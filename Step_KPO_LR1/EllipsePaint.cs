using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Step_KPO_LR1
{
    public class EllipsePaint : IPainter
    {
        Point start;
        Point current;
        bool draw;
        public void ChildWindow_MouseDown(ChildWindow window, object sender, MouseEventArgs e)
        {
            start = e.Location;
            current = e.Location;
            draw = true;
        }

        public void ChildWindow_MouseLeave(ChildWindow window, object sender, EventArgs e)
        {
            if (draw)
            {
                draw = false;
                using (var g = Graphics.FromImage(window.image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var pen = new Pen(window.parent.color, window.parent.thickness))
                    {
                        g.DrawEllipse(pen, start.X, start.Y, current.X - start.X, current.Y - start.Y);
                    }
                }
                window.update_image();
            }
        }

        public void ChildWindow_MouseMove(ChildWindow window, object sender, MouseEventArgs e)
        {
            current = e.Location;
            if(draw)
                window.Invalidate();
        }

        public void ChildWindow_MouseUp(ChildWindow window, object sender, MouseEventArgs e)
        {
            draw = false;
            using (var g = Graphics.FromImage(window.image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var pen = new Pen(window.parent.color, window.parent.thickness))
                {
                    g.DrawEllipse(pen, start.X, start.Y, e.Location.X - start.X, e.Location.Y - start.Y);
                }
            }
            window.update_image();
        }

        public void OnPaint(ChildWindow window, PaintEventArgs e)
        {
            if (draw)
            {
                using (var pen = new Pen(window.parent.color, window.parent.thickness))
                {
                    e.Graphics.DrawEllipse(pen, start.X, start.Y, current.X - start.X, current.Y - start.Y);
                }
            }
        }
    }
}
