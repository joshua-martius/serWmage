using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using serwmImageUploader.Classes;

namespace serwmImageUploader.Forms
{
    public partial class frmDrawInstance : Form
    {
        private int[] _initial = new int[2];
        private bool _isSet = false;
        private System.Drawing.Graphics formGraphics = null;
        private Brush _brush = new SolidBrush(Color.FromArgb(255, 16, 16, 16));
        private Pen _drawPen = null;
        private Rectangle _rect = new Rectangle();

        public frmDrawInstance()
        {
            InitializeComponent();
            //this.Size = Screen.FromPoint(Cursor.Position).Bounds.Size;
            int width = Screen.AllScreens.ToList().Sum(scr => scr.Bounds.Width);
            int height = Screen.AllScreens.ToList().Max(scr => scr.Bounds.Height);
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(width, height);

            this.CenterToScreen();
            this.Location = new Point(this.Location.X, this.Location.Y);




            _drawPen = new Pen(_brush, 2);
            formGraphics = this.CreateGraphics();
        }

        private void frmDrawInstance_MouseMove(object sender, MouseEventArgs e)
        {
            if(_isSet)
            {
                _rect.X =       Math.Min(e.X, _initial[0]);
                _rect.Y =       Math.Min(e.Y, _initial[1]);
                _rect.Width =   Math.Abs(e.X - _initial[0]);
                _rect.Height =  Math.Abs(e.Y - _initial[1]);
                formGraphics.DrawRectangle(_drawPen, _rect);
            }
        }

        private void frmDrawInstance_MouseDown(object sender, MouseEventArgs e)
        {
            _initial[0] = e.X;
            _initial[1] = e.Y;
            _isSet = true;            
            Cursor.Current = Cursors.Hand;
        }

        private void frmDrawInstance_MouseUp(object sender, MouseEventArgs e)
        {
            _isSet = false;
            Cursor.Current = Cursors.Default;
            this.Hide(); // prevent the form from being visible on the screenshot
            Screenshotter.TakeScreenshot(Application.StartupPath, _rect);
            this.Close();
        }

        private void frmDrawInstance_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Escape))
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
