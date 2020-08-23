using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using serwmImageUploader.Forms;

namespace serwmImageUploader
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Count() == 2 && (args[1] == "-directdraw" || args[1] == "-dd"))
            {
                Application.Run(new frmMain(true));
            }
            else if (!(Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1) || args.Count() == 1)
            {
                // prevent multiple instances, except if command line arguments were used
                Application.Run(new frmMain(args.ToList()));
            }
            else MessageBox.Show("Only one instance at the time possible!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }
    }
}
