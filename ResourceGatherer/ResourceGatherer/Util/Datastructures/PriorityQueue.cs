using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util.Datastructures {
    /// <summary>
    /// A self written generic Priority Queue
    /// </summary>
    /// <typeparam name="T">The class that has to be stored in the nodes</typeparam>
    public class PriorityQueue<T> {
        #region Variables
        /// <summary>
        /// The current heap
        /// </summary>
        PriorityNode<T>[] heap;
        /// <summary>
        /// The amount of objects in the heap
        /// </summary>
        int size;
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor that initializes the heap
        /// </summary>
        public PriorityQueue() : this(5) { }

        /// <summary>
        /// Simple constructor that initializes the heap
        /// </summary>
        /// <param name="heapSize">The starting size of the heap</param>
        public PriorityQueue(int heapSize) {
            heap = new PriorityNode<T>[heapSize];
            size = 0;
        }
        #endregion

        #region Functions
        #region Private Functions
        /// <summary>
        /// Prints the heap to the console
        /// </summary>
        /// <param name="i">The index of the current object to be printed</param>
        /// <param name="t">The number of indents, so it resembles a tree</param>
        private void PrintHeap(int i, int t) {
            if (i > size)
                return;

            PrintHeap(i * 2 + 1, t + 1);

            for (int j = 0; j < t; j++)
                Console.Write('\t');
            Console.WriteLine("P: {1}", heap[i].node, heap[i].priority);

            PrintHeap(i * 2, t + 1);

        }

        /// <summary>
        /// Moves an index down until its parent is smaller and both its childs are larger
        /// </summary>
        /// <param name="i">The index to percolate from</param>
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

        /// <summary>
        /// Moves an object down. This object only has a left child and we would thus not need to go down further
        /// </summary>
        /// <param name="i">The index to percolate from</param>
        private void PercolateDownLeft(int i) {
            int left = i * 2;
            if (heap[i].priority > heap[left].priority) {
                heap[0] = heap[i];
                heap[i] = heap[left];
                heap[left] = heap[0];
            }
        }

        /// <summary>
        /// Doubles the current heap
        /// </summary>
        private void DoubleArray() {
            PriorityNode<T>[] temp = new PriorityNode<T>[heap.Length * 2];
            for (int i = 1; i < heap.Length; i++)
                temp[i] = heap[i];

            heap = temp;
        }

        /// <summary>
        /// Checks if an object is currently present in the heap
        /// </summary>
        /// <param name="n">The object to be checked</param>
        /// <returns>True if it is in the heap, False if not</returns>
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
        /// <summary>
        /// Checks if the heap is empty
        /// </summary>
        public bool isEmpty {
            get {
                return size == 0;
            }
        }

        /// <summary>
        /// Inserts an object into the heap
        /// </summary>
        /// <param name="node">The node to be inserted</param>
        /// <param name="priority">The priority of the node</param>
        public void Insert(T node, float priority) {
            if (node == null)
                return;

            if (HeapContainsNode(node))
                return;

            if (size + 1 == heap.Length)
                DoubleArray();

            PriorityNode<T> n = new PriorityNode<T>(node, priority);

            int hole = ++size;
            heap[0] = n;

            for (; n.priority < heap[hole / 2].priority && hole > 1; hole /= 2)
                heap[hole] = heap[hole / 2];

            heap[hole] = n;
        }

        /// <summary>
        /// Returns the highest priority node in the heap
        /// </summary>
        /// <returns>The object with the highest priority</returns>
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

        /// <summary>
        /// Prints the heap to the console
        /// </summary>
        public void PrintHeap() {
            PrintHeap(1, 0);
        }

        /// <summary>
        /// Percolates an object up until its parent is smaller and its children are higher
        /// </summary>
        /// <param name="i"></param>
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

        /// <summary>
        /// Percolates down from the start
        /// </summary>
        public void PercolateDown() {
            PercolateDown(1);
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// A priority node. It contains the object and its priority and is the building block of the priority queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PriorityNode<T> {
        #region Variables
        /// <summary>
        /// The object
        /// </summary>
        public T node;
        /// <summary>
        /// The priority of the object
        /// </summary>
        public float priority;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new node
        /// </summary>
        /// <param name="node">The object</param>
        /// <param name="priority">The priority</param>
        public PriorityNode(T node, float priority) {
            this.node = node;
            this.priority = priority;
        }
        #endregion
    }
}
