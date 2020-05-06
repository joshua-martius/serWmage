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
        private const string _baseString = "ABCDEFGHIJKLMNOPQ_RSTUVXYZabc,defghijklmnopqrstuvwxyz0123456789";
        private Configuration _config = null;

        /// <summary>
        /// The <see cref="Configuration"/> on which the <see cref="WebHandler"/> relies.
        /// </summary>
        public Configuration Config { get => this._config; set => this._config = value; }

        /// <summary>
        /// Initializes a new <see cref="WebHandler"/> object with a given <see cref="Configuration"/> set.
        /// </summary>
        /// <param name="config">The <see cref="Configuration"/> of the new <see cref="WebHandler"/> object.</param>
        public WebHandler(Configuration config)
        {
            _config = config;
        }

        /// <summary>
        /// Initializes a blank <see cref="WebHandler"/>.
        /// </summary>
        public WebHandler() { }

        /// <summary>
        /// Uploads the given Screenshot to the server which is given in the <see cref="Config"/> object.
        /// </summary>
        /// <param name="filepath">The local filepath to the screenshot which shall be uploaded.</param>
        /// <returns>The URL to the image on the remote imageserver.</returns>
        public string UploadScreenshot(string filepath)
        {
            string imgID = string.Empty;
            using (SftpClient sftp = new SftpClient(_config.Address, _config.Username, _config.Password))
            {
                try
                {
                    sftp.Connect();
                    sftp.ChangeDirectory(_config.RemoteDirectory);
                    var files = sftp.ListDirectory(_config.RemoteDirectory).ToList();

                    // ** Duplicate Check
                    string filename = string.Empty;
                    do
                    {
                        imgID = this.generateID();
                        filename = "." + imgID + ".png";
                    } while (!(files.TrueForAll(f => !f.Name.Equals(filename))));
                    
                    using (var fileStream = new FileStream(filepath, FileMode.Open))
                    {
                        sftp.BufferSize = 4096;
                        string remotePath = string.Format("{0}/{1}", _config.RemoteDirectory, filename);
                        sftp.UploadFile(fileStream, remotePath);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            File.Delete(filepath);
            return string.Format("https://{0}/.{1}.png", _config.Address, imgID);
        }

        /// <summary>
        /// Generates a random alphanumerical <see cref="string"/> with a given length.
        /// </summary>
        /// <param name="length">The length to the generated <see cref="string"/>.</param>
        /// <returns>A random alphanumerical <see cref="string"/>.</returns>
        private string generateID(int length = 16)
        {
            string output = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < length; i++) output += _baseString[rnd.Next(0, _baseString.Length)];
            return output;
        }
    }
}
