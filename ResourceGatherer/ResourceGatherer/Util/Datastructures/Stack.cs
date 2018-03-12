using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util.Datastructures {
    /// <summary>
    /// A self written generic Stack
    /// </summary>
    /// <typeparam name="T">The class to be stored in the stack</typeparam>
    public class Stack<T> {
        /// <summary>
        /// The current stack
        /// </summary>
        T[] stack;
        /// <summary>
        /// Some data to make things easier
        /// </summary>
        int top, maxStackSize, stackSize;

        /// <summary>
        /// Checks whether the stack is empty
        /// </summary>
        public bool isEmpty {
            get {
                return stackSize == 0;
            }
        }

        /// <summary>
        /// Creates a new stack with a size of 5
        /// </summary>
        public Stack() : this(5) { }

        /// <summary>
        /// Creates a new stack
        /// </summary>
        /// <param name="size">The size of the stack</param>
        public Stack(int size) {
            maxStackSize = size;
            stack = new T[maxStackSize];
            top = stackSize = 0;
        }

        /// <summary>
        /// Returns the top most item
        /// </summary>
        /// <returns>The object on the top</returns>
        public T Pop() {
            if (stackSize == 0)
                return default(T);
            top = stackSize -= 1;
            return stack[top + 1];
        }

        /// <summary>
        /// Pushes a new object to the stack
        /// </summary>
        /// <param name="data">The object to be pushed</param>
        public void Push(T data) {
            if (stackSize == maxStackSize)
                DoubleStack();
            top = stackSize += 1;
            stack[top] = data;
        }

        /// <summary>
        /// Returns the topmost object without removing it. If you want it to be removed from the stack as well, use Pop()
        /// </summary>
        /// <returns>The object on the top</returns>
        public T Top() {
            return stack[top];
        }

        /// <summary>
        /// Doubles the current stack
        /// </summary>
        private void DoubleStack() {
            T[] temp = new T[maxStackSize * 2];
            for (int i = 0; i < maxStackSize; i++)
                temp[i] = stack[i];
            maxStackSize *= 2;
            stack = temp;
        }
    }
}
