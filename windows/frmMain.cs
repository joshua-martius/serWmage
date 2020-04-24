using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace serwmImageUploader
{
    public partial class frmMain : Form
    {
        private Configuration _config = null;
        private const string _baseString = "ABCDEFGHIJKLMNOPQ_RSTUVXYZabc-,defghijklmnopqrstuvwxyz0123456789";


        public frmMain()
        {
            InitializeComponent();
            if (!InitializeConfiguration()) Environment.Exit(0);
        }

        private bool InitializeConfiguration()
        {
            if (!Configuration.Exists)
            {
                frmConfigwizard frm = new frmConfigwizard();
                frm.ShowDialog();
                if (frm.DialogResult.Equals(DialogResult.OK))
                {
                    _config = frm.Config;
                    _config.Save();
                }
                else
                {
                    Application.Exit();
                    return false;
                }
            }
            else _config = Configuration.Load();

            HotKey HK = new HotKey();
            HK.OwnerForm = this;
            HK.HotKeyPressed += new HotKey.HotKeyPressedEventHandler(HK_trigger);
            HK.AddHotKey(Keys.R, HotKey.MODKEY.MOD_CONTROL, "mainHK");
            return true;
        }

        private void HK_trigger(string ID)
        {
            string path = this.TakeScreenshot();
            string link = this.UploadScreenshot(path);
            this.CopyLinkToClipboard(link);
            Console.Beep();
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

        private void CopyLinkToClipboard(string link)
        {
            Clipboard.SetText(link);
        }

        private string UploadScreenshot(string filepath)
        {
            string imgID = string.Empty;
            using (SftpClient sftp = new SftpClient(_config.Address, _config.Username, _config.Password))
            {
                try
                {
                    sftp.Connect();
                    sftp.ChangeDirectory(Configuration.RemoteDirectory);

                    imgID = this.generateID();

                    using(var fileStream = new FileStream(filepath, FileMode.Open))
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

        private string TakeScreenshot()
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File

                string filepath = string.Format("{0}\\tmp.png", Application.StartupPath);
                captureBitmap.Save(filepath, ImageFormat.Png);
                return filepath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
