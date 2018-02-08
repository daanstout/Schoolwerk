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
        enum dirs {
            zero = -1,
            north,
            east,
            south,
            west
        }

        public List<int> path;

        public override void Draw(Graphics g, Maze maze) {
            //base.Draw(g, maze);
            if (path == null)
                return;
            DistanceDrawer drawer = new DistanceDrawer();
            for (int i = 0; i < path.Count - 1; i++) {
                //Console.WriteLine("i = {0}, path.Count = {1}", i, path.Count);
                drawer.Draw(g, path[i], path[i + 1], maze.width, 0, Color.Black);
                
            }
        }

        public override void SolveMaze(Maze maze) {
            base.SolveMaze(maze);

            path = new List<int>();
            int current = maze.start;
            path.Add(current);
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

            Console.WriteLine(dir.ToString());

            while (current != 2) {
                //Console.WriteLine(current);
                if (dir == dirs.north) {
                    //Console.WriteLine("1");
                    if (current / maze.width == (current + 1) / maze.width) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    } else if (current - maze.width >= 0) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    } else if (current / maze.width == (current - 1) / maze.width && current != 0) {
                        if (!maze.IsEdge(current, current - 1)) {
                            nextDir = dirs.west;
                            nextSquare = current - 1;
                        }
                    } else if (current + maze.width < maze.maze.size) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    }
                } else if (dir == dirs.east) {
                    // ALL MUST BE LIKE THIS!!!
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
                    } else if (current + maze.width < maze.maze.size) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    } else if (current / maze.width == (current + 1) / maze.width) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    } else if (current - maze.width >= 0) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    }
                }else if(dir == dirs.west) {
                    if (current - maze.width >= 0) {
                        if (!maze.IsEdge(current, current - maze.width)) {
                            nextDir = dirs.north;
                            nextSquare = current - maze.width;
                        }
                    } else if (current / maze.width == (current - 1) / maze.width && current != 0) {
                        if (!maze.IsEdge(current, current - 1)) {
                            nextDir = dirs.west;
                            nextSquare = current - 1;
                        }
                    } else if (current + maze.width < maze.maze.size) {
                        if (!maze.IsEdge(current, current + maze.width)) {
                            nextDir = dirs.south;
                            nextSquare = current + maze.width;
                        }
                    } else if (current / maze.width == (current + 1) / maze.width) {
                        if (!maze.IsEdge(current, current + 1)) {
                            nextDir = dirs.east;
                            nextSquare = current + 1;
                        }
                    }
                }
                Console.WriteLine("Next = {0} and {1}", nextSquare, nextDir.ToString());
                //current = nextSquare;
                current = 2;
                dir = nextDir;
                path.Add(current);
            }
        }
    }
}
