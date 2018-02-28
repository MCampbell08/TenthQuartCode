using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoDataStructures;

namespace TestTheLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<string> list1 = new SingleLinkedList<string>();
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            BinarySearchTree<int> searchTree = new BinarySearchTree<int>();

            searchTree.Add(10);
            searchTree.Add(3);
            searchTree.Add(15);
            searchTree.Add(2);
            searchTree.Add(1);

            Console.WriteLine(searchTree.ToString());
            Console.WriteLine();
            Console.WriteLine(searchTree.Height());
            Console.WriteLine();
            Console.WriteLine("Here");
            Console.WriteLine(searchTree.InOrder());
            Console.WriteLine();

            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");
            list.Add("F");
            list.Add("G");
            list.Add("H");

            Console.WriteLine(list.ToString());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Deleting index 7");
            Console.WriteLine(list.RemoveAt(7));
            Console.WriteLine(list.ToString());

            Console.WriteLine();
            Console.WriteLine("Position 5: " + list.Get(5));

            Console.WriteLine();
            Console.WriteLine("Deleting node 5");
            Console.WriteLine(list.RemoveAt(5));

            Console.WriteLine();
            Console.WriteLine("Position 5: " + list.Get(5));

            Console.WriteLine();
            Console.WriteLine(list.ToString());


            Console.WriteLine();
            Console.WriteLine(list.Search("A"));

            Console.WriteLine();
            list.Insert("X", 0);

            Console.WriteLine();
            Console.WriteLine(list.ToString());

            Console.WriteLine();
            Console.WriteLine(list.Get(0));
        }
    }
}
