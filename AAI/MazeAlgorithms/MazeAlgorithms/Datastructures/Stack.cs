using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Datastructures {
    public class Stack<T> {
        T[] stack;
        int top, maxStackSize, stackSize;

        public bool isEmpty {
            get {
                return stackSize == 0;
            }
        }

        public Stack() : this(5) { }

        public Stack(int size) {
            maxStackSize = size;
            stack = new T[maxStackSize];
            top = stackSize = 0;
        }

        public T Pop() {
            if (stackSize == 0)
                return default(T);
            top = stackSize -= 1;
            return stack[top + 1];
        }

        public void Push(T data) {
            if (stackSize == maxStackSize)
                DoubleStack();
            top = stackSize += 1;
            stack[top] = data;
        }

        public T Top() {
            return stack[top];
        }

        private void DoubleStack() {
            T[] temp = new T[maxStackSize * 2];
            for (int i = 0; i < maxStackSize; i++)
                temp[i] = stack[i];
            maxStackSize *= 2;
            stack = temp;
        }
    }
}
