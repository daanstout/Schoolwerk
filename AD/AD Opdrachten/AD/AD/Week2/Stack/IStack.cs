using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week2.Stack {
    public interface IStack<T> {
        void Push(T data);
        T Pop();
        T Top();
    }
}
