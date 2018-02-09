using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public class RecursiveBacktrackerGeneratingAlgorithm : AGeneratingAlgorithm {
        List<int> squares;

        public override void GenerateMaze(Maze maze) {
            base.GenerateMaze(maze);

            squares = new List<int> {
                maze.start
            };

            GenerateMaze(maze, maze.start);

            maze.mazeEdges.AddRange(edgeList);

            current = null;


        }

        private void GenerateMaze(Maze maze, int current) {
            if (!Global.noDelay)
                while (!Global.doStep) { }
            Global.doStep = false;

            iterations++;

            List<int> neighbours = maze.maze.GetAllNeighbours(current);
            while (neighbours.Count > 0) {
                int next = neighbours[rand.Next(0, neighbours.Count)];

                neighbours.Remove(next);

                if (squares.Contains(next))
                    continue;

                Edge nextEdge = null;

                foreach (Edge e in edgeList)
                    if (e.square1 == current && e.square2 == next || e.square1 == next && e.square2 == current)
                        nextEdge = e;

                int root1 = maze.maze.Find(nextEdge.square1);
                int root2 = maze.maze.Find(nextEdge.square2);

                if (root1 == root2) {
                    maze.mazeEdges.Add(nextEdge);
                    return;
                }

                this.current = nextEdge;

                maze.maze.Union(nextEdge.square1, nextEdge.square2);

                edgeList.Remove(nextEdge);

                squares.Add(next);

                GenerateMaze(maze, next);
            }
        }
    }
}
