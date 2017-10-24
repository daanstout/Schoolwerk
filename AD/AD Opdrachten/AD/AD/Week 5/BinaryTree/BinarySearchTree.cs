using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week_5.BinaryTree {
    public class BinarySearchTree : IBinarySearchTree {
        public Node root;

        public BinarySearchTree(Node root) {
            this.root = root;
        }

        public int FindMin() {
            return FindMin(root);
        }

        private int FindMin(Node node) {
            if (node == null)
                return 0;
            else {
                if (node.left == null)
                    return node.element;
                else
                    return FindMin(node.left);
            }
        }

        public string InOrder() {
            return InOrder(root);
        }

        private string InOrder(Node node) {
            if (node == null) {
                return "";
            } else {
                return InOrder(node.left) + " " + node.element + " " + InOrder(node.right);
            }
        }

        public void Insert(int x) {
            if (root == null)
                root = new Node(x);
            else
                Insert(x, root);
        }

        private void Insert(int x, Node node) {
            if (node.element > x) {
                if (node.left == null)
                    node.left = new Node(x);
                else
                    Insert(x, node.left);
            } else if (node.element < x) {
                if (node.right == null)
                    node.right = new Node(x);
                else
                    Insert(x, node.right);
            }
        }

        public override string ToString() {
            if (root == null)
                return "";
            else
                return ToString(root.left) + " " + root.element + " " + ToString(root.right);
        }

        private string ToString(Node node) {
            if (node == null)
                return "NULL";
            else {
                return "[ " + ToString(node.left) + " " + node.element + " " + ToString(node.right) + " ]";
            }
        }

        public void Remove(int x) {
            Remove(x, root, null);
        }

        private void Remove(int x, Node node, Node previous) {
            if (node == null)
                return;
            else if (node.element == x) {
                if (node.right == null && node.left == null) {
                    if (previous.left.element == x)
                        previous.left = null;
                    else
                        previous.right = null;
                } else if(node.right != null) {
                    Node current = node.right;
                    Node currentParent = node;
                    while(current.left != null) {
                        currentParent = current;
                        current = current.left;
                    }
                    current.left = node.left;
                } else {

                }
            } else if (node.element > x) {
                Remove(x, node.left, node);
            } else if (node.element < x) {
                Remove(x, node.right, node);
            }
        }

        public void RemoveMin() {
            RemoveMin(root, null);
        }

        private void RemoveMin(Node node, Node previous) {
            if (node.left == null) {
                if (node.right != null)
                    previous.left = node.right;
                else
                    previous.left = null;
            } else {
                RemoveMin(node.left, node);
            }
        }
    }
}
