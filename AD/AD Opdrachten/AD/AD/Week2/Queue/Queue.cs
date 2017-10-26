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
            front = back = queueSize = 0;
        }

        public void Enqueue(T item) {
            if (queueSize == queueMaxSize)
                DoubleQueue();
            queue[back] = item;
            back++;
            queueSize++;
            back %= queueMaxSize;
        }

        public T Dequeue() {
            T item = queue[front];
            queue[front] = default(T);
            queueSize--;
            front++;
            front %= queueMaxSize;
            return item;
        }

        public void makeEmpty() {
            for(int i = 0; i < queueMaxSize; i++) {
                queue[i] = default(T);
            }

            front = back = queueSize = 0;
        }

        private void DoubleQueue() {
            T[] temp = new T[queueMaxSize * 2];
            for(int i = 0; i < queueMaxSize; i++) {
                temp[i] = queue[(i+back)%queueMaxSize];
            }
            back = queueMaxSize;
            front = 0;
            queueMaxSize *= 2;
            queue = temp;
        }
    }
}
