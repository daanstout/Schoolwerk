using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week4.Binary {
    public class BinaryNode<T> where T : IComparable { // Omdat we de value willen kunnen vergelijken
        public T value;
        public BinaryNode<T> left; // Elke node heeft een linker child, ook als deze null is.
        public BinaryNode<T> right; // En elke node heeft een rechter child, ook als deze null is.

        public BinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right) {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }
}
