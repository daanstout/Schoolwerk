using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class AStarSolvingAlgorithm : ASolvingAlgorithm {
        #region Public Functions
        public override void Draw(Graphics g, Maze maze) {
            if (!maze.solved || solving)
                return;

            for (int i = 0; i < solution.Length; i++) {
                if (solution[i] < 0)
                    continue;

                DrawLine(g, i, solution[i], maze.width);
            }
        }

        public override void SolveMaze(Maze maze) {
            solving = true;

            solution = new int[maze.maze.size];
            initSolutions();

            solution[maze.start] = -1;

            PriorityQueue<int> q = new PriorityQueue<int>();

            q.Insert(maze.start, 1);

            while (!q.isEmpty) {
                int current = q.GetHighestPriority();

                if (current < 0)
                    continue;

                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                if (current == maze.end) {
                    maze.solved = true;
                    solving = false;
                    return;
                }

                int next;

                if (current + maze.width > maze.maze.size) {
                    next = current + maze.width;
                    if (Length(current) < Length(next) && Length(next) != -1) {
                        solution[next] = current;
                        q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                    }
                }
                if (current / maze.width == (current - 1) / maze.width && current > 0) {
                    next = current - 1;
                    if (Length(current) < Length(next) && Length(next) != -1) {
                        solution[next] = current;
                        q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                    }
                }
                if (current - maze.width > 0) {
                    next = current - maze.width;
                    if (Length(current) < Length(next) && Length(next) != -1) {
                        solution[next] = current;
                        q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                    }
                }
                if (current / maze.width == (current + 1) / maze.width && current < maze.maze.size) {
                    next = current + 1;
                    if (Length(current) < Length(next) && Length(next) != -1) {
                        solution[next] = current;
                        q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                    }
                }
            }
            solving = false;
        }
        #endregion
    }
}
