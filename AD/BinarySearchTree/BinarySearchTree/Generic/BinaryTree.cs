using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Generic {
    public class BinaryTree<T> {
        public Node<T> root;

        public BinaryTree(Node<T> root) {
            this.root = root;
        }
    }
}
