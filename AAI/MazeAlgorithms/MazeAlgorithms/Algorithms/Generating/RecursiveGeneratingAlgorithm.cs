using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class RecursiveGeneratingAlgorithm : AGeneratingAlgorithm {
        new Rectangle current;

        #region Functions
        #region Public Functions
        public override void Draw(Graphics g, Maze maze) {
            if (Global.showPosition && current != null)
                g.FillRectangle(new SolidBrush(Color.Blue), current);
        }

        public override void GenerateMaze(Maze maze) {
            iterations = 0;

            GenerateMaze(maze, 0, maze.width, 0, maze.height, rand.Next() % 2 == 0);
        }

        public override string GetAbout() {
            return "Recursive Algorithm: The Recursive Algorithm creates a maze recursively. It places a wall in it's area, splitting it in 2. Then it adds a hole in it connecting them and calling the function recursively for each new area. This creates mazes that have a clear bias for repeated patterns.";
        }
        #endregion

        #region Private Functions
        private void GenerateMaze(Maze maze, int x, int width, int y, int height, bool horizontal) {
            if (!Global.noDelay)
                while (!Global.doStep) { }
            Global.doStep = false;

            iterations++;

            current = new Rectangle(x * Global.squareSize, y * Global.squareSize, width * Global.squareSize, height * Global.squareSize);

            if (horizontal) { // Horizontal wall
                if (width == 1 || height == 1)
                    return;
                else {
                    int half = height / 2;
                    for (int i = x; i < width + x; i++)
                        maze.mazeEdges.Add(new Edge((half - 1 + y) * maze.width + i, (half + y) * maze.width + i));

                    int gap = rand.Next(1, width + 1) + x - 1;
                    Edge e = maze.GetEdge((half - 1 + y) * maze.width + gap, (half + y) * maze.width + gap);
                    if (e != null)
                        maze.mazeEdges.Remove(e);

                    GenerateMaze(maze, x, width, y, half, !horizontal);
                    GenerateMaze(maze, x, width, half + y, height - half, !horizontal);
                }
            } else { // Vertical wall
                if (height == 1 || width == 1)
                    return;
                else {
                    int half = width / 2;
                    for (int i = y; i < height + y; i++)
                        maze.mazeEdges.Add(new Edge((half - 1 + x) + maze.width * i, (half + x) + maze.width * i));

                    int gap = rand.Next(1, height + 1) + y - 1;
                    Edge e = maze.GetEdge((half - 1 + x) + maze.width * gap, (half + x) + maze.width * gap);
                    if (e != null)
                        maze.mazeEdges.Remove(e);

                    GenerateMaze(maze, x, half, y, height, !horizontal);
                    GenerateMaze(maze, half + x, width - half, y, height, !horizontal);
                }
            }
        }
        #endregion
        #endregion
    }
}
