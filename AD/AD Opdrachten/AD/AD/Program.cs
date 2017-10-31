using AD.Week2.LinkedList;
using AD.Week2.Queue;
using AD.Week4.Binary;
using AD.Week4.FCNS;
using AD.Week5.BinaryTree;
using AD.Week5.BinaryHeap;
using AD.Week6.Graven;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AD {
    class Program {
        static void Main(string[] args) {
            //FCNS();
            //Binary();
            //BinarySearch();
            //BinaryHeap();
            //Graph();
            //LinkedList();
            //Q();
            //Stack();





            Console.ReadKey();
        }

        public static void FCNS() { // First Child Next Sibling. Children weten niet wie hun parent is, siblings weten niet wie hun vorige sibling is
            FCNSTree<char> tree = new FCNSTree<char>(null);

            FCNSNode<char> A = new FCNSNode<char>('A', null, null);
            FCNSNode<char> B = new FCNSNode<char>('B', null, null);
            FCNSNode<char> C = new FCNSNode<char>('C', null, null);
            FCNSNode<char> D = new FCNSNode<char>('D', null, null);
            FCNSNode<char> E = new FCNSNode<char>('E', null, null);
            FCNSNode<char> F = new FCNSNode<char>('F', null, null);
            FCNSNode<char> G = new FCNSNode<char>('G', null, null);
            FCNSNode<char> H = new FCNSNode<char>('H', null, null);
            FCNSNode<char> I = new FCNSNode<char>('I', null, null);
            FCNSNode<char> J = new FCNSNode<char>('J', null, null);
            FCNSNode<char> K = new FCNSNode<char>('K', null, null);

            tree.root = A;
            A.child = B;
            B.child = F;
            F.sibling = G;
            B.sibling = C;
            C.sibling = D;
            D.child = H;
            D.sibling = E;
            E.child = I;
            I.sibling = J;
            J.child = K;

            Console.WriteLine(tree.Size());
            tree.PrintPreOrder();
        }

        public static void Binary() { // Binary tree, elke node heeft maximaal 2 children. Volgorde maakt niet uit.
            BinaryTree<int> tree = new BinaryTree<int>(null);

            BinaryNode<int> a = new BinaryNode<int>(1, null, null);
            BinaryNode<int> b = new BinaryNode<int>(2, null, null);
            BinaryNode<int> c = new BinaryNode<int>(3, null, null);
            BinaryNode<int> d = new BinaryNode<int>(4, null, null);
            BinaryNode<int> e = new BinaryNode<int>(5, null, null);
            BinaryNode<int> f = new BinaryNode<int>(6, null, null);
            BinaryNode<int> g = new BinaryNode<int>(7, null, null);
            BinaryNode<int> h = new BinaryNode<int>(8, null, null);
            BinaryNode<int> i = new BinaryNode<int>(9, null, null);
            BinaryNode<int> j = new BinaryNode<int>(10, null, null);

            tree.root = f;
            f.left = b;
            f.right = g;
            b.left = a;
            b.right = e;
            g.right = i;
            e.left = d;
            i.left = h;
            i.right = j;
            d.left = c;

            Console.WriteLine(tree.Size());
            Console.WriteLine(tree.Height());
            tree.PrintPreOrder();
            tree.PrintInOrder();
            tree.PrintPostOrder();
            Console.WriteLine(tree.getLeaves());
            Console.WriteLine(tree.getSingleChilds());
            Console.WriteLine(tree.getDualChilds());

            BinaryTree<int> tree2 = new BinaryTree<int>(null);

            tree2.addNode(new BinaryNode<int>(4, null, null));
            tree2.addNode(new BinaryNode<int>(2, null, null));
            tree2.addNode(new BinaryNode<int>(1, null, null));
            tree2.addNode(new BinaryNode<int>(3, null, null));
            tree2.addNode(new BinaryNode<int>(6, null, null));

            Console.WriteLine(tree2);
        }

        public static void BinarySearch() { // Binary Search Tree, zoals de Binary Tree, maar waardes kleiner dan de parent komen links, en groter komen rechts
            BinarySearchTree tree = new BinarySearchTree(null);

            Console.WriteLine(tree);
            tree.Insert(6);
            Console.WriteLine(tree);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(7);
            
            Console.WriteLine(tree.FindMin());
            Console.WriteLine(tree);
            Console.WriteLine(tree.InOrder());
            tree.RemoveMin();
            Console.WriteLine(tree);
        }

        public static void BinaryHeap() { // Binary Heap (ints), de root is altijd de laagste waarde.
            BinaryHeap heap = new BinaryHeap();
            heap.add(1);
            heap.add(2);
            heap.add(3);
            heap.add(4);
            heap.add(5);
            heap.add(6);
            heap.add(2);
            Console.WriteLine(heap.FindMin());
            heap.printPreOrder();
        }

        public static void Graph() {
            Graph graph = new Graph();

            graph.AddEdge("V0", "V1", 2);
            graph.AddEdge("V0", "V3", 1);
            graph.AddEdge("V1", "V3", 3);
            graph.AddEdge("V1", "V4", 10);
            graph.AddEdge("V2", "V0", 4);
            graph.AddEdge("V2", "V5", 5);
            graph.AddEdge("V3", "V4", 2);
            graph.AddEdge("V3", "V6", 4);
            graph.AddEdge("V3", "V5", 8);
            graph.AddEdge("V3", "V2", 2);
            graph.AddEdge("V4", "V6", 6);
            graph.AddEdge("V6", "V5", 1);

            Console.WriteLine(graph);
        }

        public static void LinkedList() {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            list.addFirst(5);
            list.addFirst(4);
            list.addFirst(3);
            list.print();
            list.insert(2, 7);
            Console.WriteLine();
            list.print();
            list.insert(0, 10);
            Console.WriteLine();
            list.print();
            Console.WriteLine();
            Console.WriteLine(list.getFirst());
            list.removeFirst();
            Console.WriteLine();
            list.print();
        }

        public static void Q() {
            Week2.Queue.Queue<int> Q = new Week2.Queue.Queue<int>();
            Q.Enqueue(4);
            Q.Enqueue(5);
            Q.Enqueue(10);
            Q.Enqueue(2);
            Console.WriteLine(Q.Dequeue());
            Console.WriteLine(Q.Dequeue());
            Q.makeEmpty();
            Q.Enqueue(1);
            Console.WriteLine(Q.Dequeue());
        }

        public static void Stack() {
            Week2.Stack.Stack<int> stack = new Week2.Stack.Stack<int>();
            stack.Push(3);
            stack.Push(10);
            stack.Push(11);
            Console.WriteLine(stack.Top());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Top());
        }
    }
}
