using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Integer {
    public class Node {
        public int data;
        public Node left;
        public Node right;

        public Node(int data, Node left, Node right) {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public Node(int data) {
            this.data = data;
        }

        public Node() { }

        public void addNode(Node n) {
            if (n.data < data) {
                if (left == null)
                    left = n;
                else
                    left.addNode(n);
            } else {
                if (right == null)
                    right = n;
                else
                    right.addNode(n);
            }
        }

        public void PostPrintNode() {
            if (left != null)
                left.PostPrintNode();
            if (right != null)
                right.PostPrintNode();
            Console.WriteLine(data);
        }

        public void InPrintNode() {
            if (left != null)
                left.InPrintNode();
            Console.WriteLine(data);
            if (right != null)
                right.InPrintNode();
        }

        public void PrePrintNode() {
            Console.WriteLine(data);
            if (left != null)
                left.PrePrintNode();
            if (right != null)
                right.PrePrintNode();
        }

        public void RemoveAllNode(int data) {
            if (this.data < data) {
                if (left != null)
                    if (left.data == data)
                        left = null;
                    else
                        left.RemoveAllNode(data);
            } else if (this.data > data)
                if (right != null)
                    if (right.data == data)
                        right = null;
                    else
                        left.RemoveAllNode(data);
        }

        public void RemoveSingleNode(int data) {

        }
    }
}
