using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class DepthFirstSolvingAlgorithm : ASolvingAlgorithm {
        #region Functions
        #region Public Functions
        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

            SolveMaze(maze, maze.start);
        }

        public override string GetAbout() {
            return "Depth First: Depth First algorithm goes over the nodes in a chosen way. It prioritises 1 direction over the other and doesn't go to the next direction until every node in the current direction is explored.";
        }
        #endregion

        #region Private Functions
        private void SolveMaze(Maze maze, int current) {
            if (!Global.noDelay)
                while (!Global.doStep) { }
            Global.doStep = false;

            iterations++;

            if (current == maze.end) {
                maze.solved = true;
                solving = false;
                return;
            }

            List<int> neighbours = maze.maze.GetAllNeighbours(current);
            foreach (int next in neighbours) {
                if (maze.solved)
                    return;
                if (!maze.IsEdge(current, next)) {
                    if (Length(current) < Length(next) || solution[next] == -1) {
                        solution[next] = current;
                        this.current = next;
                        SolveMaze(maze, next);
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
