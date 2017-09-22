using BinarySearchTree.Integer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree {
    class Program {
        static void Main(string[] args) {
            BinaryTree tree = new BinaryTree(new Node(5));
            tree.addNode(new Node(3));
            tree.addNode(new Node(4));
            tree.addNode(new Node(7));
            tree.addNode(new Node(10));


            tree.inPrintTree();



            Console.ReadKey();
        }
    }
}
