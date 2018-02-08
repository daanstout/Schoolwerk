using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public abstract class AGeneratingAlgorithm : IGeneratingAlgorithm {
        #region Variables
        protected List<Edge> edgeList;
        protected Random rand = new Random();
        #endregion

        #region Public Functions
        public virtual void Draw(Graphics g, Maze maze) {
            if (edgeList == null && maze.maze == null)
                return;
            if (edgeList == null)
                edgeList = maze.maze.GetAllEdges();

            for (int i = 0; i < edgeList.Count; i++)
                edgeList[i].DrawEdgeLine(g, maze.width, Color.LightGray);
        }

        public virtual void GenerateMaze(Maze maze) {
            edgeList = maze.maze.GetAllEdges();
        }
        #endregion
    }
}
