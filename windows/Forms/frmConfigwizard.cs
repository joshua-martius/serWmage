using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            this.chkOpenAfterCreation.Checked = Convert.ToBoolean(config.OpenImageAfterUpload);
        }

        public Configuration Config { get => this._config; }

        private void btnSaveRun_Click(object sender, EventArgs e)
        {
            _config = new Configuration();
            _config.Username = tbxUsername.Text;
            _config.Password = tbxPassword.Text;
            _config.Address = tbxServerAddress.Text;
            _config.RemoteDirectory = tbxRemoteDirectory.Text;
            _config.OpenImageAfterUpload = chkOpenAfterCreation.Checked;
            _config.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
