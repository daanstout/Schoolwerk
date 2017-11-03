using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week2.LinkedList {
    public class Node<T> {
        public T data;
        public Node<T> next; // Een single linked list kan 0 of 1 "next" hebben

        public Node(T data) {
            this.data = data;
        }
    }
}
