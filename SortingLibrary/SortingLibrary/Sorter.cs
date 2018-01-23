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
                done = true;
                while (counter < inputArray.Length - 1)
                {
                    if (inputArray[counter + 1].CompareTo(inputArray[counter]) > 0)
                    {
                        T tempObject = inputArray[counter + 1];
                        inputArray[counter + 1] = inputArray[counter];
                        inputArray[counter] = tempObject;
                        done = false;
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
            int leastInput = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                leastInput = i;

                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j].CompareTo(inputArray[leastInput]) < 0)
                    {
                        leastInput = j;
                    }
                }
                T tempObject = inputArray[i];
                inputArray[i] = inputArray[leastInput];
                inputArray[leastInput] = tempObject;
            }
        }
        public static void InsertionSort(T[] inputArray)
        {
            int previousInputLoc = 0;
            T temp = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                temp = inputArray[i];
                previousInputLoc = i - 1;

                while (previousInputLoc >= 0 && inputArray[previousInputLoc].CompareTo(temp) > 0)
                {
                    inputArray[previousInputLoc + 1] = inputArray[previousInputLoc];
                    previousInputLoc--;
                }
                inputArray[previousInputLoc + 1] = temp;
            }
        }
    }
}
