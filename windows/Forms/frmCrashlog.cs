using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using serwmImageUploader.Classes;
using System.IO;

namespace serwmImageUploader.Forms
{
    public partial class frmCrashlog : Form
    {
        private bool _logExists { get => File.Exists(Crashlogger.Filepath); }

        public frmCrashlog()
        {
            InitializeComponent();
            if(_logExists) rtbCrashlog.Text = File.ReadAllText(Crashlogger.Filepath);
            else
            {
                MessageBox.Show("There are no crashes logged yet!","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Crashlogger.Filepath);
                rtbCrashlog.Clear();
            }
            catch (Exception ex)
            {
                Crashlogger.Write(ex.Message);
                rtbCrashlog.AppendText(ex.Message);
            }
        }
    }
}
