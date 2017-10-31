using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week2.Queue {
    public class Queue<T> {
        T[] queue;
        int front, back, queueMaxSize, queueSize;

        public Queue() {
            queueMaxSize = 5;
            queue = new T[queueMaxSize];
            front = back = queueSize = 0; // Optional
        }

        public void Enqueue(T item) {
            if (queueSize == queueMaxSize) // Als de array vol zit, verdubbel dan de grootte
                DoubleQueue();
            queue[back] = item; // Zet het item achteraan de queue
            back++;
            queueSize++;
            back %= queueMaxSize; // Back wordt weer 0 als hij het einde van de array bereikt.
        }

        public T Dequeue() {
            T item = queue[front];
            queue[front] = default(T); // Zet de front op de default waarde (0, null, w/e)
            queueSize--; // Queue wordt kleiner
            front++; // De front gaat naar voren
            front %= queueMaxSize; // Front wordt weer 0 als hij het einde van de array bereikt.
            return item;
        }

        public void makeEmpty() {
            for(int i = 0; i < queueMaxSize; i++) {
                queue[i] = default(T); // Zet elk element van de array op de default waarde (0, null, w/e)
            }
            front = back = queueSize = 0; // Reset alle posities
        }

        private void DoubleQueue() {
            T[] temp = new T[queueMaxSize * 2]; // Verdubbel de grootte
            for(int i = 0; i < queueMaxSize; i++) {
                temp[i] = queue[(i+back)%queueMaxSize]; // Vul de nieuwe array zo, dat de front vooraan staat en de back achteraan.
            }
            back = queueMaxSize;
            front = 0;
            queueMaxSize *= 2;
            queue = temp;
        }
    }
}
