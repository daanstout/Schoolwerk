using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week2.LinkedList {
    public class SimpleLinkedList<T> : ISimpleLinkedList<T> {
        private Node<T> header;

        public SimpleLinkedList() {
            header = new Node<T>(default(T));
        }

        public void addFirst(T data) {
            if (header.next == null)
                header.next = new Node<T>(data);
            else {
                Node<T> temp = header.next;
                header.next = new Node<T>(data);
                header.next.next = temp;
            }
        }

        public void clear() {
            header.next = null;
        }

        public T getFirst() {
            if (header.next == null)
                return default(T);

            return header.next.data;
        }

        public void insertWhile(int index, T data) {
            if (index < 0)
                return;
            else {
                Node<T> current = header;
                while (current.next != null && index > 0) {
                    current = current.next;
                    index--;
                }
                if (index > 0) { // Hier komen we als we niet meer kunnen hoppen want current.next == null, maar index is groter dan 0 dus we willen nog verder.
                    return;
                } else if (current.next == null) {  // Hier komen we als we niet meer kunnen hoppen want current.next == null EN index is 0 dus we zijn ook waar we willen komen.
                    current.next = new Node<T>(data);
                } else {    // Hier komen we als we nog wel kunnen hoppen want current.next != null, maar index is 0 dus we zijn waar we willen zijn.
                    Node<T> temp = current.next;
                    current.next = new Node<T>(data);
                    current.next.next = temp;
                }
            }
        }

        #region insert
        public void insert(int index, T data) {
            if (index < 0)
                return;
            else
                insert(index, data, header);
        }

        private void insert(int index, T data, Node<T> current) {
            if (current.next == null && index > 0)
                return;
            else if (current.next == null)
                current.next = new Node<T>(data);
            else if (index > 0)
                insert(index - 1, data, current.next);
            else if (index == 0) {
                Node<T> temp = current.next;
                current.next = new Node<T>(data);
                current.next.next = temp;
            }
        }
        #endregion

        public void print() {
            print(header.next);
        }

        private void print(Node<T> current) {
            if (current == null) {
                return;
            } else {
                Console.WriteLine("data: " + current.data);
                print(current.next);
            }
        }

        public void removeFirst() {
            Node<T> temp = header.next.next;
            header.next = temp;
        }
    }
}
