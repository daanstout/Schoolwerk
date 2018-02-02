using MazeAlgorithms.Datastructures;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        #region Public functions
        public void Draw(Graphics g) {
            if (!maze.IsMaze())
                return;
        }
        #endregion
    }
}
