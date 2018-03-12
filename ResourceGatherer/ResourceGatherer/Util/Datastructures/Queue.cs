using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util.Datastructures {
    /// <summary>
    /// A self written generic Queue
    /// </summary>
    /// <typeparam name="T">The class this queue stores</typeparam>
    public class Queue<T> {
        #region Variables
        /// <summary>
        /// The queue
        /// </summary>
        T[] queue;
        /// <summary>
        /// Some data used to make everything a bit easier
        /// </summary>
        int front, back, queueMaxSize, queueSize;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the queue with a size of 5
        /// </summary>
        public Queue() : this(5) { }

        /// <summary>
        /// Initializes the queue
        /// </summary>
        /// <param name="maxSize">The max number of objects it can store before needing to be enlarged</param>
        public Queue(int maxSize) {
            queueMaxSize = maxSize;
            queue = new T[queueMaxSize];
            front = back = queueSize = 0;
        }
        #endregion

        #region Functions
        #region Private Functions
        /// <summary>
        /// Doubles the queue
        /// </summary>
        private void DoubleQueue() {
            T[] temp = new T[queueMaxSize * 2]; // Verdubbel de grootte
            for (int i = 0; i < queueMaxSize; i++) {
                temp[i] = queue[(i + back) % queueMaxSize]; // Vul de nieuwe array zo, dat de front vooraan staat en de back achteraan.
            }
            back = queueMaxSize;
            front = 0;
            queueMaxSize *= 2;
            queue = temp;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Checks if the current queue is emtpy
        /// </summary>
        public bool isEmpty {
            get {
                return queueSize == 0;
            }
        }

        /// <summary>
        /// Pushes an object into the queue
        /// </summary>
        /// <param name="item">The object to be pushed</param>
        public void Enqueue(T item) {
            if (queueSize == queueMaxSize) // Als de array vol zit, verdubbel dan de grootte
                DoubleQueue();
            queue[back] = item; // Zet het item achteraan de queue
            back++;
            queueSize++;
            back %= queueMaxSize; // Back wordt weer 0 als hij het einde van de array bereikt.
        }

        /// <summary>
        /// Removes the first item from the queue
        /// </summary>
        /// <returns>The object in the front</returns>
        public T Dequeue() {
            if (queueSize == 0)
                return default(T);
            T item = queue[front];
            queue[front] = default(T); // Zet de front op de default waarde (0, null, w/e)
            queueSize--; // Queue wordt kleiner
            front++; // De front gaat naar voren
            front %= queueMaxSize; // Front wordt weer 0 als hij het einde van de array bereikt.
            return item;
        }

        /// <summary>
        /// Clears the queue
        /// </summary>
        public void makeEmpty() {
            for (int i = 0; i < queueMaxSize; i++) {
                queue[i] = default(T); // Zet elk element van de array op de default waarde (0, null, w/e)
            }
            front = back = queueSize = 0; // Reset alle posities
        }
        #endregion
        #endregion
    }
}
