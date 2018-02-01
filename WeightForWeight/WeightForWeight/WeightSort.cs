using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WeightForWeight
{
    public class WeightSort
    {
        public static string OrderWeight(string strng)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            strng = regex.Replace(strng, " ");

            string[] weightBucket = strng.Split(' ');
            int[] weightsWeight = new int[weightBucket.Length];


            int counter = 0;

            foreach(string s in weightBucket)
            {
                var result = s.Select(x => int.Parse(x.ToString())).Sum();
                weightsWeight[counter] = result;
                counter++;
            }
            
            InsertionSort(weightBucket, weightsWeight);
            SortSameWeight(weightBucket, weightsWeight);

            return string.Join(' ', weightBucket);
        }
        public static void InsertionSort(string[] weightBucket, int[] weightsWeight)
        {
            int previousInputLoc = 0;
            string temp = weightBucket[0];
            int tempWeight = weightsWeight[0];

            for (int i = 1; i < weightsWeight.Length; i++)
            {
                temp = weightBucket[i];
                tempWeight = weightsWeight[i];
                previousInputLoc = i - 1;

                while (previousInputLoc >= 0 && weightsWeight[previousInputLoc].CompareTo(tempWeight) > 0)
                {
                    weightsWeight[previousInputLoc + 1] = weightsWeight[previousInputLoc];
                    weightBucket[previousInputLoc + 1] = weightBucket[previousInputLoc];
                    previousInputLoc--;
                }
                weightBucket[previousInputLoc + 1] = temp;
                weightsWeight[previousInputLoc + 1] = tempWeight;
            }
        }
        private static void SortSameWeight(string[] weightBucket, int[] weightsWeight)
        {
            int counter = 0;
            bool done = false;
            while (!done)
            {
                done = true;
                for (int i = 0; i < weightsWeight.Length - 1; i++)
                {
                    if (weightsWeight[i] == weightsWeight[i + 1] && weightBucket[i] != weightBucket[i + 1])
                    {
                        counter = 0;
                        while (counter < 2 && (counter <= weightBucket[i].Length / 2 && counter <= weightBucket[i + 1].Length / 2))
                        {
                            if (weightBucket[i][0] < weightBucket[i + 1][0])
                                break;
                            if ((weightBucket[i][counter] == weightBucket[i + 1][counter] && weightBucket[i].Length > 1 && int.Parse(weightBucket[i][counter + 1].ToString()) == 0) || weightBucket[i][counter] > weightBucket[i + 1][counter])
                            {
                                SwitchWeights(weightBucket, i);
                                done = false;
                            }
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine("Hello");
        }

        private static void SwitchWeights(string[] weightBucket, int i)
        {
            string tempObjectWeight = weightBucket[i];
            weightBucket[i] = weightBucket[i + 1];
            weightBucket[i + 1] = tempObjectWeight;
        }
    }
}
