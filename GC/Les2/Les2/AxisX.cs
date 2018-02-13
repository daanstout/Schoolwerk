using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Les2 {
    public class AxisX {
        private int size;

        public List<Vector2> vb;

        public AxisX(int size) {
            this.size = size;

            vb = new List<Vector2> {
                new Vector2(150, 150),
                new Vector2(150 + size, 150)
            };
        }

        public void Draw(Graphics g, List<Vector2> vb) {
            Pen pen = new Pen(Color.Red, 2f);
            g.DrawLine(pen, vb[0].x, vb[0].y, vb[1].x, vb[1].y);
            Font font = new Font("Arial", 10);
            PointF p = new PointF(vb[1].x, vb[1].y);
            g.DrawString("x", font, Brushes.Red, p);
        }
    }
}
