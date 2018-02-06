﻿using System;
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
        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

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
                
                if (current - maze.width > 0) {     // Checks up
                    next = current - maze.width;
                    if (!maze.IsEdge(current, next)) {
                        if (Length(current) < Length(next) || solution[next] == -1) {
                            solution[next] = current;
                            q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                        }
                    }
                }
                if (maze.solved)
                    return;
                if (current / maze.width == (current + 1) / maze.width && current < maze.maze.size) {       // Checks right
                    next = current + 1;
                    if (!maze.IsEdge(current, next)) {
                        if (Length(current) < Length(next) || solution[next] == -1) {
                            solution[next] = current;
                            q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                        }
                    }
                }
                if (maze.solved)
                    return;
                if (current + maze.width < maze.maze.size) {        // Checks down
                    next = current + maze.width;
                    if (!maze.IsEdge(current, next)) {
                        if (Length(current) < Length(next) || solution[next] == -1) {
                            solution[next] = current;
                            q.Insert(next, Length(next) + Global.Heuristic(next, maze.end, maze.width));
                        }
                    }
                }
                if (maze.solved)
                    return;
                if (current / maze.width == (current - 1) / maze.width && current > 0) {        // Checks left
                    next = current - 1;
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
        #endregion
    }
}
