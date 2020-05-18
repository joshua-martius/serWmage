using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using serwmImageUploader.Classes;

namespace serwmImageUploader
{
    public class Configuration
    {
        private const int CONFIG_AMOUNT = 7;

        private string[] _config = new string[CONFIG_AMOUNT];
       
        public string PathToKeyFile 
        {
            get => _config[6];
            set
            {
                if (!UseKeyFile) throw new Exception("UseKeyFile not set!");
                else _config[6] = value;
            }
        }

        /// <summary>
        /// Indicates wether password login or key file login shall be used.
        /// </summary>
        public bool UseKeyFile { get => Convert.ToBoolean(_config[5]); set => _config[5] = value.ToString(); }

        /// <summary>
        /// The Imageserver's address.
        /// </summary>
        public string Address { get => _config[0]; set => _config[0] = value; }
        
        /// <summary>
        /// The SFTP username for the Imageserver.
        /// </summary>
        public string Username { get => _config[1]; set => _config[1] = value; }
        
        /// <summary>
        /// The password of the SFTP user for the Imageserver.
        /// </summary>
        public string Password { get => _config[2]; set => _config[2] = value; }

        /// <summary>
        /// The full filepath of the configuration file.
        /// </summary>
        private static string Filepath { get => string.Format("{0}\\config.ini", Application.StartupPath); }

        /// <summary>
        /// The directory of the images on the remote Imageserver.
        /// </summary>
        public string RemoteDirectory { get => _config[3]; set => _config[3] = value; }

        /// <summary>
        /// Determines wether a configuration file exists or not.
        /// </summary>
        public static bool Exists { get => File.Exists(Configuration.Filepath); }

        /// <summary>
        /// Determines if a new taken image shall be opened after it has been uploaded.
        /// </summary>
        public bool OpenImageAfterUpload { get => Convert.ToBoolean(_config[4]); set => _config[4] = value.ToString(); }

        /// <summary>
        /// Saves the current <see cref="Configuration"/> into the <see cref="Filepath"/>.
        /// </summary>
        public void Save() => File.WriteAllLines(Configuration.Filepath, _config);

        /// <summary>
        /// Loads the configuration file from <see cref="Filepath"/>.
        /// </summary>
        /// <returns>A <see cref="Configuration"/> object with all the attributes from the saved configuration file.</returns>
        public static Configuration Load()
        {
            try
            {
                Configuration config = new Configuration();
                config._config = File.ReadAllLines(Configuration.Filepath);
                if (config._config.Length != CONFIG_AMOUNT)
                {
                    Exception ex = new Exception("Incomplete configuration!\nDelete your configuration file and create a new one.");
                    Crashlogger.Write(ex);
                    throw ex;
                }
                return config;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Configuration files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// Initializes a blank configuration object.
        /// </summary>
        public Configuration(){ }
    }
}
