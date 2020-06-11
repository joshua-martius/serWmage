using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serwmImageUploader
{
    public partial class frmConfigwizard : Form
    {
        Configuration _config = null;

        public frmConfigwizard()
        {
            InitializeComponent();
        }

        public frmConfigwizard(Configuration config) : this()
        {
            this.tbxUsername.Text = config.Username;
            this.tbxPassword.Text = config.Password;
            
            this.tbxRemoteDirectory.Text = config.RemoteDirectory;
            this.tbxServerAddress.Text = config.Address;

            this.radImageToClipboard.Checked = !config.LinkToClipboard;
            this.radLinkToClipboard.Checked = config.LinkToClipboard;

            radUseSSHKey.Checked = config.UseKeyFile;
            radUsePassword.Checked = !config.UseKeyFile;

            if (config.UseKeyFile) tbxKeyFilePath.Text = config.PathToKeyFile;
            chkPlayBeep.Checked = config.PlayBeep;
            this.chkOpenAfterCreation.Checked = Convert.ToBoolean(config.OpenImageAfterUpload);
        }

        public Configuration Config { get => this._config; }

        private bool isValidConfig()
        {
            // ToDo: more validation
            if (tbxRemoteDirectory.Text[tbxRemoteDirectory.Text.Length - 1] != '/') return false;
            return true;
        }

        private void btnSaveRun_Click(object sender, EventArgs e)
        {
            if(isValidConfig())
            {
                _config = new Configuration();
                _config.Username = tbxUsername.Text;
                _config.Password = tbxPassword.Text;
                _config.Address = tbxServerAddress.Text;
                _config.RemoteDirectory = tbxRemoteDirectory.Text;
                _config.OpenImageAfterUpload = chkOpenAfterCreation.Checked;
                _config.LinkToClipboard = radLinkToClipboard.Checked;
                _config.UseKeyFile = radUseSSHKey.Checked;
                _config.PlayBeep = chkPlayBeep.Checked;
                if (_config.UseKeyFile) _config.PathToKeyFile = tbxKeyFilePath.Text;
                _config.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Missing or wrong configuration details!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radUseSSHKey_CheckedChanged(object sender, EventArgs e)
        {
            tbxPassword.Clear();
            tbxKeyFilePath.Visible = radUseSSHKey.Checked;
            btnBrowseKeyFile.Visible = radUseSSHKey.Checked;

            tbxPassword.Visible = radUsePassword.Checked;

            if (tbxPassword.Visible) lblPassword.Text = "Password: ";
            else lblPassword.Text = "SSH-File:";
        }

        private void btnBrowseKeyFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = string.Format("Select SSH-Keyfile for {0}@{1}", tbxUsername.Text, tbxServerAddress.Text);
            if(dlg.ShowDialog().Equals(DialogResult.OK))
            {
                tbxKeyFilePath.Text = dlg.FileName;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }
    }
}
