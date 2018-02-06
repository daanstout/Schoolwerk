using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class RecursiveGeneratingAlgorithm : AGeneratingAlgorithm {
        public override void Draw(Graphics g, Maze maze) { }

        public override void GenerateMaze(Maze maze) {
            //base.GenerateMaze(maze);

            //GenerateMaze(maze, 0, maze.width, 0, maze.height, rand.Next() % 2 == 0);
            GenerateMaze(maze, 0, maze.width, 0, maze.height, true);
        }

        private void GenerateMaze(Maze maze, int x, int width, int y, int height, bool horizontal) {
            if (!Global.noDelay)
                while (!Global.doStep) { }
            Global.doStep = false;

            if (horizontal) { // Horizontal wall
                if (width == 1 || height == 1)
                    return;
                else {
                    int half = y + height / 2;
                    Console.WriteLine("{0} = {1} + {2} / 2", half, y, height);
                    //Console.WriteLine("i = {0}; i < {1} + {0}; i++", x, width);
                    for (int i = x; i < width + x; i++)
                        maze.mazeEdges.Add(new Edge((half - 1) * maze.width + i, half * maze.width + i));
                    int gap = rand.Next(1, width) + x;
                    //Console.WriteLine(gap);
                    Edge e = maze.GetEdge((half - 1) * maze.width + gap, half * maze.width + gap);
                    if (e != null)
                        maze.mazeEdges.Remove(e);

                    //Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}\n{0}, {1}, {2}, {4}, {6}, {5}", maze, x, width, y, half, !horizontal, height - half);
                    GenerateMaze(maze, x, width, y, half, !horizontal);
                    GenerateMaze(maze, x, width, half, height - half, !horizontal);
                }
            } else { // Vertical wall
                if (height == 1 || width == 1)
                    return;
                else {
                    int half = x + width / 2;
                    for (int i = y; i < height + y; i++)
                        maze.mazeEdges.Add(new Edge((half - 1) + maze.width * i, half + maze.width * i));
                    int gap = rand.Next(1, height) + y;
                    Edge e = maze.GetEdge((half - 1) + maze.width * gap, half + maze.width * gap);
                    if (e != null)
                        maze.mazeEdges.Remove(e);

                    GenerateMaze(maze, x, half, y, height, !horizontal);
                    GenerateMaze(maze, half, width - half, y, height, !horizontal);
                }
            }
        }

        private void CreateEdge(Maze maze, int a, int b) {
            maze.mazeEdges.Add(new Edge(a, b));
        }
    }
}
