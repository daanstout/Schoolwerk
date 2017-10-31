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

        public T Pop() { // Pop: Verwijder het bovenste element van de stack
            top = stackSize -= 1; // Set de top op het element ónder de top. De oude top wordt vanzelf verwijderd door de Garbage Collector
            return stack[top + 1]; // Return het element boven de nieuwe top.
        }

        public void Push(T data) {
            if (stackSize == maxStackSize) // Als de array vol is, verdubbel dan de grootte
                DoubleStack();
            top = stackSize += 1; // Vergroot de index met 1
            stack[top] = data; // Zet de data op deze index
        }

        public T Top() {
            return stack[top];
        }

        private void DoubleStack() {
            T[] temp = new T[maxStackSize * 2]; // Nieuwe lege array, 2x zo groot
            for (int i = 0; i < maxStackSize; i++)
                temp[i] = stack[i]; // Vul de array
            maxStackSize *= 2;
            stack = temp; // Vervang de oude array
        }
    }
}
