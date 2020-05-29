using System;
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
        private bool _openCropping = false;
        
        public frmMain()
        {
            InitializeComponent();
            if (!InitializeConfiguration()) Environment.Exit(0);
            this.Text += " V" + Application.ProductVersion;
            this.grpDragNDrop.AllowDrop = true;
            this.grpDragNDrop.DragEnter += this.GrpDragNDrop_DragEnter;
            this.grpDragNDrop.DragDrop += this.GrpDragNDrop_DragDrop;

        }

        public frmMain(List<string> args) : this()
        {
            if(args.Count.Equals(1))
            {
                if(File.Exists(args[0]) && args[0].EndsWith(".png"))
                {
                    string filepath = args[0];
                    string link = _web.UploadScreenshot(filepath, false);
                    this.CopyToClipboard(link);
                    if(_web.Config.PlayBeep) Console.Beep();
                    this.Close();
                }
            }
        }

        private void GrpDragNDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] filearray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filepath = filearray[0];
            string link = _web.UploadScreenshot(filepath, false);
            this.CopyToClipboard(link);
            if(_web.Config.PlayBeep) Console.Beep();
        }

        private void GrpDragNDrop_DragEnter(object sender, DragEventArgs e)
        {
            string[] filearray = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            List<string> filelist = filearray.ToList();
            if (!filelist.TrueForAll(str => str.EndsWith(".png"))) return;
            else e.Effect = DragDropEffects.Copy;
        }

        private void Drawer_FormClosed(object sender, FormClosedEventArgs e)
        {
            _openCropping = false;
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

            HotKey HK = new HotKey();
            HK.OwnerForm = this;
            HK.HotKeyPressed += new HotKey.HotKeyPressedEventHandler(HK_trigger);
            HK.AddHotKey(Keys.R, HotKey.MODKEY.MOD_CONTROL, "CTRL-R");
            HK.AddHotKey(Keys.F2, HotKey.MODKEY.MOD_NONE, "F2");
            HK.AddHotKey(Keys.Pause, HotKey.MODKEY.MOD_SHIFT, "SHIFT-BREAK");
            HK.AddHotKey(Keys.Pause, HotKey.MODKEY.MOD_NONE, "BREAK");

            this.btnShowCrashfile.Enabled = Crashlogger.LogExits;
            return true;
        }

        private void HK_trigger(string ID)
        {
            switch (ID)
            {
                case "CTRL-R":
                    string path = Screenshotter.TakeScreenshot();
                    string link = _web.UploadScreenshot(path);
                    this.CopyToClipboard(link, path);
                    if (_web.Config.OpenImageAfterUpload) Process.Start(link);
                    if(_web.Config.PlayBeep) Console.Beep();
                    break;
                case "F2":
                    if(!_openCropping)
                    {
                        frmDrawInstance drawer = new frmDrawInstance();
                        drawer.FormClosed += this.Drawer_FormClosed;
                        _openCropping = true;
                        drawer.ShowDialog();
                    }
                    break;
                case "BREAK":
                    if (this.Visible) this.Hide();
                    else this.Show();
                    break;
                case "SHIFT-BREAK":
                    if(_web.Config.PlayBeep) Console.Beep();
                    if(_web.Config.PlayBeep) Console.Beep();
                    Application.Exit();
                    return;
                default:
                    break;
            }
        }

        private void CopyToClipboard(string link)
        {
            if(link != null) Clipboard.SetText(link);
        }       

        private void CopyToClipboard(string link, string filepath)
        {
            this.CopyToClipboard(link);
            if (File.Exists(filepath))
            {
                // ** add image to clipboard
                Clipboard.SetData(DataFormats.Bitmap, Bitmap.FromFile(filepath));
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
    }
}
