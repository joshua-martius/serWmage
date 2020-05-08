using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace serwmImageUploader.Classes
{
    public static class Crashlogger
    {
        private static string _filepath = string.Format("{0}/crashes.log", Application.StartupPath);

        public static void Write(Exception exception, bool includeTimestamp = true) => Crashlogger.Write(exception.Message, includeTimestamp);
        
        public static void Write(string message, bool includeTimestamp = true)
        {
            string output = string.Empty;
            if (includeTimestamp) output = Crashlogger.getTimestamp() + ": ";
            output += message;
            File.AppendAllText(_filepath, output);
        }

        private static string getTimestamp() => string.Format("[{0}]", DateTime.Now.ToShortTimeString());
    }
}
