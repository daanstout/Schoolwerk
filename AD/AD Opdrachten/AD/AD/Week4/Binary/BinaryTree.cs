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

        // root > node = 1  -> links
        // root == node = 0 -> niet
        // root < node = -1 -> rechts
        public void addNode(BinaryNode<T> node) {
            //Console.WriteLine(root.value.CompareTo(node.value));
            if (node == null)
                return;
            else if (root == null)
                root = node;
            else {
                addNode(node, root);
            }
        }

        private void addNode(BinaryNode<T> node, BinaryNode<T> current) {
            if (current.value.CompareTo(node.value) == 1) {
                if (current.left == null)
                    current.left = node;
                else
                    addNode(node, current.left);
            } else if (current.value.CompareTo(node.value) == -1) {
                if (current.right == null)
                    current.right = node;
                else
                    addNode(node, current.right);
            }
        }

        public override string ToString() {
            if (root == null)
                return "NULL";
            else {
                return ToString(root.left) + " " + root.value + " " + ToString(root.right);
            }
        }

        private string ToString(BinaryNode<T> node) {
            if (node == null)
                return "NULL";
            else {
                return "[ " + ToString(node.left) + " " + node.value + " " + ToString(node.right) + " ]";
            }
        }

        public int getLeaves() {
            return getLeaves(root);
        }

        private int getLeaves(BinaryNode<T> node) {
            if (node == null)
                return 0;
            else {
                if (node.left == null && node.right == null)
                    return 1;
                else
                    return 0 + getLeaves(node.left) + getLeaves(node.right);
            }
        }

        public int getSingleChilds() {
            return getSingleChilds(root);
        }

        private int getSingleChilds(BinaryNode<T> node) {
            if (node == null)
                return 0;
            else {
                if ((node.left == null && node.right != null) || (node.left != null && node.right == null))
                    return 1 + getSingleChilds(node.left) + getSingleChilds(node.right);
                else
                    return 0 + getSingleChilds(node.left) + getSingleChilds(node.right);
            }
        }

        public int getDualChilds() {
            return getDualChilds(root);
        }

        private int getDualChilds(BinaryNode<T> node) {
            if (node == null)
                return 0;
            else {
                if (node.left != null && node.right != null)
                    return 1 + getDualChilds(node.left) + getDualChilds(node.right);
                else
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
                return 0;
            else {
                int sizeLeft = Height(node.left);
                int sizeRight = Height(node.right);

                if (sizeLeft > sizeRight)
                    return sizeLeft + 1;
                else
                    return sizeRight + 1;
            }
        }

        public bool IsEmpty() {
            return root == null;
        }

        public void MakeEmpty() {
            root = null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2) {

        }

        public void PrintInOrder() {
            Console.Write("Print in order: [ ");
            PrintInOrder(root);
            Console.WriteLine("]");
        }

        private void PrintInOrder(BinaryNode<T> node) {
            if (node == null)
                return;
            else {
                PrintInOrder(node.left);
                Console.Write(node.value + " ");
                PrintInOrder(node.right);
            }
        }

        public void PrintPostOrder() {
            Console.Write("Print post order: [ ");
            PrintPostOrder(root);
            Console.WriteLine("]");
        }

        private void PrintPostOrder(BinaryNode<T> node) {
            if (node == null)
                return;
            else {
                PrintPostOrder(node.left);
                PrintPostOrder(node.right);
                Console.Write(node.value + " ");
            }
        }

        public void PrintPreOrder() {
            Console.Write("Print pre order: [ ");
            PrintPreOrder(root);
            Console.WriteLine("]");
        }

        private void PrintPreOrder(BinaryNode<T> node) {
            if (node == null)
                return;
            else {
                Console.Write(node.value + " ");
                PrintPreOrder(node.left);
                PrintPreOrder(node.right);
            }
        }

        public int Size() {
            return Size(root);
        }

        private int Size(BinaryNode<T> node) {
            if (node == null)
                return 0;
            else {
                return 1 + Size(node.left) + Size(node.right);
            }
        }
        #endregion
    }
}
