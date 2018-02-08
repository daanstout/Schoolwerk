using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms {
    public static class Global {
        #region Variables
        public static int squareSize = 10;
        public static volatile bool doStep = false;
        public static bool isDrawing = false;
        public static bool noDelay = false;
        public static bool showPosition = false;
        #endregion

        #region Public Functions
        public static int Heuristic(int a, int b, int width) {
            int rowa, rowb, columna, columnb;
            rowa = a / width;
            rowb = b / width;
            columna = a % width;
            columnb = b % width;
            return Math.Abs(rowa - rowb) + Math.Abs(columna - columnb);
        }
        #endregion
    }
}
