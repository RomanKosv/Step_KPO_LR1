using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Step_KPO_LR1
{
    public partial class ChildWindow : Form
    {
        public List<Bitmap> old_versions = new List<Bitmap>();
        public List<Bitmap> new_versions = new List<Bitmap>();
        public bool do_save_old = false;
        public Bitmap image;
        public static int default_width=400;
        public static int default_height=300;
        public string? SavePath = null;
        public ImageFormat? format = null;
        bool saved = false;
        public MainWindow parent;
        public ChildWindow(MainWindow par)
        {
            InitializeComponent();
            image = new Bitmap(default_width, default_height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
            }
            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.None;
            this.Invalidate();
            parent = par;
        }
        public void update_image()
        {
            if (do_save_old)
            {
                old_versions.Add(image);
            }
            this.Invalidate();
            saved = false;
        }

        private void ChildWindow_MouseDown(object sender, MouseEventArgs e)
        {
            parent.paint.ChildWindow_MouseDown(this, sender, e);
        }

        private void ChildWindow_MouseLeave(object sender, EventArgs e)
        {
            parent.paint.ChildWindow_MouseLeave (this, sender, e);
        }

        private void ChildWindow_MouseMove(object sender, MouseEventArgs e)
        {
            parent.paint.ChildWindow_MouseMove(this, sender, e);
        }

        private void ChildWindow_MouseUp(object sender, MouseEventArgs e)
        {
            parent.paint.ChildWindow_MouseUp(this, sender, e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            parent.paint.OnPaint(this, e);
            if (image != null)
            {
                e.Graphics.DrawImage(image,new Rectangle(0,0,image.Width,image.Height));
                using (var pen = new Pen(Color.Black, 1)) {
                    e.Graphics.DrawRectangle(pen,0,0,image.Width,image.Height);
                }
            }
        }
    }
}
