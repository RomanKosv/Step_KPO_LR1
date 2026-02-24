using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Step_KPO_LR1
{
    internal class Line : IPainter
    {
        Point last;
        Point curr;
        bool draw = false;
        public void ChildWindow_MouseDown(ChildWindow window, object sender, MouseEventArgs e)
        {
            last = e.Location;
            draw = e.Button == MouseButtons.Left;
        }

        public void ChildWindow_MouseLeave(ChildWindow window, object sender, EventArgs e)
        {
            //pass
        }

        public void ChildWindow_MouseMove(ChildWindow window, object sender, MouseEventArgs e)
        {
            curr = e.Location;
            if (draw) window.Invalidate();
        }

        public void ChildWindow_MouseUp(ChildWindow window, object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && draw)
            {
                using (var g = Graphics.FromImage(window.image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var pen = new Pen(window.parent.color, window.parent.thickness))
                    {
                        curr = e.Location;
                        g.DrawLine(pen, last, curr);
                    }
                }
                window.update_image();
            }
            draw = false;
        }

        public void OnPaint(ChildWindow window, PaintEventArgs e)
        {
            if (draw)
            {
                using (var pen = new Pen(window.parent.color, window.parent.thickness))
                {
                    e.Graphics.DrawLine(pen, last, curr);
                }
            }
        }
    }
}
