using System;
using SortingLibrary;

namespace SorterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = new int[] { 0, 45, 7, 4};
            Sorter<Int32>.BubbleSort(number);
        }
    }
}
