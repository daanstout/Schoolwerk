using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinaryIntTree {
    public class Node {
        public int element;
        public Node left;
        public Node right;

        public Node(int x) {
            element = x;
            left = right = null;
        }

        void insert(int x) {
            if (x < element)
                if (left == null)
                    left = new Node(x);
                else
                    left.insert(x);
            else if (x > element)
                if (right == null)
                    right = new Node(x);
                else
                    right.insert(x);
        }
    }
}
