using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.MazeMain {
    public class Edge {
        #region Variables
        public int square1;
        public int square2;
        #endregion

        #region Constructors
        public Edge(int square1, int square2) {
            this.square1 = square1;
            this.square2 = square2;
        }
        #endregion

        #region Public Functions
        public void DrawEdgeLine(Graphics g, int width, Color color) {
            int row = square2 / width; // The row of Square2
            int column = square2 % width; // The column of Square2

            if (square1 + 1 == square2) {
                // Square2 is to the right of Square1
                g.DrawLine(new Pen(color), new Point(column * Global.squareSize, row * Global.squareSize), new Point(column * Global.squareSize, (row + 1) * Global.squareSize));
            } else {
                // Square2 is below Square1
                g.DrawLine(new Pen(color), new Point(column * Global.squareSize, row * Global.squareSize), new Point((column + 1) * Global.squareSize, row * Global.squareSize));
            }
        }

        public override string ToString() {
            return String.Format("[{0}; {1}]", square1, square2);
        }
        #endregion
    }
}
