using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class HuntKillGeneratingAlgorithm : AGeneratingAlgorithm {
        int currentColumn = -1;

        List<int> squares = new List<int>();

        public override void Draw(Graphics g, Maze maze) {
            base.Draw(g, maze);

            for (int i = 0; i < maze.maze.size; i++)
                if (!squares.Contains(i))
                    g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle((i % maze.width) * Global.squareSize + 1, (i / maze.width) * Global.squareSize + 1, Global.squareSize - 1, Global.squareSize - 1));

            if (currentColumn > 0 && Global.showPosition)
                g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, (currentColumn - 1) * Global.squareSize, Global.squareSize * maze.width + 1, Global.squareSize + 1));
        }

        public override void GenerateMaze(Maze maze) {
            base.GenerateMaze(maze);

            int square = rand.Next(0, maze.maze.size);
            squares.Add(square);

            while (!maze.isMaze) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                iterations++;

                List<int> neighbours = maze.maze.GetAllNeighbours(square);
                List<int> validNeighbours = new List<int>();

                int root1 = maze.maze.Find(square);

                foreach (int neighbour in neighbours) {
                    int root2 = maze.maze.Find(neighbour);

                    if (root1 != root2)
                        validNeighbours.Add(neighbour);
                }

                if (validNeighbours.Count == 0) {
                    square = -1;
                    for (currentColumn = 0; currentColumn < maze.height; currentColumn++) {
                        if (!Global.noDelay)
                            while (!Global.doStep) { }
                        Global.doStep = false;
                        if (square == -1) {
                            iterations++;
                            for (int i = maze.width * currentColumn; i < (maze.width * (currentColumn + 1)); i++) {
                                if (square == -1) {
                                    int root2 = maze.maze.Find(i);
                                    if (root1 != root2) {
                                        neighbours = maze.maze.GetAllNeighbours(i);

                                        foreach (int neighbour in neighbours) {
                                            int root3 = maze.maze.Find(neighbour);
                                            if (root1 == root3) {
                                                square = i;
                                                squares.Add(square);
                                                current = GetEdge(square, neighbour);
                                                edgeList.Remove(current);

                                                maze.maze.Union(square, neighbour);
                                                break;
                                            }
                                        }
                                    }
                                } else
                                    break;
                            }
                        } else
                            break;
                    }
                } else {
                    currentColumn = -1;

                    int next = validNeighbours[rand.Next(0, validNeighbours.Count)];

                    current = GetEdge(square, next);
                    edgeList.Remove(current);
                    squares.Add(next);

                    maze.maze.Union(square, next);

                    square = next;
                }
            }

            current = null;
            currentColumn = -1;

            maze.mazeEdges.AddRange(edgeList);
        }

        public override string GetAbout() {
            return "";
        }
    }
}
