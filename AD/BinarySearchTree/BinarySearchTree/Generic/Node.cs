using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Generic{
    public class Node<T> {
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
    }
}
