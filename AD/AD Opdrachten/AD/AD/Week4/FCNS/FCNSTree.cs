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
            // Prints the tree in PreOrder ( Self, left, right)
            Console.Write("[ ");
            PrintPreOrder(root);
            Console.WriteLine("]");
        }

        private void PrintPreOrder(FCNSNode<T> node) { // Pre-order: Self, Links, Rechts
            if (node == null)   // If the node is null, we stop here
                return;
            else {  // Else, we print the value and do PrintPreOrder for the child and sibling, if they are null, they get caught in their function
                Console.Write(node.value + " "); // self..
                PrintPreOrder(node.child);       // linker child is altijd de child v/d FCNS
                PrintPreOrder(node.sibling);     // rechter child is altijd de sibling v/d FCNS
            }
        }

        public int Size() {
            return Size(root);
        }

        private int Size(FCNSNode<T> node) { // Size: Aantal nodes in de tree
            if (node == null)
                return 0; // Return 0 als een node niet bestaat.
            else {
                return 1 + Size(node.child) + Size(node.sibling); // Return 1 als een node wél bestaat, en check of er children zijn
            }
        }
    }
}
