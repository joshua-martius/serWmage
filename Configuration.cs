using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serwmImageUploader
{
    public class Configuration
    {
        string _address = string.Empty;
        string _username = string.Empty;
        string _password = string.Empty;

        public string Address { get => this._address; }
        public string Username { get => this._username; }
        public string Password { get => this._password; }

        private static string Filepath { get => string.Format("{0}\\config.ini", System.Windows.Forms.Application.StartupPath); }

        public static string RemoteDirectory { get => string.Format("/home/webserver/webroot/img/"); }

        public static bool Exists { get => File.Exists(Configuration.Filepath); }

        public void Save()
        {
            string content = string.Format("{0}\n{1}", _username, _password);
            File.WriteAllText(Configuration.Filepath, content);
        }

        public static Configuration Load()
        {
            string[] content = File.ReadAllLines(Configuration.Filepath);
            return new Configuration(content[0], content[1]);
        }

        public Configuration(){ this._address = "serwm.com"; }
        public Configuration(string username, string password) : this()
        {
            this._username = username;
            this._password = password;
        }
    }
}
