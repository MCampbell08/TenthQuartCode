using System;
using AlgoDataStrucutres;

namespace AlgoDataProjectTester
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();


            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Insert(5, 4);

            int num = list.Get(5);

            num = list.RemoveLast();

            num = list.Search(7);

            list.Clear();
            Console.WriteLine(list.ToString());
        }
    }
}
