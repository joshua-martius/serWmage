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
        // toDo: remove redundancy
        /// <summary>
        /// Takes a 1920x1080 screenshot and saves it under the given filepath.
        /// </summary>
        /// <param name="filepath">The full path into which the screenshot shall be saved.</param>
        /// <returns>The full path into which the screenshot has been saved.</returns>
        public static string TakeScreenshot(string filepath)
        {
            return TakeScreenshot(filepath, 1920, 1080);
        }

        /// <summary>
        /// Takes a 1920x1080 screenshot and saves it into the <see cref="Application.StartupPath"/>.
        /// </summary>
        /// <returns>The full path into which the screenshot has been saved.</returns>
        public static string TakeScreenshot()
        {
            return TakeScreenshot(Application.StartupPath, 1920, 1080);
        }

        /// <summary>
        /// Takes a screenshot with the given <paramref name="width"/> and <paramref name="height"/>, saves it into the given <paramref name="filepath"/>.
        /// </summary>
        /// <param name="filepath">The full path into which the screenshot shall be saved.</param>
        /// <param name="width">The width for the screenshot.</param>
        /// <param name="height">The height for the screenshot.</param>
        /// <returns></returns>
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
                Crashlogger.Write(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Takes a screenshot with the size of the given <paramref name="rect"/> and saves it into <paramref name="filepath"/>.
        /// </summary>
        /// <param name="filepath">The full path into which the screenshot shall be saved.</param>
        /// <param name="rect">The rectangle whoms boundaries the screenshot should have.</param>
        /// <returns></returns>
        public static string TakeScreenshot(string filepath, Rectangle rect)
        {
            if (rect.Width == 0 || rect.Height == 0)
            {
                Exception ex = new Exception("Zero boundaries!");
                Crashlogger.Write(ex);
                throw ex;
            }
            //Creating a new Bitmap object
            Bitmap captureBitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            //Creating a Rectangle object which will  
            //capture our Current Screen
            Rectangle captureRectangle = rect;
            //Creating a New Graphics Object
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            //Copying Image from The Screen

            int left = captureRectangle.Left;
            int top = captureRectangle.Top;

            if(Screen.AllScreens.Count() == 1) captureGraphics.CopyFromScreen(left, top, 0, 0, captureRectangle.Size);
            else captureGraphics.CopyFromScreen(left - 1920, top, 0, 0, captureRectangle.Size);

            //Saving the Image File
            filepath = string.Format("{0}\\tmp.png", filepath);
            captureBitmap.Save(filepath, ImageFormat.Png);
            return filepath;
        }
    }
}
