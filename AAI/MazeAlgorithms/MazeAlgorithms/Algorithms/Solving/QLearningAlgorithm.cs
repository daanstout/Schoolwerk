using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms.Solving {
    public class QLearningAlgorithm : ASolvingAlgorithm {
        private readonly int[] moveValues = { -1, -10 };

        private int[] scores;

        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

            scores = new int[maze.size];

            for (int i = 0; i < scores.Length; i++)
                scores[i] = 0;

            current = maze.start;

            bool moving = true;

            int previous = -1;

            while (true) {
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

                maze.ValidateNeighbours(ref neighbours, current);

                if (neighbours.Count <= 0)
                    return;

                if (neighbours.Count == 1 && previous >= 0) {
                    while (true) {
                        if (!Global.noDelay)
                            while (!Global.doStep) { }
                        Global.doStep = false;

                        iterations++;

                        neighbours = maze.maze.GetAllNeighbours(current);

                        maze.ValidateNeighbours(ref neighbours, current);

                        if (neighbours.Count >= 3) {
                            break;
                        }

                        scores[current] += moveValues[1];

                        if (neighbours.Count == 1) {
                            previous = current;
                            current = neighbours[0];
                        } else if (neighbours[0] == previous) {
                            previous = current;
                            current = neighbours[1];
                        } else {
                            previous = current;
                            current = neighbours[0];
                        }
                    }

                    continue;
                }

                int lowest = int.MaxValue;

                for (int i = 0; i < neighbours.Count; i++)
                    if (neighbours[i] != previous)
                        if (lowest == int.MaxValue)
                            lowest = neighbours[i];
                        else if (scores[neighbours[i]] >= scores[lowest])
                            lowest = neighbours[i];

                if (lowest == int.MaxValue)
                    continue;

                previous = current;
                current = lowest;

                scores[lowest] += moveValues[0];
            }
        }

        public override void Draw(Graphics g, Maze maze) {
            if (scores == null) {
                base.Draw(g, maze);
                return;
            }

            for (int i = 0; i < maze.size; i++) {
                int row = i / maze.width;
                int column = i % maze.width;

                PointF point = new PointF(column * Global.squareSize, row * Global.squareSize);

                g.DrawString(scores[i].ToString(), new Font("Arial", 9), new SolidBrush(Color.Black), point);
            }
        }

        public override string GetAbout() => "An algorithm wherein an AI learns to walk through the maze by giving each spot a score";
    }
}
