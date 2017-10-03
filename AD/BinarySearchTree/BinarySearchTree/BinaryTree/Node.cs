using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinaryTree{
    public class Node<T> where T : IComparable<T> {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T data, Node<T> left, Node<T> right) {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public Node(T data) {
            this.data = data;
        }

        public Node() { }

        public void insert(Node<T> node) {
            Console.WriteLine(data.CompareTo(node.data));
            if (data.CompareTo(node.data) == 1) {
                Console.WriteLine("Bigger");
                if (right == null)
                    right = node;
                else
                    right.insert(node);
            } else if (data.CompareTo(node.data) == 1) {
                Console.WriteLine("Smaller");
                if (left == null)
                    left = node;
                else
                    left.insert(node);
            }
        }
    }
}
