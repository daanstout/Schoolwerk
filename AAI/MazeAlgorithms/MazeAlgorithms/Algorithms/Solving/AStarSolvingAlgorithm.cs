using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms.Solving {
    public class AStarSolvingAlgorithm : ASolvingAlgorithm {
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
                            q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                        }
                    }
                }
            }
            solving = false;
        }

        public override string GetAbout() => "A*: A* is a solving algorithm that combines Dijksta's (or Breadth First if every node is the same) and Greedy Best First. It takes the node that looks the best as its next node. It decides a node's priority based on both it's estimated optimal distance to the end and the current distance traveled.";
        #endregion
    }
}
