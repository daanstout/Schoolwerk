using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Drawing {
    public class LineDrawer : IPathDrawer {
        public void Draw(Graphics g, int a, int b, int width, int length, Color color) {
            int rowa, rowb, columna, columnb;
            rowa = a / width;
            rowb = b / width;
            columna = a % width;
            columnb = b % width;
            g.DrawLine(new Pen(color, 0.2f * Global.squareSize), new Point(columna * Global.squareSize + (Global.squareSize / 2), rowa * Global.squareSize + (Global.squareSize / 2)), new Point(columnb * Global.squareSize + (Global.squareSize / 2), rowb * Global.squareSize + (Global.squareSize / 2)));
        }
    }
}
