using System;
using AlgoDataStructures;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgoDataStructures.BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();

            binarySearchTree.Add(2);
            binarySearchTree.Add(9);
            binarySearchTree.Add(1);
            binarySearchTree.Add(4);
            binarySearchTree.Add(-20);

            if (binarySearchTree.Contains(-4))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

            binarySearchTree.Remove(9);
            binarySearchTree.Clear();

            binarySearchTree.Add(2);
            binarySearchTree.Add(9);
            binarySearchTree.Add(1);
            binarySearchTree.Add(4);
            binarySearchTree.Add(-20);

            Console.WriteLine(binarySearchTree.Count);

            Console.WriteLine(binarySearchTree.Height());
        }
    }
}
