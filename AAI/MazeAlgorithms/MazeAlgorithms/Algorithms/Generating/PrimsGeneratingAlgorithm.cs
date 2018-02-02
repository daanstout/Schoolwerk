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
        public void Draw(Graphics g, UpTree tree) {
            if (edgeList == null && tree == null)
                return;
            if (edgeList == null)
                edgeList = tree.GetAllEdges();

            foreach (Edge edge in edgeList) {
                edge.DrawEdgeLine(g, tree.width, Color.Gray);
            }
        }

        public void GenerateMaze(Maze maze) {


        }
        #endregion
    }
}
