using System;
using System.Collections.Generic;
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
    }
}
