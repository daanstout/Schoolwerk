using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week4.FCNS {
    public class FCNSTree<T> : IFCNSTree<T> {
        public FCNSNode<T> root;

        public FCNSTree(FCNSNode<T> root) {
            this.root = root;
        }


        public void PrintPreOrder() {
            // Prints the tree in PreOrder
            Console.Write("[ ");
            PrintPreOrder(root);
            Console.WriteLine("]");
        }

        private void PrintPreOrder(FCNSNode<T> node) {
            if (node == null)   // If the node is null, we stop here
                return;
            else {  // Else, we print the value and do PrintPreOrder for the child and sibling, if they are null, they get caught in their function
                Console.Write(node.value + " ");
                PrintPreOrder(node.child);
                PrintPreOrder(node.sibling);
            }
        }

        public int Size() {
            return Size(root);
        }

        private int Size(FCNSNode<T> node) {
            if (node == null)
                return 0;
            else {
                return 1 + Size(node.child) + Size(node.sibling);
            }
        }
    }
}
