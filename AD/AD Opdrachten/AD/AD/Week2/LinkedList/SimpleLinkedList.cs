using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week2.LinkedList {
    public class SimpleLinkedList<T> : ISimpleLinkedList<T> {
        private Node<T> header;

        public SimpleLinkedList() {
            header = new Node<T>(default(T)); // De header is een nieuwe node met de default waarde van whatever T is (0, null, w/e)
        }

        public void addFirst(T data) { // Vooraan de lijst toevoegen, ná de Header
            if (header.next == null)
                header.next = new Node<T>(data); // Voeg het element direct toe als de Header geen "next" heeft ( == lijst is leeg)
            else {
                Node<T> temp = header.next; // Oude eerste node opgeslagen in een tijdelijke variabele..
                header.next = new Node<T>(data); // ..nieuwe Node wordt aan de Header gekoppeld..
                header.next.next = temp; // ..nieuwe Node wordt via temp aan oude Node gekoppeld.
            }
        }

        public void clear() {
            header.next = null; // Header's "next" wordt null. De gehele lijst is nu "zwevende" data die wordt opgepikt door de Garbage Collector
        }

        public T getFirst() {
            if (header.next == null)
                return default(T); // Return 0 of null ofzo wanneer de lijst leeg is

            return header.next.data; // Return anders de data van de eerste Node na de Header
        }

        public void insertWhile(int index, T data) {
            if (index < 0) // Negatieve indexen zijn onmogelijk.
                return;
            else {
                Node<T> current = header; // Variabele current om bij te houden waar in de lijst we zijn.
                while (current.next != null && index > 0) { // De volgende Node mag niet null zijn EN we zijn nog niet waar we wíllen zijn..
                    current = current.next; // ..current gaat naar de volgende Node..
                    index--; // ..en index wordt eentje kleiner omdat we een stapje dichterbij zijn
                }
                if (index > 0) { // current.next is null, dus de while-loop stopt, maar index wil verder springen: opgegeven index ligt buiten de List, dus return.
                    return;
                } else if (current.next == null) {  // Index EN current.next zijn 0/null, de in-te-voegen Node moet precies aan het einde van de Lijst gezet worden.
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
            Node<T> temp = header.next.next; // Zet de Node die aan de Header vast zit op de Node ná de eerste (header.next.next).
            header.next = temp;
        }
    }
}
