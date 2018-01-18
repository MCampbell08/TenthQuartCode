using System;
using System.Collections.Generic;
using System.Text;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable
    {
        public static void BubbleSort(T[] inputArray)
        {
            bool done = false;
            while (!done) {
                int counter = 0;
                T objectT = inputArray[counter];
                int choice = inputArray[counter + 1].CompareTo(inputArray[counter]);
                while (counter < inputArray.Length - 1)
                {
                    if (inputArray[counter + 1].CompareTo(inputArray[counter]) > 0)
                    {
                        T tempObject = inputArray[counter + 1];
                        inputArray[counter + 1] = inputArray[counter];
                        inputArray[counter] = tempObject;

                    }
                    else
                    {
                        counter++; 
                    }
                }
            }
        }
        public static void SelectionSort(T[] inputArray)
        {

        }
        public static void InsertionSort(T[] inputArray)
        {

        }
    }
}
