using System;
using System.Collections.Generic;
using System.Text;

namespace Step_KPO_LR1
{
    internal class Lastik:IPainter
    {
        Point lastPoint;
        public void ChildWindow_MouseDown(ChildWindow window, object sender, MouseEventArgs e)
        {
            //pass
            lastPoint = e.Location;
        }

        public void ChildWindow_MouseLeave(ChildWindow window, object sender, EventArgs e)
        {
            //pass
        }

        public void ChildWindow_MouseMove(ChildWindow window, object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (var g = Graphics.FromImage(window.image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var pen = new Pen(Color.White, window.parent.thickness))
                    {
                        g.DrawLine(pen, lastPoint, e.Location);
                        lastPoint = e.Location;
                    }
                }
                window.update_image();
            }
        }

        public void ChildWindow_MouseUp(ChildWindow window, object sender, MouseEventArgs e)
        {
            //pass
        }

        public void OnPaint(ChildWindow w, PaintEventArgs e)
        {
            //pass
        }
    }
}
