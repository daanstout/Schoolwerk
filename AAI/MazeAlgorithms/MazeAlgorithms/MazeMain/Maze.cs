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
        #region Private Variables
        private UpTree maze;
        #endregion

        #region Public Variables
        public int width, height;
        #endregion
        #endregion

        #region Constructors
        public Maze() {
            maze = new UpTree(3, 3);
            width = 3;
            height = 3;
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
