using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week5.BinaryHeap {
    public class BinaryHeap {
        int[] heap;
        int size;

        public BinaryHeap() {
            heap = new int[5]; // Nieuwe array met een vaste grootte van 5.
            size = 0; // Indexteller.
        }

        public int FindMin() {
            return heap[1]; // Het tweede element van een BinaryHeap is altijd het laagste ((Het éérste element is leeg, en wordt gebruikt voor percolaten)
        }

        public void add(int x) {
            if (size + 1 == heap.Length) {
                doubleArray(); // Verdubbel de grootte van de array als de maximale grootte overschreden wordt.
            }

            int hole = ++size; // Bepaal een plek voor de nieuwe waarde
            heap[0] = x; // Zet de toe te voegen waarde (tijdelijk!) op de eerste index.

            // Door hoe de Heap werkt, een index gedeeld door twee is altijd de parent van de Node. 
            for (; x < heap[hole / 2]; hole /= 2) // Deze loop gaat door totdat de toe-te-voegen waarde NÍET lager is dan de waarde van de bovenliggende node
                heap[hole] = heap[hole / 2]; // Als de waarde van x wel lager is, zet dan de waarde van de bovenliggende node in de onderliggende. Hierdoor ontstaat een gaatje.

            heap[hole] = x; // Zet de waarde van x in het gat
        }

        public void printPreOrder() { // Starter
            Console.Write("Pre order: [ ");
            printPreOrder(1);
            Console.WriteLine("]");
        }

        private void printPreOrder(int i) { // Vervolg -- PreOrder: Self, Links, Rechts
            if (i > size)
                return;
            else {
                Console.Write(heap[i] + " "); // Self is easy
                printPreOrder(i * 2); // Linker child is altijd de index van het huidige element keer twee. (recursief)
                printPreOrder(i * 2 + 1); // Rechter child is altijd de index van het huidige element keer twee plus 1 (recursief)
            }
        }

        public void PercolateUp(int i) {
            if (i == 1)
                return;

            if (heap[i / 2] < heap[i]) {
                heap[0] = heap[i];
                heap[i] = heap[i / 2];
                heap[i / 2] = heap[0];

                PercolateUp(i / 2);
            }
        }

        public void BuildHeap(int[] list) {
            heap = list;
            size = list.Length;

            for (int i = size / 2; i >= 1; i--) {
                if (i * 2 + 1 > size)
                    PercolateDownLeft(i);
                else
                    PercolateDown(i);
            }
        }

        public void PercolateDown() {
            PercolateDown(1);
        }

        private void PercolateDown(int i) {
            int left = i * 2;
            int right = i * 2 + 1;
            int smallest = heap[left] > heap[right] ? right : left;
            if (heap[i] > heap[smallest]) {
                heap[0] = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = heap[0];
                if (smallest * 2 <= size) {
                    if (smallest * 2 + 1 <= size)
                        PercolateDown(smallest);
                    else
                        PercolateDownLeft(smallest);
                }
            }
        }

        private void PercolateDownLeft(int i) {
            int left = i * 2;
            if (heap[i] > heap[left]) {
                heap[0] = heap[i];
                heap[i] = heap[left];
                heap[left] = heap[0];
            }
        }

        private void doubleArray() {
            int[] temp = new int[heap.Length * 2];
            for (int i = 1; i < heap.Length; i++)
                temp[i] = heap[i];

            heap = temp;
        }
    }
}
