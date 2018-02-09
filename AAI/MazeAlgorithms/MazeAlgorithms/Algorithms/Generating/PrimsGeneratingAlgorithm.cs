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

            List<int> squares = new List<int> {
                maze.start
            };

            while (!maze.maze.IsMaze() && edgeList.Count > 0) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                while (Global.isDrawing) { }

                iterations++;

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

                current = null;

                foreach (Edge e in edgeList) {
                    if (e.square1 == randomSquare && e.square2 == newSquare ||
                        e.square1 == newSquare && e.square2 == randomSquare) {
                        current = e;
                        break;
                    }
                }

                if (current == null)
                    continue;

                edgeList.Remove(current);

                int root1 = maze.maze.Find(current.square1);
                int root2 = maze.maze.Find(current.square2);

                if (root1 == root2)
                    maze.mazeEdges.Add(current);
                else {
                    maze.maze.Union(current.square1, current.square2);
                    if (!squares.Contains(current.square1))
                        squares.Add(current.square1);
                    if (!squares.Contains(current.square2))
                        squares.Add(current.square2);
                }
            }
            current = null;
            maze.mazeEdges.AddRange(edgeList);
        }
        #endregion
        #endregion
    }
}
