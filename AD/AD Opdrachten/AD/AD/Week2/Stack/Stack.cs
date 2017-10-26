using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week2.Stack {
    public class Stack<T> : IStack<T> {
        T[] stack;
        int top, maxStackSize, stackSize;

        public Stack() {
            maxStackSize = 5;
            stack = new T[maxStackSize];
            top = stackSize = 0;
        }

        public T Pop() {
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
