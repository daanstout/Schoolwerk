using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week5.BinaryTree {
    public class BinarySearchTree : IBinarySearchTree {
        public Node root;

        public BinarySearchTree(Node root) {
            this.root = root;
        }

        public int FindMin() {
            return FindMin(root);
        }

        private int FindMin(Node node) { // Find Minimum: De node met de laagste waarde is altijd helemaal links in een Binary Search Tree.
            if (node == null)
                return 0;
            else {
                if (node.left == null) // Als de huidige node geen linker child heeft, is hij dus de kleinste waarde.
                    return node.element;
                else // Heeft hij wél een linker child, bekijk deze dan (recursief)
                    return FindMin(node.left);
            }
        }

        public string InOrder() {
            return InOrder(root);
        }

        private string InOrder(Node node) { // In Order: eerst linker child, dan zelf, dan rechter child.
            if (node == null) {
                return ""; // Base case, lege string als (child)node niet bestaat.
            } else {
                return InOrder(node.left) + " " + node.element + " " + InOrder(node.right); // Alle linker children eerst, dan de eigen waarde, dan alle rechter
            }
        }

        public void Insert(int x) {
            if (root == null) // De in-te-voegen node wordt de root als er geen root is.
                root = new Node(x);
            else
                Insert(x, root);
        }

        private void Insert(int x, Node node) {
            if (node.element > x) { // Als de bekeken node een grotere waarde heeft dan de in-te-voegen node, gaan we naar LINKS.
                if (node.left == null) // Als de bekeken node geen linker child heeft, wordt de in-te-voegen node de linker child
                    node.left = new Node(x);
                else // Anders gaan we (recursief) een stap verder.
                    Insert(x, node.left);
            } else if (node.element < x) { // Zelfde als hierboven, maar nu gaan we naar RECHTS.
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
            //Remove(x, root, null);
        }

        /*private void Remove(int x, Node node, Node previous) {
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
        }*/

        public void RemoveMin() {
            RemoveMin(root, null);
        }

        private void RemoveMin(Node node, Node previous) { // De laagste node is altijd ver links.
            if (node.left == null) { // Als er geen linker child is..
                if (node.right != null) // ..maar WÉL een rechter child..
                    previous.left = node.right; // ..zet dan het rechter child als de "nieuwe" laagste node
                else
                    previous.left = null; // Als er óók geen rechter child is, verwijder deze leaf dan
            } else { // Zolang er nog een linker child is gaan we (recursief) dieper
                RemoveMin(node.left, node);
            }
        }
    }
}
