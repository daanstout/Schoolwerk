using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week4.Binary {
    public class BinaryNode<T> where T : IComparable { // Omdat we de value willen kunnen vergelijken
        public T value;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right) {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }
}
