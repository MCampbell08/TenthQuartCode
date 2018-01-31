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
        public static void MergeSort(T[] inputArray)
        {
            MergeSplitter(inputArray, 0, inputArray.Length - 1);
        }
        private static void MergeSplitter(T[] inputArray, int left, int right)
        {
            if (right > left)
            {
                int mid = (right + left) / 2;

                MergeSplitter(inputArray, left, mid);
                MergeSplitter(inputArray, (mid + 1), right);

                Merge(inputArray, left, (mid + 1), right);
            }
        }
        private static void Merge(T[] inputArray, int leftPos, int midPos, int rightPos)
        {
            T[] temp = new T[inputArray.Length];

            int leftEnd = (midPos - 1); ;
            int numOfElem = (rightPos - leftPos + 1);
            int tempPos = leftPos;

            while ((leftPos <= leftEnd) && (midPos <= rightPos))
            {
                if (inputArray[leftPos].CompareTo(inputArray[midPos]) < 0)
                    temp[tempPos++] = inputArray[leftPos++];
                else
                    temp[tempPos++] = inputArray[midPos++];
            }

            while (leftPos <= leftEnd)
                temp[tempPos++] = inputArray[leftPos++];

            while (midPos <= rightPos)
                temp[tempPos++] = inputArray[midPos++];

            for (int i = 0; i < numOfElem; i++)
            {
                inputArray[rightPos] = temp[rightPos];
                rightPos--;
            }
        }
        public static void QuickSort(T[] inputArray)
        {
            SortPivot(inputArray, 0, inputArray.Length - 1);
        }
        private static void SortPivot(T[] inputArray, int left, int right){
            int leftTempPos = left;
            int rightTempPos = right;

            T pivotPoint = inputArray[(leftTempPos + rightTempPos) / 2];

            while (leftTempPos <= rightTempPos)
            {
                while (inputArray[leftTempPos].CompareTo(pivotPoint) < 0)
                    leftTempPos++;

                while (inputArray[rightTempPos].CompareTo(pivotPoint) > 0)
                    rightTempPos--;

                if (leftTempPos <= rightTempPos)
                {
                    T tempObject = inputArray[leftTempPos];
                    inputArray[leftTempPos] = inputArray[rightTempPos];
                    inputArray[rightTempPos] = tempObject;

                    leftTempPos++; rightTempPos--;
                }

                if (left < rightTempPos)
                    SortPivot(inputArray, left, rightTempPos);

                if (right > leftTempPos)
                    SortPivot(inputArray, leftTempPos, right);
            }
        }
    }
}
