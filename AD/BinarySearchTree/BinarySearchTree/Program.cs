using BinarySearchTree.BinaryTree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree {
    class Program {
        static void Main(string[] args) {
            BinaryTree<int> tree = new BinaryTree<int>(new Node<int>(5));
            tree.insert(new Node<int>(3));
            //tree.addNode(new Node<int>(4));
            //tree.addNode(new Node<int>(7));
            //tree.addNode(new Node<int>(10));
            //tree.inPrintTree();
            Console.WriteLine();
            //tree.RemoveAllNode(7);


            //tree.inPrintTree();



            Console.ReadKey();
        }
    }
}
