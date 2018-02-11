using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class DeadEndSolvingAlgorithm : ASolvingAlgorithm {
        List<int> deadEnds = new List<int>();

        public override void Draw(Graphics g, Maze maze) {
            int row, column;
            for (int i = 0; i < deadEnds.Count; i++) {
                row = deadEnds[i] / maze.width;
                column = deadEnds[i] % maze.width;
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(column * Global.squareSize, row * Global.squareSize, Global.squareSize + 1, Global.squareSize + 1));
            }

            if (Global.showPosition)
                DrawCurrentPosition(g, maze);
        }

        public override void SolveMaze(Maze maze) {
            Datastructures.Queue<int> q = new Datastructures.Queue<int>();

            for (current = 0; current < maze.maze.size; current++) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                if (current == maze.start || current == maze.end)
                    continue;

                iterations++;

                List<int> neighbours = maze.maze.GetAllNeighbours(current);
                int count = 0;

                foreach (int neighbour in neighbours)
                    if (!maze.IsEdge(current, neighbour) && !deadEnds.Contains(current))
                        count++;

                if (count == 1) {
                    deadEnds.Add(current);
                    q.Enqueue(current);
                }
            }

            while (!q.isEmpty) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                current = q.Dequeue();

                if (current == maze.start || current == maze.end)
                    continue;

                iterations++;

                List<int> neighbours = maze.maze.GetAllNeighbours(current);
                int next = -1;

                foreach (int neighbour in neighbours) {
                    if (neighbour == maze.end)
                        continue;
                    if (!maze.IsEdge(current, neighbour) && !deadEnds.Contains(neighbour)) {
                        List<int> neighbourNeighbours = maze.maze.GetAllNeighbours(neighbour);

                        int count = 0;

                        foreach (int i in neighbourNeighbours)
                            if (!maze.IsEdge(neighbour, i) && !deadEnds.Contains(i))
                                count++;

                        if (count == 1)
                            if (next == -1)
                                next = neighbour;
                            else
                                continue;
                    }
                }

                if (next == -1)
                    continue;

                deadEnds.Add(next);
                q.Enqueue(next);
            }
        }

        public override string GetAbout() {
            return "Dead End Filler: The Dead End Filler algorithm goes over the maze and looks for any dead ends. These are then filled in and pushed on a queue. It then goes over the found dead ends and continues filling them in layer by layer until only the solution(s) remain(s).";
        }

        public override void reset() {
            base.reset();
            deadEnds = new List<int>();
        }
    }
}
