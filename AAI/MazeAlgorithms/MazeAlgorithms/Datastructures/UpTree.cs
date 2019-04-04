using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Datastructures {
    public class UpTree {
        #region Variables
        #region Private Variables
        private readonly int[] tree;
        #endregion

        #region Public Variables
        public int width;
        public int height;

        public int size => width * height;
        #endregion
        #endregion

        #region Constructors
        public UpTree(int width, int height) {
            this.width = width;
            this.height = height;

            tree = new int[size];

            initTree();
        }
        #endregion

        #region Functions
        #region Private Functions
        private void initTree() {
            for (int i = 0; i < size; i++)
                tree[i] = -1;
        }
        #endregion

        #region Public Functions
        public int Find(int element) {
            if (element >= size)
                return -1;
            else if (element < 0)
                return -1;
            else if (tree[element] < 0)
                return element;
            else {
                tree[element] = Find(tree[element]);
                return tree[element];
            }
        }

        public bool Union(int element1, int element2) {
            int root1 = Find(element1);
            int root2 = Find(element2);

            int newSize = tree[root1] + tree[root2];

            if (root1 == root2)
                return false;
            else if (tree[root1] < tree[root2]) {
                tree[root2] = root1;

                tree[root1] = newSize;
            } else {
                tree[root1] = root2;

                tree[root2] = newSize;
            }
            return true;
        }

        public bool IsMaze() {
            for (int i = 1; i < size; i++)
                if (tree[i] == -size)
                    return true;

            return false;
        }

        public List<Edge> GetAllEdges() {
            List<Edge> edgeList = new List<Edge>();

            for (int i = 0; i < size; i++) {
                if (i / width == (i + 1) / width)
                    edgeList.Add(new Edge(i, i + 1));

                if (i + width < size)
                    edgeList.Add(new Edge(i, i + width));
            }
            return edgeList;
        }

        public List<int> GetAllNeighbours(int square) {
            List<int> possibilities = new List<int>();

            if (square < 0 || square >= size)
                return possibilities;

            if (square - width >= 0)     // Check up
                possibilities.Add(square - width);
            if (square / width == (square + 1) / width)     // Check right
                possibilities.Add(square + 1);
            if (square + width < size)      // Check down
                possibilities.Add(square + width);
            if (square / width == (square - 1) / width && square > 0)       // Check left
                possibilities.Add(square - 1);

            //if (possibilities.Count == 0)
            //    return null;

            return possibilities;
        }

        public void PrintTree() {
            foreach (int i in tree)
                Console.Write(i + "   ");
        }
        #endregion
        #endregion
    }
}
