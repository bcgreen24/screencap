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
        private int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        private int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private double scalingFactor = 1;
        private bool _canDraw;
        private int _startX, _startY;
        private Rectangle _rect;

        public Overlay()
        {
            InitializeComponent();
           
            scalingFactor = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;
        }

        private void Overlay_MouseMove(object sender, MouseEventArgs e)
        {
            //If we are not allowed to draw, simply return and disregard the rest of the code
            if (!_canDraw) return;

            //The x-value of our rectangle should be the minimum between the start x-value and the current x-position
            int x = Math.Min(_startX, e.X);
            //The y-value of our rectangle should also be the minimum between the start y-value and current y-value
            int y = Math.Min(_startY, e.Y);

            //The width of our rectangle should be the maximum between the start x-position and current x-position minus
            //the minimum of start x-position and current x-position
            int width = Math.Max(_startX, e.X) - Math.Min(_startX, e.X);

            //For the hight value, it's basically the same thing as above, but now with the y-values:
            int height = Math.Max(_startY, e.Y) - Math.Min(_startY, e.Y);
            _rect = new Rectangle(x, y, width, height);
            //Refresh the form and draw the rectangle
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Create a new 'pen' to draw our rectangle with, give it the color red and a width of 2
            using (Pen pen = new Pen(Color.Red, 4))
            {
                //Draw the rectangle on our form with the pen
                e.Graphics.DrawRectangle(pen, _rect);
            }
        }

        private void Overlay_Load(object sender, EventArgs e)
        {

        }

        private void Overlay_MouseDown_1(object sender, MouseEventArgs e)
        {
            //The system is now allowed to draw rectangles
            _canDraw = true;
            //Initialize and keep track of the start position
            _startX = e.X;
            _startY = e.Y;

            Point p = PointToScreen(e.Location);

            this.x = p.X;
            this.y = p.Y;
                    
        }

        private void Overlay_MouseUp(object sender, MouseEventArgs e)
        {
            //The system is no longer allowed to draw rectangles
            _canDraw = false;


            this.bbx = (e.Location.X - this.x) * scalingFactor;
            this.bby = (e.Location.Y - this.y) * scalingFactor;

            Bitmap captureBitmap = new Bitmap(Convert.ToInt32(bbx/scalingFactor), Convert.ToInt32(bby/scalingFactor), PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = new Rectangle(this.x, this.y, Convert.ToInt32(bbx), Convert.ToInt32(bby));
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

            captureBitmap.Save(@"c:\Users\Bryan Green\Pictures\capture" + counter.ToString() + ".jpg", ImageFormat.Jpeg);

            counter++;
            this.Hide();
        }
    }
}
