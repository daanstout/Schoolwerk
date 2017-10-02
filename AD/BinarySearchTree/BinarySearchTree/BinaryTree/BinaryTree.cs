using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinaryTree {
    public class BinaryTree<T> where T : IComparable<T>{
        public Node<T> root;

        public BinaryTree(Node<T> root) {
            this.root = root;
        }

        public void insert(Node<T> node) {
            if (node != null) {
                if (root != null) {
                    root.insert(node);
                } else {
                    root = node;
                }
            }
        }
    }
}
