﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using serwmImageUploader.Classes;
using Renci.SshNet.Sftp;
using serwmImageUploader.Forms;
using System.Diagnostics;

namespace serwmImageUploader
{
    public partial class frmMain : Form
    {
        private WebHandler _web = null;
        
        public frmMain(bool directDraw = false)
        {
            InitializeComponent();
            if (!InitializeConfiguration()) Environment.Exit(0);
            if(directDraw)
            {
                this.Hide();
                frmDrawInstance frm = new frmDrawInstance();
                if(frm.ShowDialog().Equals(DialogResult.OK))
                {
                    Drawer_FormClosed(frm, null);
                    this.Close();
                }
            }
            this.Text += " V" + Application.ProductVersion;
            this.AllowDrop = true;
            this.DragEnter += this.FrmMain_DragEnter;
            this.DragDrop += this.FrmMain_DragDrop;
        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] filearray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filepath = filearray[0];
            string link = _web.UploadScreenshot(filepath, false);
            this.CopyToClipboard(link, filepath, true);
            if (_web.Config.PlayBeep) Console.Beep();
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            string[] filearray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            List<string> filelist = filearray.ToList();
            if (!filelist.TrueForAll(str => str.EndsWith(".png"))) return;
            else e.Effect = DragDropEffects.Copy;
        }

        ~frmMain() => File.Delete(Application.StartupPath + "\\.png");

        public frmMain(List<string> args) : this()
        {
            if(args.Count.Equals(1))
            {
                if(File.Exists(args[0]) && args[0].EndsWith(".png"))
                {
                    string filepath = args[0];
                    string link = _web.UploadScreenshot(filepath, false);
                    this.CopyToClipboard(link, filepath);
                    if(_web.Config.PlayBeep) Console.Beep();
                    this.Close();
                }
            }
        }

        private void Drawer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_openCropping = false;
            try
            {
                Form send = (Form)sender;
                if (send.DialogResult == DialogResult.Cancel) return;
                string filepath = Application.StartupPath + "\\tmp.png";
                string link = _web.UploadScreenshot(filepath);
                this.CopyToClipboard(link, filepath);
                if (_web.Config.OpenImageAfterUpload && link != null) Process.Start(link);
                if(_web.Config.PlayBeep) Console.Beep();
            }
            catch (Exception ex)
            {
                Crashlogger.Write(ex);
                throw ex;
            }
        }

        private bool InitializeConfiguration()
        {
            _web = new WebHandler();
            if (!Configuration.Exists)
            {
                frmConfigwizard frm = new frmConfigwizard();
                frm.ShowDialog();
                if (frm.DialogResult.Equals(DialogResult.OK))
                {
                    _web.Config = frm.Config;
                    _web.Config.Save();
                }
            }
            else _web.Config = Configuration.Load();

            

            this.btnShowCrashfile.Enabled = Crashlogger.LogExits;
            return true;
        }

        private void CopyToClipboard(string link, string filepath, bool forceLink = false)
        {
            if (forceLink || _web.Config.LinkToClipboard)
            {
                if (link != null) Clipboard.SetText(link);
            }
            else
            {
                if (File.Exists(filepath)) Clipboard.SetData(DataFormats.Bitmap,Bitmap.FromFile(filepath));
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOpenConfiguration_Click(object sender, EventArgs e)
        {
            frmConfigwizard frm = new frmConfigwizard(_web.Config);
            if(frm.ShowDialog().Equals(DialogResult.OK))
            {
                _web.Config = frm.Config;
            }
        }

        private void btnShowCrashfile_Click(object sender, EventArgs e)
        {
            try
            {
                frmCrashlog frm = new frmCrashlog();
                DialogResult result = frm.ShowDialog();
                if (result.Equals(DialogResult.Cancel)) this.btnShowCrashfile.Enabled = false;
            }
            catch{}
        }

        private void btnUploadCustom_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PNG-Images|*.png";
            dlg.Title = "Open Image for uploading to " + _web.Config.Address;
            if(dlg.ShowDialog().Equals(DialogResult.OK))
            {
                string filepath = dlg.FileName;
                if (!filepath.EndsWith(".png")) throw new Exception("Invalid file selected!");
                string link = _web.UploadScreenshot(filepath, false);
                this.CopyToClipboard(link, filepath);
                if(_web.Config.PlayBeep) Console.Beep();
            }
        }

        private void lblGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/y0sh1DE/serwmage");
        }
    }
}
