using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace screenCap
{
    public partial class frmScreenCapMain : Form
    {
        private Form frmOverlay = new Overlay();
        private KeyHandler ghk;

        public frmScreenCapMain()
        {
            InitializeComponent();
            ghk = new KeyHandler(Keys.F6, this);
            ghk.Register();
        }

        private void HandleHotKey()
        {
            try
            {
                frmOverlay.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                HandleHotKey();
            }
            base.WndProc(ref m);
        }
    }

    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private IntPtr hWnd;
        private int id;


        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, 0, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }

    public static class Constants
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }


}
