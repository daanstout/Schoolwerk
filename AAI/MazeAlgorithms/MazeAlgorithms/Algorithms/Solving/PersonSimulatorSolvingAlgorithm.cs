using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public class PersonSimulatorSolvingAlgorithm : ASolvingAlgorithm {
        #region Public Functions
        public override void Draw(Graphics g, Maze maze) {
            if (current < 0 || current >= maze.maze.size)
                return;

            DrawCurrentPosition(g, maze);
        }

        public override void SolveMaze(Maze maze) {
            solving = true;

            int previous = -1;

            while (current != maze.end) {
                while (!Global.doStep) { }
                Global.doStep = false;

                iterations++;

                List<int> neighbours = maze.maze.GetAllNeighbours(current);

                List<int> validNeighbours = new List<int>();

                foreach (int i in neighbours)
                    if (!maze.IsEdge(current, i))
                        validNeighbours.Add(i);

                switch (validNeighbours.Count) {
                    case 0:
                        Console.WriteLine("There are no neighbours!!!");
                        break;
                    case 1:
                        previous = current;
                        current = validNeighbours[0];
                        break;
                    case 2:
                        if (validNeighbours[0] == previous) {
                            previous = current;
                            current = validNeighbours[1];
                        } else {
                            previous = current;
                            current = validNeighbours[0];
                        }
                        break;
                    case 3:
                    case 4:
                        int dir = validNeighbours[rand.Next(0, validNeighbours.Count)];
                        while (dir == previous)
                            dir = validNeighbours[rand.Next(0, validNeighbours.Count)];

                        previous = current;
                        current = dir;
                        break;
                }
            }
            solving = false;
        }

        public override string GetAbout() {
            return "Person Simulator: This algorithm randomly traverses the maze. It choses a random path and continues down it until it finds a new intersection where it will chose a random new direction, or, until it encounters a dead end and simply turns around. It's possible that this algorithm never finds the end!";
        }
        #endregion
    }
}
