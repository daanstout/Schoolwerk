using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Datastructures {
    public class PriorityQueue<T> {
        #region Variables
        PriorityNode<T>[] heap;
        int size;
        #endregion

        #region Constructors
        public PriorityQueue() {
            heap = new PriorityNode<T>[5];
            size = 0;
        }
        #endregion

        #region Functions
        #region Private Functions
        private void PrintHeap(int i, int t) {
            if (i > size)
                return;

            PrintHeap(i * 2 + 1, t + 1);

            for (int j = 0; j < t; j++)
                Console.Write('\t');
            Console.WriteLine("P: {1}", heap[i].node, heap[i].priority);

            PrintHeap(i * 2, t + 1);

        }

        private void PercolateDown(int i) {
            if (i * 2 > size)
                return;
            else if (i * 2 == size) {
                PercolateDownLeft(i);
                return;
            }

            int left = i * 2;
            int right = i * 2 + 1;
            int smallest = heap[left].priority > heap[right].priority ? right : left;

            if (heap[i].priority > heap[smallest].priority) {
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
            if (heap[i].priority > heap[left].priority) {
                heap[0] = heap[i];
                heap[i] = heap[left];
                heap[left] = heap[0];
            }
        }

        private void DoubleArray() {
            PriorityNode<T>[] temp = new PriorityNode<T>[heap.Length * 2];
            for (int i = 1; i < heap.Length; i++)
                temp[i] = heap[i];

            heap = temp;
        }

        private bool HeapContainsNode(T n) {
            foreach (PriorityNode<T> node in heap) {
                if (node == null)
                    continue;
                if (node.node.Equals(n))
                    return true;
            }
            return false;
        }
        #endregion

        #region Public Functions
        public bool isEmpty {
            get {
                return size == 0;
            }
        }

        public void Insert(T node, int priority) {
            if (node == null)
                return;

            if (HeapContainsNode(node))
                return;

            if (size + 1 == heap.Length)
                DoubleArray();

            PriorityNode<T> n = new PriorityNode<T>(node, priority);

            int hole = ++size;
            heap[0] = n;

            for (; n.priority <= heap[hole / 2].priority && hole > 1; hole /= 2)
                heap[hole] = heap[hole / 2];

            heap[hole] = n;
        }

        public T GetHighestPriority() {
            if (size == 0)
                return default(T);

            if (size == 1) {
                return heap[size--].node;
            }

            T n = heap[1].node;

            heap[1] = heap[size--];

            PercolateDown();

            return n;
        }

        public void PrintHeap() {
            PrintHeap(1, 0);
        }

        public void PercolateUp(int i) {
            if (i == 1)
                return;

            if (heap[i / 2].priority < heap[i].priority) {
                heap[0] = heap[i];
                heap[i] = heap[i / 2];
                heap[i / 2] = heap[0];

                PercolateUp(i / 2);
            }
        }

        public void PercolateDown() {
            PercolateDown(1);
        }
        #endregion
        #endregion
    }

    class PriorityNode<T> {
        #region Variables
        public T node;
        public int priority;
        #endregion

        #region Constructors
        public PriorityNode(T node, int priority) {
            this.node = node;
            this.priority = priority;
        }
        #endregion
    }
}
