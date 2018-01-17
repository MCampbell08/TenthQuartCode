using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLibrary
{
    public class Sorter<T>
    {
        public static void BubbleSort(IComparable<T>[] inputArray)
        {
            bool done = false;
            int counter = 0;
            T objectT = inputArray[counter];
            int choice = inputArray[counter + 1].CompareTo(inputArray[counter]);
            while (!done)
            {
                if (inputArray[counter + 1].CompareTo(inputArray[counter]))
                {

                }
                else
                {

                }
            }
        }
        public static void SelectionSort(IComparable<T>[] inputArray)
        {

        }
        public static void InsertionSort(IComparable<T>[] inputArray)
        {

        }
    }
}
