using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_Week2_HW_Form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                HTree(e.Graphics, new Point(350, 350), new Size(200, 200), 7);
                SierpinskiTree(e.Graphics, new Point(350, 350), new Size(400, 400), 7);
                //BoomVanPythagoras(e.Graphics);
            }
        }

        private void HTree(Graphics g, Point location, Size size, int amount) {
            if (amount > 0) {
                g.DrawLine(new Pen(Color.Black), new Point(location.X - (size.Width / 2), location.Y), new Point(location.X + (size.Width / 2), location.Y));
                g.DrawLine(new Pen(Color.Black), new Point(location.X - (size.Width / 2), location.Y - (size.Height / 2)), new Point(location.X - (size.Width / 2), location.Y + (size.Height / 2)));
                g.DrawLine(new Pen(Color.Black), new Point(location.X + (size.Width / 2), location.Y - (size.Height / 2)), new Point(location.X + (size.Width / 2), location.Y + (size.Height / 2)));
                HTree(g, new Point(location.X - size.Width / 2, location.Y - size.Height / 2), new Size(size.Width / 2, size.Height / 2), amount - 1);
                HTree(g, new Point(location.X + size.Width / 2, location.Y - size.Height / 2), new Size(size.Width / 2, size.Height / 2), amount - 1);
                HTree(g, new Point(location.X - size.Width / 2, location.Y + size.Height / 2), new Size(size.Width / 2, size.Height / 2), amount - 1);
                HTree(g, new Point(location.X + size.Width / 2, location.Y + size.Height / 2), new Size(size.Width / 2, size.Height / 2), amount - 1);
            }
        }

        private void SierpinskiTree(Graphics g, Point location, Size size, int amount) {
            if(amount > 0) {
                PointF[] points = new PointF[3];
                points[0] = new PointF(location.X - size.Width / 2, location.Y + size.Height / 2);
                points[1] = new PointF(location.X + size.Width / 2, location.Y + size.Height / 2);
                points[2] = new PointF(location.X, location.Y - size.Height / 2);
                g.DrawPolygon(new Pen(Color.Black), points);

                SierpinskiTree(g, new Point(location.X, location.Y - size.Height / 4), new Size(size.Width / 2, size.Height / 2), amount - 1);
                SierpinskiTree(g, new Point(location.X - size.Width / 4, location.Y + size.Height / 4), new Size(size.Width / 2, size.Height / 2), amount - 1);
                SierpinskiTree(g, new Point(location.X + size.Width / 4, location.Y + size.Height / 4), new Size(size.Width / 2, size.Height / 2), amount - 1);
            }
        }

        private void BoomVanPythagoras(Graphics g, Point location, Size size, int amount) {

        }
    }
}
