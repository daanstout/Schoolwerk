using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinaryIntTree {
    public class BinaryTree : IBinarySearchTree {
        public Node root;

        public BinaryTree(Node root) {
            this.root = root;
        }

        public BinaryTree() { }


        public int FindMin() {
            if (root != null)
                return FindMin(root).element;
            else
                return 0;
        }

        private Node FindMin(Node n) {
            if (n.left == null)
                return n;
            else
                return FindMin(n);
        }


        public string InOrder() {
            if (root != null)
                return InOrder(root);
            else
                return "";
        }

        private string InOrder(Node n) {
            string s = "";
            if (n.left != null)
                s += InOrder(n.left);
            s += n.element + " ";
            if (n.right != null)
                s += InOrder(n.right);
            return s;
        }


        public void Insert(int x) {
            if (root == null)
                root = new Node(x);
            else
                Insert(x, root);
        }

        private void Insert(int x, Node n) {
            if (x < n.element)
                if (n.left == null)
                    n.left = new Node(x);
                else
                    Insert(x, n.left);
            else if (x > n.element)
                if (n.right == null)
                    n.right = new Node(x);
                else
                    Insert(x, n.right);
        }


        public void Remove(int x) {
            Remove(x, root);
        }

        private Node Remove(int x, Node n) {
            if (n == null)
                throw new Exception();
            if (x < n.element)
                n.left = Remove(x, n.left);
            else if (x > n.element)
                n.right = Remove(x, n.right);
            else if (n.left != null && n.right != null) {
                n.element = FindMin(n.right).element;
                n.right = RemoveMin(n.right);
            } else
                n = (n.left != null) ? n.left : n.right;

            return n;

        }


        public void RemoveMin() {
            if (root != null)
                RemoveMin(root);
        }

        private Node RemoveMin(Node n) {
            if (n == null)
                throw new Exception();
            else if (n.left != null) {
                n.left = RemoveMin(n.left);
                return n;
            } else
                return n.right;

        }


        public override string ToString() {
            return ToString(root);
        }

        private string ToString(Node n) {
            if (n == null)
                return "";

            string s;
            s = "";

            if (n.left == null)
                s += "NULL";
            else
                s += "[ " + ToString(n.left) + " ]";

            s += " " + n.element + " ";

            if (n.right == null)
                s += "NULL";
            else
                s += "[ " + ToString(n.right) + " ]";

            return s;
        }
    }
}
