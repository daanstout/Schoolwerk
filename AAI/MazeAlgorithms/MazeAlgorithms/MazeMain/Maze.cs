using MazeAlgorithms.Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.MazeMain {
    public class Maze {
        #region Variables
        private UpTree maze;
        #endregion

        #region Constructors
        public Maze() {
            maze = new UpTree(9);
        }
        #endregion
    }
}
