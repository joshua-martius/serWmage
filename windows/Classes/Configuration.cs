using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serwmImageUploader
{
    public class Configuration
    {
        private const int CONFIG_AMOUNT = 5;

        private string[] _config = new string[CONFIG_AMOUNT];
        
        public string Address { get => _config[0]; set => _config[0] = value; }
        public string Username { get => _config[1]; set => _config[1] = value; }
        public string Password { get => _config[2]; set => _config[2] = value; }

        private static string Filepath { get => string.Format("{0}\\config.ini", System.Windows.Forms.Application.StartupPath); }

        public string RemoteDirectory { get => _config[3]; set => _config[3] = value; }

        public static bool Exists { get => File.Exists(Configuration.Filepath); }

        public bool OpenImageAfterUpload { get => Convert.ToBoolean(_config[4]); set => _config[4] = value.ToString(); }

        public void Save() => File.WriteAllLines(Configuration.Filepath, _config);

        public static Configuration Load()
        {
            try
            {
                Configuration config = new Configuration();
                config._config = File.ReadAllLines(Configuration.Filepath);
                if (config._config.Length != CONFIG_AMOUNT) throw new Exception("Incomplete configuration!\nDelete your configuration file and create a new one.");
                return config;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Configuration files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
        }

        public Configuration(){ }
    }
}
