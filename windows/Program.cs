using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serwmImageUploader
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!(Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1))
            {
                // prevent multiple instances
                Application.Run(new frmMain());
            }
            else MessageBox.Show("Only one instance at the time possible!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }
    }
}
