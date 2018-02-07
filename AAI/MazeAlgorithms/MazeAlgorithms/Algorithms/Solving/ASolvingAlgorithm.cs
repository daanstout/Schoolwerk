using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.Datastructures;
using MazeAlgorithms.Drawing;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Solving {
    public abstract class ASolvingAlgorithm : ISolvingAlgorithm {
        #region Variables
        protected int[] solution;
        protected bool solving;
        protected IPathDrawer pathDrawer = new LineDrawer();
        #endregion

        #region Functions
        #region Protected Functions
        protected void initSolutions() {
            for (int i = 0; i < solution.Length; i++)
                solution[i] = -1;
        }

        protected int Length(int element) {
            if (element >= solution.Length)
                return -1;
            else if (element < 0)
                return -1;
            else if (solution[element] <= 0)
                return 1;
            else
                return 1 + Length(solution[element]);
        }

        protected void DrawLine(Graphics g, int a, int b, int width, Color color) {
            int rowa, rowb, columna, columnb;
            rowa = a / width;
            rowb = b / width;
            columna = a % width;
            columnb = b % width;
            g.DrawLine(new Pen(color, 0.2f * Global.squareSize), new Point(columna * Global.squareSize + (Global.squareSize / 2), rowa * Global.squareSize + (Global.squareSize / 2)), new Point(columnb * Global.squareSize + (Global.squareSize / 2), rowb * Global.squareSize + (Global.squareSize / 2)));
        }
        #endregion

        #region Public Functions
        public virtual void Draw(Graphics g, Maze maze) {
            if (!maze.solved && !solving)
                return;

            if (solution == null)
                return;

            for (int i = 0; i < solution.Length; i++) {
                if (solution[i] < 0)
                    continue;

                pathDrawer.Draw(g, i, solution[i], maze.width, Length(i), Color.Black);
                //DrawLine(g, i, solution[i], maze.width, Color.Black);
            }

            if (maze.solved) {
                int current = maze.end;
                LineDrawer drawer = new LineDrawer();
                while (current != maze.start) {
                    drawer.Draw(g, current, solution[current], maze.width, 0, Color.LightGreen);
                    //DrawLine(g, current, solution[current], maze.width, Color.LightGreen);

                    current = solution[current];
                }
            }
        }

        public void UpdateDrawMethod(bool distanceMethod) {
            if (distanceMethod)
                pathDrawer = new DistanceDrawer();
            else
                pathDrawer = new LineDrawer();
        }

        public virtual void SolveMaze(Maze maze) {
            solving = true;

            solution = new int[maze.maze.size];
            initSolutions();

            solution[maze.start] = -2;
        }

        public virtual void reset() {
            if (solution == null)
                return;
            for (int i = 0; i < solution.Length; i++)
                solution[i] = -1;
        }
        #endregion
        #endregion
    }
}
