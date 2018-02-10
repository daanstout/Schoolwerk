using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Drawing;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class RightHandSolvingAlgorithm : ASolvingAlgorithm {
        #region Enumerations
        enum dirs {
            zero = -1,
            north,
            east,
            south,
            west
        }
        #endregion

        #region Variables
        private List<int> path;
        private List<dirs> dirList;
        #endregion

        #region Public Functions
        public override void Draw(Graphics g, Maze maze) {
            if (path == null || dirList == null)
                return;

            if (path.Count + 1 != dirList.Count) {
                if (path.Count != dirList.Count) {
                    Console.WriteLine(path.Count + " - - " + dirList.Count);
                    return;
                }
            }

            int row, column;
            Pen pen = new Pen(Color.Green, Global.squareSize / 5);
            for (int i = 1; i < path.Count + 1; i++) {
                if (i >= path.Count)
                    if (!maze.solved)
                        continue;

                int square = path[i - 1];
                dirs dir = dirList[i];

                row = square / maze.width;
                column = square % maze.width;

                /*  {column, row}           {column + 1, row}
                 *      _____________________________
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |                           |
                 *      |___________________________|
                 *  {column, row + 1}       {column + 1, row + 1}
                 *  
                 *  All should be multiplied by Global.squareSize
                 */

                if (dir == dirs.north) {
                    if (dirList[i - 1] == dirs.north) {
                        g.DrawLine(pen, new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize), new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize));
                    } else if (dirList[i - 1] == dirs.east) {
                        //Console.WriteLine("Square {0}, at row={1},column={2}, goes {3} from {4}", square, row, column, dir, dirList[i - 1]);
                        Point[] p = new Point[3] {new Point(column * Global.squareSize, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.south) {
                        Point[] p = new Point[4] {new Point(column * Global.squareSize + 2, row * Global.squareSize),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.west) {
                        Point[] p = new Point[3] { new Point((column + 1) * Global.squareSize, row * Global.squareSize + 2),
                            new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize + 2),
                            new Point((column + 1)* Global.squareSize - 2, row * Global.squareSize)};
                        g.DrawLines(pen, p);
                    }
                } else if (dir == dirs.east) {
                    if (dirList[i - 1] == dirs.north) {
                        Point[] p = new Point[3] {new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize),
                            new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize, (row + 1) * Global.squareSize - 2)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.east) {
                        g.DrawLine(pen, new Point(column * Global.squareSize, (row + 1) * Global.squareSize - 2), new Point((column + 1) * Global.squareSize, (row + 1) * Global.squareSize - 2));
                    } else if (dirList[i - 1] == dirs.south) {
                        Point[] p = new Point[3] {new Point(column * Global.squareSize + 2, row * Global.squareSize),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize, (row + 1) * Global.squareSize - 2)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.west) {
                        Point[] p = new Point[4] {new Point((column + 1) * Global.squareSize, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize + 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize, (row + 1) * Global.squareSize - 2)};
                        g.DrawLines(pen, p);
                    }
                } else if (dir == dirs.south) {
                    if (dirList[i - 1] == dirs.north) {
                        Point[] p = new Point[4] {new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize),
                            new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize + 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.east) {
                        Point[] p = new Point[3] { new Point(column * Global.squareSize, (row + 1) * Global.squareSize - 2),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize - 2),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize) };
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.south) {
                        g.DrawLine(pen, new Point(column * Global.squareSize + 2, row * Global.squareSize), new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize));
                    } else if (dirList[i - 1] == dirs.west) {
                        Point[] p = new Point[3] {new Point((column + 1) * Global.squareSize, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize + 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize + 2, (row + 1) * Global.squareSize)};
                        g.DrawLines(pen, p);
                    }
                } else if (dir == dirs.west) {
                    if (dirList[i - 1] == dirs.north) {
                        Point[] p = new Point[3] {new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize),
                            new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize, row * Global.squareSize + 2)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.east) {
                        Point[] p = new Point[4] {new Point(column * Global.squareSize, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize - 2, (row + 1) * Global.squareSize - 2),
                            new Point((column + 1) * Global.squareSize - 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize, row * Global.squareSize + 2)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.south) {
                        Point[] p = new Point[3] {new Point(column * Global.squareSize + 2, row * Global.squareSize),
                            new Point(column * Global.squareSize + 2, row * Global.squareSize + 2),
                            new Point(column * Global.squareSize, row * Global.squareSize + 2)};
                        g.DrawLines(pen, p);
                    } else if (dirList[i - 1] == dirs.west) {
                        g.DrawLine(pen, new Point((column + 1) * Global.squareSize, row * Global.squareSize + 2), new Point(column * Global.squareSize, row * Global.squareSize + 2));
                    }
                }
            }
            if (!maze.solved) {
                row = current / maze.width;
                column = current % maze.width;
                g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(column * Global.squareSize + 2, row * Global.squareSize + 2, Global.squareSize - 4, Global.squareSize - 4));
            }
        }

        public override void SolveMaze(Maze maze) {
            solving = true;

            path = new List<int>();
            dirList = new List<dirs>();
            current = maze.start;
            path.Add(current);
            dirList.Add(dirs.east);
            int nextSquare = -1;
            dirs dir = dirs.zero;
            dirs nextDir = dirs.zero;


            if (current / maze.width == (current - 1) / maze.width && dir == dirs.zero && current != 0) {
                if (!maze.IsEdge(current, current - 1))
                    dir = dirs.west;
            }
            if (current + maze.width < maze.maze.size && dir == dirs.zero) {
                if (!maze.IsEdge(current, current + maze.width))
                    dir = dirs.south;
            }
            if (current / maze.width == (current + 1) / maze.width && dir == dirs.zero) {
                if (!maze.IsEdge(current, current + 1))
                    dir = dirs.east;
            }
            if (current - maze.width >= 0 && dir == dirs.zero) {
                if (!maze.IsEdge(current, current - maze.width))
                    dir = dirs.north;
            }

            while (!(current == maze.end && (dir == dirs.east || dir == dirs.south))) {
                if (!Global.noDelay)
                    while (!Global.doStep) { }
                Global.doStep = false;

                iterations++;

                if (dir == dirs.north) {
                    if (current / maze.width == (current + 1) / maze.width) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    }
                    if (current - maze.width >= 0 && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    }
                    if (current / maze.width == (current - 1) / maze.width && current != 0 && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current - 1)) {
                            nextDir = dirs.west;
                            nextSquare = current - 1;
                        }
                    }
                    if (current + maze.width < maze.maze.size && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    }
                } else if (dir == dirs.east) {
                    if (current + maze.width < maze.maze.size) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    }
                    if (current / maze.width == (current + 1) / maze.width && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    }
                    if (current - maze.width >= 0 && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    }
                    if (current / maze.width == (current - 1) / maze.width && current != 0 && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current - 1)) {
                            nextDir = dirs.west;
                            nextSquare = current - 1;
                        }
                    }
                } else if (dir == dirs.south) {
                    if (current / maze.width == (current - 1) / maze.width && current != 0) {
                        if (!maze.IsEdge(current, current - 1)) {
                            nextDir = dirs.west;
                            nextSquare = current - 1;
                        }
                    }
                    if (current + maze.width < maze.maze.size && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    }
                    if (current / maze.width == (current + 1) / maze.width && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    }
                    if (current - maze.width >= 0 && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    }
                } else if (dir == dirs.west) {
                    if (current - maze.width >= 0) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    }
                    if (current / maze.width == (current - 1) / maze.width && current != 0 && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current - 1)) {
                            nextDir = dirs.west;
                            nextSquare = current - 1;
                        }
                    }
                    if (current + maze.width < maze.maze.size && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    }
                    if (current / maze.width == (current + 1) / maze.width && nextDir == dirs.zero) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    }
                }
                //Console.WriteLine("Next = {0} and {1}", nextSquare, nextDir.ToString());
                current = nextSquare;
                //current = 2;
                dir = nextDir;
                nextDir = dirs.zero;
                path.Add(current);
                dirList.Add(dir);
                //count++;
            }
            dirList.Add(dirs.east);
            maze.solved = true;
            solving = false;
        }

        public override string GetAbout() {
            return "Right Hand: This algorithm follows the rule of putting your hand on the right side of the maze and keep it there. This will 100% of the time find the end if the maze is a true maze with no loops.";
        }
        #endregion
    }
}
