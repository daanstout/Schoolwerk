using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week4.Binary {
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable {
        public BinaryNode<T> root;

        public BinaryTree(BinaryNode<T> root) {
            this.root = root;
        }

        public void addNode(BinaryNode<T> node) {
            if (node == null)
                return;
            else if (root == null) // Als er geen root is wordt node de nieuwe root
                root = node;
            else 
                addNode(node, root);            
        }

        // root > node = 1  -> links
        // root == node = 0 -> waarde is gelijk -- doe niks.
        // root < node = -1 -> rechts
        private void addNode(BinaryNode<T> node, BinaryNode<T> current) {
            if (current.value.CompareTo(node.value) == 1) { // De toe-te-voegen node heeft een lagere waarde dan de bekeken node (ROOT bij de eerste keer)
                if (current.left == null)
                    current.left = node; // Als de bekeken node geen linker child heeft wordt de toe-te-voegen node deze
                else
                    addNode(node, current.left); // is er wél een linker child, ga dan (recursief) een stap verder.
            } else if (current.value.CompareTo(node.value) == -1) { // Idem als hierboven, maar dan voor rechts.
                if (current.right == null)
                    current.right = node;
                else
                    addNode(node, current.right);
            }
        }

        public override string ToString() {
            if (root == null)
                return "NULL";
            else { // Als de root node niet leeg is, ToString dan eerst (recursief) de linker node, en daarna de rechter.
                return ToString(root.left) + " " + root.value + " " + ToString(root.right);
            }
        }

        private string ToString(BinaryNode<T> node) {
            if (node == null)
                return "NULL";
            else { // Zelfde als hierboven, maar dan met een blokhaak als de node niet null is.
                return "[ " + ToString(node.left) + " " + node.value + " " + ToString(node.right) + " ]";
            }
        }

        public int getLeaves() {
            return getLeaves(root);
        }

        private int getLeaves(BinaryNode<T> node) {
            if (node == null)
                return 0; // Base case, breakpoint.
            else {
                if (node.left == null && node.right == null) // Heeft de huidige node geen children, dan is het een leaf -- return 1 voor het eindresultaat.
                    return 1; 
                else // heeft hij wél children, dan is het geen leaf -- return 0 en ga recursief de linker en rechter children af.
                    return 0 + getLeaves(node.left) + getLeaves(node.right);
            }
        }

        public int getSingleChilds() {
            return getSingleChilds(root);
        }

        private int getSingleChilds(BinaryNode<T> node) {
            if (node == null)
                return 0; // Base case, breakpoint.
            else {
                if ((node.left == null && node.right != null) || (node.left != null && node.right == null)) // Check of de node EN diens Children maar 1 child heeft
                    return 1 + getSingleChilds(node.left) + getSingleChilds(node.right);
                else // Zo niet, check dan alleen nog de children (ook als deze null zijn)
                    return 0 + getSingleChilds(node.left) + getSingleChilds(node.right);
            }
        }

        public int getDualChilds() {
            return getDualChilds(root);
        }

        private int getDualChilds(BinaryNode<T> node) {
            if (node == null)
                return 0; // Base case, breakpoint.
            else {
                if (node.left != null && node.right != null) // Check of de node EN diens children 2 children hebben
                    return 1 + getDualChilds(node.left) + getDualChilds(node.right);
                else // Zo niet, check dan alleen nog de children (ook als deze null zijn)
                    return 0 + getDualChilds(node.left) + getDualChilds(node.right);
            }
        }

        #region Interface
        public BinaryNode<T> GetRoot() {
            return root;
        }

        public int Height() {
            return Height(root);
        }

        private int Height(BinaryNode<T> node) {
            if (node == null)
                return 0; // Bestaat er een child niet, return dan 0
            else {
                int sizeLeft = Height(node.left); // Ga recursief elk linker child af
                int sizeRight = Height(node.right); // Ga recursief elk rechter child af

                if (sizeLeft > sizeRight)
                    return sizeLeft + 1;
                else
                    return sizeRight + 1;
            }
        }

        public bool IsEmpty() {
            return root == null; // Simplistische "if". Te lezen als if(root == null) return true; else return false;
        }

        public void MakeEmpty() {
            root = null; // als root null wordt is de rest van de tree niet meer te bereiken, waardoor deze zo goed als leeg is.
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2) {

        }

        public void PrintInOrder() {
            Console.Write("Print in order: [ ");
            PrintInOrder(root);
            Console.WriteLine("]");
        }

        private void PrintInOrder(BinaryNode<T> node) { // In Order: linker child eerst, dan self, dan rechter child.
            if (node == null)
                return; // Base case als (child)node niet bestaat
            else {
                PrintInOrder(node.left); // Linker child eerst..
                Console.Write(node.value + " "); // ..dan self..
                PrintInOrder(node.right); // ..dan rechter child.
            }
        }

        public void PrintPostOrder() { 
            Console.Write("Print post order: [ ");
            PrintPostOrder(root);
            Console.WriteLine("]");
        }

        private void PrintPostOrder(BinaryNode<T> node) { // Post Order: Linker child eerst, dan rechter child, dan self.
            if (node == null)
                return; // Base case als (child)node niet bestaat
            else {
                PrintPostOrder(node.left); // Linker children eerst..
                PrintPostOrder(node.right); // ..dan alle rechter children..
                Console.Write(node.value + " "); // ..dan self
            }
        }

        public void PrintPreOrder() {
            Console.Write("Print pre order: [ ");
            PrintPreOrder(root);
            Console.WriteLine("]");
        }

        private void PrintPreOrder(BinaryNode<T> node) { // Pre Order: Eerst self, dan linker child, dan rechter child.
            if (node == null)
                return; // Base case als (child)node niet bestaat
            else {
                Console.Write(node.value + " "); // Eerst self..
                PrintPreOrder(node.left); // ..dan alle linker children..
                PrintPreOrder(node.right); // ..dan alle rechter children
            }
        }

        public int Size() {
            return Size(root);
        }

        private int Size(BinaryNode<T> node) { // De size van een Tree is het aantal nodes
            if (node == null)
                return 0; // Als een (child)node niet bestaat, wordt hij niet geteld.
            else {
                return 1 + Size(node.left) + Size(node.right); // Als de node wel bestaat, tel dan 1 en check (recursief) de linker en rechter child
            }
        }
        #endregion
    }
}
