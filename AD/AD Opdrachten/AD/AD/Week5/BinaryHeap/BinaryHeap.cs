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
