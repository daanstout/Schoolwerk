using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class RandomGeneratingAlgorithm : IGeneratingAlgorithm {
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
            edgeList = maze.maze.GetAllEdges();

            while (!maze.maze.IsMaze() && edgeList.Count > 0) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                while (Global.isDrawing) { }

                int randIndex = rand.Next(0, edgeList.Count);
                Edge edge = edgeList[randIndex];
                edgeList.Remove(edge);

                int root1 = maze.maze.Find(edge.square1);
                int root2 = maze.maze.Find(edge.square2);

                if (root1 == root2) {
                    maze.mazeEdges.Add(edge);
                } else
                    maze.maze.Union(edge.square1, edge.square2);
            }

            maze.mazeEdges.AddRange(edgeList);
        }
        #endregion
    }
}
