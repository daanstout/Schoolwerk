using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week4.FCNS {
    public class FCNSNode<T> {
        public T value;             // This is the value
        public FCNSNode<T> child;   // This is the child
        public FCNSNode<T> sibling; // This is the sibling

        public FCNSNode(T value, FCNSNode<T> child, FCNSNode<T> sibling) {      // Basic constructor 
            this.value = value;
            this.child = child;
            this.sibling = sibling;
        }
    }
}
