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

                int randomSquare = squares[rand.Next(0, squares.Count)];
                List<int> neighbours = maze.maze.GetAllNeighbours(randomSquare);

                List<int> validNeigbhours = new List<int>();

                foreach (int i in neighbours)
                    if (!squares.Contains(i))
                        validNeigbhours.Add(i);

                if (validNeigbhours.Count == 0) {
                    squares.Remove(randomSquare);
                    continue;
                }
                int newSquare = validNeigbhours[rand.Next(0, validNeigbhours.Count)];

                Edge edge = null;

                foreach (Edge e in edgeList) {
                    if (e.square1 == randomSquare && e.square2 == newSquare ||
                        e.square1 == newSquare && e.square2 == randomSquare) {
                        edge = e;
                        break;
                    }
                }

                if (edge == null)
                    continue;
                //maze.GetEdge(randomSquare, )

                //List<Edge> potential = GetPotentialEdges(squares);
                //Edge randomEdge = potential[rand.Next(0, potential.Count)];
                edgeList.Remove(edge);

                int root1 = maze.maze.Find(edge.square1);
                int root2 = maze.maze.Find(edge.square2);

                if (root1 == root2)
                    maze.mazeEdges.Add(edge);
                else {
                    maze.maze.Union(edge.square1, edge.square2);
                    if (!squares.Contains(edge.square1))
                        squares.Add(edge.square1);
                    if (!squares.Contains(edge.square2))
                        squares.Add(edge.square2);
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
