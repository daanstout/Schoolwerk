using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week_5.BinaryTree {
    public class Node {
        public int element;
        public Node left;
        public Node right;

        public Node(int x) {
            element = x;
            left = null;
            right = null;
        }
    }

}
