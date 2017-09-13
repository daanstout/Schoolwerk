using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Week2.Opdracht2 {
    public class MyLinkedList<T> : ISimpleLinkedList<T> {
        Node<T> header;
        int size;

        public MyLinkedList() {
            header = new Node<T>();
            size = 0;
        }

        public void addFirst(T data) {
            header.next = new Node<T>(data, header.next);
            size++;
        }

        public void clear() {
            header.next = null;
            size = 0;
        }

        public T getFirst() {
            if (header.next == null)
                throw new ArgumentNullException();
            return header.next.data;
        }

        public void insert(int index, T data) {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            Node<T> temp = new Node<T>(data, null);

            Node<T> current = header.next;
            while(current != null && index > 0) {
                current = current.next;
                index--;
            }
        }

        public void print() {
            throw new NotImplementedException();
        }

        public void removeFirst() {
            throw new NotImplementedException();
        }
    }

    public class Node<T> {
        public T data;
        public Node<T> next;

        public Node(T data, Node<T> next) {
            this.data = data;
            this.next = next;
        }

        public Node() {

        }
    }
}
