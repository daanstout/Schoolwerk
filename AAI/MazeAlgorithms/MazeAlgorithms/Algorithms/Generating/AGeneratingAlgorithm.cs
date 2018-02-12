using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeAlgorithms.MazeMain;

namespace MazeAlgorithms.Algorithms.Generating {
    public abstract class AGeneratingAlgorithm : IGeneratingAlgorithm {
        #region Variables
        protected List<Edge> edgeList;
        protected Edge current;
        protected Random rand = new Random();
        protected int iterations;
        #endregion

        #region Protected Functions
        protected Edge GetEdge(int a, int b) {
            Edge edge = null;

            if (edgeList == null)
                return edge;

            foreach (Edge e in edgeList)
                if (e.square1 == a && e.square2 == b || e.square2 == a && e.square1 == b)
                    return e;

            return edge;
        }
        #endregion

        #region Public Functions
        public virtual void Draw(Graphics g, Maze maze) {
            if (edgeList == null && maze.maze == null)
                return;
            if (edgeList == null)
                edgeList = maze.maze.GetAllEdges();

            for (int i = 0; i < edgeList.Count; i++)
                edgeList[i].DrawEdgeLine(g, maze.width, Color.LightGray);

            //Console.WriteLine(current + " - " + Global.showPosition);
            if(current != null && Global.showPosition) {
                int row, column;
                row = current.square1 / maze.width;
                column = current.square1 % maze.width;
                g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(column * Global.squareSize + 2, row * Global.squareSize + 2, Global.squareSize - 4, Global.squareSize - 4));
                row = current.square2 / maze.width;
                column = current.square2 % maze.width;
                g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(column * Global.squareSize + 2, row * Global.squareSize + 2, Global.squareSize - 4, Global.squareSize - 4));
            }
        }

        public virtual void GenerateMaze(Maze maze) {
            edgeList = maze.maze.GetAllEdges();

            iterations = 0;
        }

        public virtual int GetIterations() {
            return iterations;
        }

        public abstract string GetAbout();
        #endregion
    }
}
