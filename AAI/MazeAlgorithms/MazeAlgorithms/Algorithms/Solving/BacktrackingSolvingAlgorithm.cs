using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class BacktrackingSolvingAlgorithm : ASolvingAlgorithm {
        #region Functions
        #region Public Functions
        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

            SolveMaze(maze, maze.start);

            solving = false;
        }
        #endregion

        #region Private Functions
        private void SolveMaze(Maze maze, int current) {
            if (!Global.noDelay)
                while (!Global.doStep) { }
            Global.doStep = false;

            if (maze.solved)
                return;

            if(current == maze.end) {
                maze.solved = true;
                return;
            }

            List<int> neighbours = maze.maze.GetAllNeighbours(current);
            foreach (int next in neighbours) {
                if (maze.solved)
                    return;
                if (!maze.IsEdge(current, next)) {
                    if (Length(current) < Length(next) || solution[next] == -1) {
                        solution[next] = current;
                        SolveMaze(maze, next);
                        if (!maze.solved)
                            solution[next] = -1;
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
