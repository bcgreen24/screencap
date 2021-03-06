using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows;

namespace screenCap
{
    public partial class Overlay : Form
    {
        private int counter = 1;
        private int x, y = 0;
        private double bbx, bby;
        private double scalingFactor = 1;
        private bool _canDraw;
        private int _startX, _startY;
        private Rectangle _rect;
        private bool paint;
        public string strSavePath;
        public Overlay()
        {
            InitializeComponent();
            scalingFactor = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;
        }

        private void setSavePath(string path)
        {
            this.strSavePath = path;
        }

        private void Overlay_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (!_canDraw) return;
            
            int x = Math.Min(_startX, e.X);
            int y = Math.Min(_startY, e.Y);
            int width = Math.Max(_startX, e.X) - Math.Min(_startX, e.X);
            int height = Math.Max(_startY, e.Y) - Math.Min(_startY, e.Y);
            _rect = new Rectangle(x, y, width, height);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (paint)
            {
                using (Pen pen = new Pen(Color.Red, 4))
                {
                    e.Graphics.DrawRectangle(pen, _rect);
                }
            }
            
        }

        private void Overlay_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.paint = true;
            _canDraw = true;
            _startX = e.X;
            _startY = e.Y;
            Point p = PointToScreen(e.Location);
            this.x = p.X;
            this.y = p.Y;
        }

        private void Overlay_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                this.paint = false;
                this.Opacity = 0.0;
                _canDraw = false;
                this.bbx = (e.Location.X - this.x) * scalingFactor;
                this.bby = (e.Location.Y - this.y) * scalingFactor;
                Bitmap captureBitmap = new Bitmap(Convert.ToInt32(bbx / scalingFactor), Convert.ToInt32(bby / scalingFactor), PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = new Rectangle(this.x, this.y, Convert.ToInt32(bbx), Convert.ToInt32(bby));
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                Console.WriteLine(this.strSavePath);
                captureBitmap.Save(this.strSavePath + "\\capture" + counter.ToString() + ".jpg", ImageFormat.Jpeg);
                counter++;
                this.Opacity = 0.2;
                this.Hide();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
