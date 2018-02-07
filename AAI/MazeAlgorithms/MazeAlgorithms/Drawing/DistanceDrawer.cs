using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Drawing {
    public class DistanceDrawer : IPathDrawer {
        public void Draw(Graphics g, int a, int b, int width, int length, Color color) {
            int rowa, rowb, columna, columnb;
            rowa = a / width;
            rowb = b / width;
            columna = a % width;
            columnb = b % width;
            g.DrawString(length.ToString(), new Font("Arial", 0.5f * Global.squareSize),new SolidBrush(color), new PointF(columna * Global.squareSize/* + (Global.squareSize / 2)*/, rowa * Global.squareSize/* + (Global.squareSize / 2)*/)/*, new Point(columnb * Global.squareSize + (Global.squareSize / 2), rowb * Global.squareSize + (Global.squareSize / 2))*/);
        }
    }
}
