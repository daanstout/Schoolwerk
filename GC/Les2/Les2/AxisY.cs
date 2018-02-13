using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Les2 {
    public class AxisY {
        private int size;

        public List<Vector2> vb;

        public AxisY(int size) {
            this.size = size;

            vb = new List<Vector2> {
                new Vector2(150, 150),
                new Vector2(150, 150 - size)
            };
        }

        public void Draw(Graphics g, List<Vector2> vb) {
            Pen pen = new Pen(Color.Green, 2f);
            g.DrawLine(pen, vb[0].x, vb[0].y, vb[1].x, vb[1].y);
            Font font = new Font("Arial", 10);
            PointF p = new PointF(vb[1].x, vb[1].y);
            g.DrawString("y", font, Brushes.Green, p);
        }
    }
}
