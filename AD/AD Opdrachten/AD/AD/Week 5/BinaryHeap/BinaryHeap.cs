using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week_5.BinaryHeap {
    public class BinaryHeap {
        int[] heap;
        int size;

        public BinaryHeap() {
            heap = new int[5];
            size = 0;
        }

        public int FindMin() {
            return heap[1];
        }

        public void add(int x) {
            if (size + 1 == heap.Length) {
                doubleArray();
            }

            int hole = ++size;
            heap[0] = x;

            for (; x < heap[hole / 2]; hole /= 2)
                heap[hole] = heap[hole / 2];

            heap[hole] = x;
        }

        public void printPreOrder() {
            Console.Write("Pre order: [ ");
            printPreOrder(1);
            Console.WriteLine("]");
        }

        private void printPreOrder(int i) {
            if (i > size)
                return;
            else {
                Console.Write(heap[i] + " ");
                printPreOrder(i * 2);
                printPreOrder(i * 2 + 1);
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
