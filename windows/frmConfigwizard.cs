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

        public Configuration Config { get => this._config; }

        private void btnSaveRun_Click(object sender, EventArgs e)
        {
            _config = new Configuration(tbxUsername.Text, tbxPassword.Text);
            _config.Save();
            this.Close();
        }
    }
}
