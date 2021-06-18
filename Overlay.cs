using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenCap
{
    public partial class Overlay : Form
    {
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine(e.X.ToString());
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            Console.WriteLine("HEllo");
        }

        private void Overlay_MouseDown_1(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location.ToString());
        }

        private void Overlay_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location.ToString());
        }
    }
}
