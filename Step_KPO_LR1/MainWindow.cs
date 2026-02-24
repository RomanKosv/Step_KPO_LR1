using System.Drawing.Imaging;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Step_KPO_LR1
{
    public partial class MainWindow : Form
    {
        public Color color = Color.Red;
        public float thickness = 4;
        public IPainter paint = new Painter();
        public HashSet<ChildWindow> childs = new HashSet<ChildWindow>();
        public MainWindow()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        public void CreatePaint()
        {
            ChildWindow wind = new ChildWindow(this);
            wind.MdiParent = this;
            wind.Show();
            childs.Add(wind);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)//create image
        {
            CreatePaint();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = Color.Blue;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = Color.Green;
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = color;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    color = dialog.Color;
                }
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form child = this.ActiveMdiChild;
            if (child is ChildWindow window)
            {
                if (window.SavePath != null)
                {
                    window.image.Save(window.SavePath, window.format ?? ImageFormat.Jpeg);
                }
                else
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            paint = new Painter();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            paint = new EllipsePaint();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            paint = new Lastik();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            paint = new Line();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            thickness = 1;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            thickness = 2;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            thickness = 4;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            thickness = 8;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            thickness = 16;
        }

        private void layoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif";
                dialog.Title = "Выберите изображение";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap img;
                        using (var stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            img = new Bitmap(Image.FromStream(stream));
                        }
                        var w = new ChildWindow(this);
                        w.SavePath = dialog.FileName;
                        w.image = img;
                        w.MdiParent = this;
                        w.Show();
                        childs.Add(w);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке: " + ex.Message);
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form child = this.ActiveMdiChild;
            if (child is ChildWindow window)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Изображение JPEG (*.jpg)|*.jpg|Точечный рисунок BMP (*.bmp)|*.bmp";
                    dialog.Title = "Save as";
                    dialog.FileName = window.SavePath ?? dialog.FileName;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat format = ImageFormat.Jpeg;
                        if (dialog.FilterIndex == 2)
                        {
                            format = ImageFormat.Bmp;
                        }
                        window.image.Save(dialog.FileName, format);
                        window.SavePath = dialog.FileName;
                        window.format = format;
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form child = this.ActiveMdiChild;
            if (child is ChildWindow window)
            {
                var dialog = new SetSize();

            }
        }
    }
}
