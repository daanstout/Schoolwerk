using MazeAlgorithms.Algorithms.Generating;
using MazeAlgorithms.Algorithms.Solving;
using MazeAlgorithms.Datastructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.MazeMain {
    public class Maze {
        #region Variables
        #region Lazy Variables
        private List<Edge> _mazeEdges;

        public List<Edge> mazeEdges {
            get {
                if (_mazeEdges == null)
                    _mazeEdges = new List<Edge>();
                return _mazeEdges;
            }
        }
        #endregion

        #region Private Variables
        private ISolvingAlgorithm solvingAlgorithm;
        private IGeneratingAlgorithm generatingAlgorithm;
        #endregion

        #region Public Variables
        public UpTree maze;
        public int width, height;
        #endregion
        #endregion

        #region Constructors
        public Maze(int width, int height) : this(width, height, new AStarSolvingAlgorithm(), new RandomGeneratingAlgorithm()) { }

        public Maze(int width, int height, ISolvingAlgorithm solving, IGeneratingAlgorithm generating) {
            maze = new UpTree(width, height);
            this.width = width;
            this.height = height;
            this.solvingAlgorithm = solving;
            this.generatingAlgorithm = generating;
        }
        #endregion

        #region Functions
        #region Public Functions
        public void Draw(Graphics g) {
            generatingAlgorithm.Draw(g, maze);

            DrawOutline(g);

            DrawMazeEdges(g);
        }

        public void SetGeneratingAlgorithm(IGeneratingAlgorithm algorithm) {
            generatingAlgorithm = algorithm;
        }

        public void SetSolvingAlgorithm(ISolvingAlgorithm algorithm) {
            solvingAlgorithm = algorithm;
        }

        public void GenerateMaze() {
            _mazeEdges = null;
            maze = new UpTree(width, height);

            generatingAlgorithm.GenerateMaze(this);
        }

        public void SolveMaze() {
            solvingAlgorithm.SolveMaze(maze);
        }
        #endregion

        #region Private Functions
        private void DrawOutline(Graphics g) {
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i < width; i++) {
                g.DrawLine(pen, new Point(i * Global.squareSize, 0), new Point((i + 1) * Global.squareSize, 0));
                g.DrawLine(pen, new Point(i * Global.squareSize, height * Global.squareSize), new Point((i + 1) * Global.squareSize, height * Global.squareSize));
            }
            for (int i = 0; i < height; i++) {
                g.DrawLine(pen, new Point(0, i * Global.squareSize), new Point(0, (i + 1) * Global.squareSize));
                g.DrawLine(pen, new Point(width * Global.squareSize, i * Global.squareSize), new Point(width * Global.squareSize, (i + 1) * Global.squareSize));
            }
        }

        private void DrawMazeEdges(Graphics g) {
            if (mazeEdges.Count == 0)
                return;

            foreach (Edge edge in mazeEdges) {
                edge.DrawEdgeLine(g, width, Color.Red);
            }
        }
        #endregion
        #endregion
    }
}
