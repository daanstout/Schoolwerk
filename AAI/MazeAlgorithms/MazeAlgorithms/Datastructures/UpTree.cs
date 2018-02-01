using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Datastructures {
    public class UpTree {
        #region Variables
        int[] tree;
        int size;
        #endregion

        #region Constructors
        private UpTree(int size) {
            tree = new int[size];

            this.size = size;

            initTree();
        }

        public UpTree(int width, int height) : this(width * height) { }
        #endregion

        #region Private functions
        private void initTree() {
            for (int i = 0; i < size; i++)
                tree[i] = -1;
        }
        #endregion

        #region Public functions
        public int Find(int element) {
            if (element >= size)
                return 0;
            else if (tree[element] < 0)
                return element;
            else {
                tree[element] = Find(tree[element]);
                return tree[element];
            }
        }

        public void Union(int element1, int element2) {
            int root1 = Find(element1);
            int root2 = Find(element2);

            int newSize = tree[root1] + tree[root2];
            if (root1 == root2)
                return;
            else if (tree[root1] < tree[root2]) {
                tree[root2] = root1;

                tree[root1] = newSize;
            } else {
                tree[root1] = tree[root2];

                tree[root2] = newSize;
            }
        }
        #endregion
    }
}
