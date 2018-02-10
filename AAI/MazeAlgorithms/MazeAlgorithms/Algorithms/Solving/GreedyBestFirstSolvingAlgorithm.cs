using MazeAlgorithms.Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class GreedyBestFirstSolvingAlgorithm : ASolvingAlgorithm {
        #region Public Functions
        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

            PriorityQueue<int> q = new PriorityQueue<int>();

            q.Insert(maze.start, 1);

            while (!q.isEmpty) {
                current = q.GetHighestPriority();

                if (current < 0)
                    continue;

                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                iterations++;

                if(current == maze.end) {
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
                            q.Insert(next, Global.Heuristic(next, maze.end, maze.width));
                        }
                    }
                }
            }
            solving = false;
        }

        public override string GetAbout() {
            return "Greedy Best First: This algorithm chooses its nodes based on the optimal distance to the end node. This can make it a very efficient algorithm if the path roughly goes there like with a maze made with Prim's, but less efficient if made randomly like with Kruskal's.";
        }
        #endregion
    }
}
