using System;
using System.Collections.Generic;
using System.Text;

namespace Step_KPO_LR1
{
    public interface IPainter
    {
        public delegate void Paint(ChildWindow window, object sender, MouseEventArgs e);
        public void ChildWindow_MouseDown(ChildWindow window, object sender, MouseEventArgs e);
        public void ChildWindow_MouseLeave(ChildWindow window, object sender, EventArgs e);
        public void ChildWindow_MouseMove(ChildWindow window, object sender, MouseEventArgs e);
        public void ChildWindow_MouseUp(ChildWindow window, object sender, MouseEventArgs e);
        public void OnPaint(ChildWindow w, PaintEventArgs e);
    }
}
