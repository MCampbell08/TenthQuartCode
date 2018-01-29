using System;

namespace SorterController
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] inputArray = new int[] { 6, 19, 3, 65, 0, 2};

            SortingLibrary.Sorter<int>.BubbleSort(inputArray);
            
            Console.WriteLine(string.Join(',', inputArray));
        }
    }
}
