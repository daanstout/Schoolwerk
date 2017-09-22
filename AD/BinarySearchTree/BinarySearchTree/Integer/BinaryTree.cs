using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Integer {
    public class BinaryTree {
        public Node root;

        public BinaryTree(Node root) {
            this.root = root;
        }

        public void addNode(Node n) {
            root.addNode(n);
        }

        public void PrePrintTree() {
            root.PrePrintNode();
        }

        public void inPrintTree() {
            root.InPrintNode();
        }

        public void PostPrintTree() {
            root.PostPrintNode();
        }

        public void RemoveAllNode(int data) {
            if(root != null) {
                if (root.data == data)
                    root = null;
                else
                    root.RemoveAllNode(data);
            }
        }

        public void RemoveSingleNode(int data) {

        }
    }
}
