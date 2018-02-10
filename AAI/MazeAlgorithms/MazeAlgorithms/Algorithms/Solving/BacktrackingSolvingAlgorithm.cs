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

        public override string GetAbout() {
            return "Backtracking: Backtracking explores the maze and undos any moves it does that ends in a dead end. In the end, you will only see 1 line from the start to the end. It is visually a simpler Depth First algorithm.";
        }
        #endregion

        #region Private Functions
        private void SolveMaze(Maze maze, int current) {
            if (!Global.noDelay)
                while (!Global.doStep) { }
            Global.doStep = false;

            if (maze.solved)
                return;

            iterations++;

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
                        this.current = next;
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
