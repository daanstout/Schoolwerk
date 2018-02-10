using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class BreadthFirstSolvingAlgorithm : ASolvingAlgorithm {
        #region Public Functions
        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

            Datastructures.Queue<int> q = new Datastructures.Queue<int>();

            q.Enqueue(maze.start);

            while (!q.isEmpty) {
                current = q.Dequeue();

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
                            q.Enqueue(next);
                        }
                    }
                }
            }
            solving = false;
        }

        public override string GetAbout() {
            return "Breadh First: Breadth First is an algorithm that, from the start on out, explores the maze in rows. It adds all neighbours to a queue and goes over them in order, adding any new nodes it finds to the queue. This goes to every node up to the depth of the end node.";
        }
        #endregion
    }
}
