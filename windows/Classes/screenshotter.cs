using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serwmImageUploader.Classes
{
    public static class Screenshotter
    {

        public static string TakeScreenshot(string filepath)
        {
            return Screenshotter.TakeScreenshot(filepath, 1920, 1080);
        }

        public static string TakeScreenshot()
        {
            return Screenshotter.TakeScreenshot(Application.StartupPath, 1920, 1080);
        }
        public static string TakeScreenshot(string filepath, int width, int height)
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = Screen.FromPoint(Cursor.Position).Bounds;
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File

                filepath = string.Format("{0}\\tmp.png", filepath);
                captureBitmap.Save(filepath, ImageFormat.Png);
                return filepath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
