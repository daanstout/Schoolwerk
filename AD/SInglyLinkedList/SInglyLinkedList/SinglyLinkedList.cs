using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SInglyLinkedList {
    public class SinglyLinkedList<T> {
        public Node<T> header = new Node<T>();

        public Node<T> tos {
            get {
                return header.next;
            }
        }

        public Node<T> find(int index) {
            return find(index - 1, header);
        }

        private Node<T> find(int index, Node<T> current) {
            if()
        }

        public void addNode(Node<T> node, int index) {

        }
    }
}
