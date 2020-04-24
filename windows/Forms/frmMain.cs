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

namespace serwmImageUploader
{
    public partial class frmMain : Form
    {
        private WebHandler _web = null;

        public frmMain()
        {
            InitializeComponent();
            if (!InitializeConfiguration()) Environment.Exit(0);
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
            HK.AddHotKey(Keys.R, HotKey.MODKEY.MOD_CONTROL, "mainHK");
            return true;
        }

        private void HK_trigger(string ID)
        {
            Console.Beep();
            string path = Screenshotter.TakeScreenshot();
            string link = _web.UploadScreenshot(path);
            this.CopyLinkToClipboard(link);
            Console.Beep();
        }

        private void CopyLinkToClipboard(string link)
        {
            Clipboard.SetText(link);
        }       

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
