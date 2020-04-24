using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serwmImageUploader.Classes
{
    public class WebHandler
    {
        private const string _baseString = "ABCDEFGHIJKLMNOPQ_RSTUVXYZabc-,defghijklmnopqrstuvwxyz0123456789";
        private Configuration _config = null;

        public Configuration Config { get => this._config; set => this._config = value; }

        public WebHandler(Configuration config)
        {
            _config = config;
        }

        public WebHandler() { }

        public string UploadScreenshot(string filepath)
        {
            string imgID = string.Empty;
            using (SftpClient sftp = new SftpClient(_config.Address, _config.Username, _config.Password))
            {
                try
                {
                    sftp.Connect();
                    sftp.ChangeDirectory(Configuration.RemoteDirectory);

                    imgID = this.generateID();

                    using (var fileStream = new FileStream(filepath, FileMode.Open))
                    {
                        sftp.BufferSize = 4096;
                        string remotePath = string.Format("{0}/{1}.png", Configuration.RemoteDirectory, imgID);
                        sftp.UploadFile(fileStream, remotePath);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            File.Delete(filepath);
            return string.Format("https://img.serwm.com/{0}.png", imgID);
        }

        private string generateID(int length = 16)
        {
            string output = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                output += _baseString[rnd.Next(0, _baseString.Length)];
            }
            return output;
        }
    }
}
