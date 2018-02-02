using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class PrimsGeneratingAlgorithm : IGeneratingAlgorithm {
        #region Variables
        List<Edge> edgeList;
        Random rand = new Random();
        #endregion

        #region Public Functions
        public void Draw(Graphics g, Maze maze) {
            if (edgeList == null && maze.maze == null)
                return;
            if (edgeList == null)
                edgeList = maze.maze.GetAllEdges();

            foreach (Edge edge in edgeList) {
                edge.DrawEdgeLine(g, maze.width, Color.Gray);
            }
        }

        public void GenerateMaze(Maze maze) {


        }
        #endregion
    }
}
