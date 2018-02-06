using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class PrimsGeneratingAlgorithm : AGeneratingAlgorithm {
        #region Functions
        #region Public Functions
        public override void GenerateMaze(Maze maze) {
            base.GenerateMaze(maze);

            List<int> squares = new List<int>();
            squares.Add(maze.start);

            while (!maze.maze.IsMaze() && edgeList.Count > 0) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                while (Global.isDrawing) { }

                List<Edge> potential = GetPotentialEdges(squares);
                Edge randomEdge = potential[rand.Next(0, potential.Count)];
                edgeList.Remove(randomEdge);

                int root1 = maze.maze.Find(randomEdge.square1);
                int root2 = maze.maze.Find(randomEdge.square2);

                if (root1 == root2)
                    maze.mazeEdges.Add(randomEdge);
                else {
                    maze.maze.Union(randomEdge.square1, randomEdge.square2);
                    if (!squares.Contains(randomEdge.square1))
                        squares.Add(randomEdge.square1);
                    if (!squares.Contains(randomEdge.square2))
                        squares.Add(randomEdge.square2);
                }
            }

            maze.mazeEdges.AddRange(edgeList);
        }
        #endregion

        #region Private Functions
        private List<Edge> GetPotentialEdges(List<int> squares) {
            List<Edge> list = new List<Edge>();
            foreach (Edge e in edgeList)
                foreach (int s in squares)
                    if (e.square1 == s || e.square2 == s)
                        list.Add(e);
            return list;
        }
        #endregion
        #endregion
    }
}
