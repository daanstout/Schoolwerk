using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class RandomGeneratingAlgorithm : AGeneratingAlgorithm {
        #region Public Functions
        public override void GenerateMaze(Maze maze) {
            base.GenerateMaze(maze);

            while (!maze.maze.IsMaze() && edgeList.Count > 0) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                while (Global.isDrawing) { }

                current = edgeList[rand.Next(0, edgeList.Count)];
                edgeList.Remove(current);

                int root1 = maze.maze.Find(current.square1);
                int root2 = maze.maze.Find(current.square2);

                if (root1 == root2) {
                    maze.mazeEdges.Add(current);
                } else
                    maze.maze.Union(current.square1, current.square2);
            }
            current = null;
            maze.mazeEdges.AddRange(edgeList);
        }
        #endregion
    }
}
