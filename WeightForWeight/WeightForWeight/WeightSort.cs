using System;
using System.Collections.Generic;
using System.Text;

namespace WeightForWeight
{
    public class WeightSort
    {
        public static string OrderWeight(string strng)
        {
            strng = strng.Trim();
            List<int> removalSpots = new List<int>();

            for (int i = 0; i < strng.Length - 1; i++)
            {
                if (strng[i] == ' ' && strng[i + 1] == ' ')
                {
                    removalSpots.Add(i);
                }
            }

            foreach(int x in removalSpots)
            {
                strng = strng.Remove(x, 1);
            }

            string[] weightBucket = strng.Split(' ');
            int[] weightsWeight = new int[weightBucket.Length];
            int counter = 0;
            foreach(string s in weightBucket)
            {
                int amount = 0;
                foreach (char c in s)
                {
                    amount += Int32.Parse(c.ToString());
                }
                weightsWeight[counter] = amount;
                counter++;
            }

            SelectionSort(weightBucket, weightsWeight);
            SortSameWeight(weightBucket, weightsWeight);

            return string.Join(' ', weightBucket);
        }
        private static void SelectionSort(string[] weightBucket, int[] weightsWeight)
        {
            int leastInput = 0;

            for (int i = 0; i < weightsWeight.Length; i++)
            {
                leastInput = i;

                for (int j = i + 1; j < weightsWeight.Length; j++)
                {
                    if (weightsWeight[j].CompareTo(weightsWeight[leastInput]) < 0)
                    {
                        leastInput = j;
                    }
                }
                int tempObject = weightsWeight[i];
                weightsWeight[i] = weightsWeight[leastInput];
                weightsWeight[leastInput] = tempObject;

                string tempObjectWeight = weightBucket[i];
                weightBucket[i] = weightBucket[leastInput];
                weightBucket[leastInput] = tempObjectWeight;
            }
        }

        private static void SortSameWeight(string[] weightBucket, int[] weightsWeight)
        {
            //bool done = false;
            //while (!done)
            //{
            //    int counter = 0;
            //    done = true;
            //    while (counter < inputArray.Length - 1)
            //    {
            //        if (inputArray[counter + 1].CompareTo(inputArray[counter]) > 0)
            //        {
            //            T tempObject = inputArray[counter + 1];
            //            inputArray[counter + 1] = inputArray[counter];
            //            inputArray[counter] = tempObject;
            //            done = false;
            //        }
            //        else
            //        {
            //            counter++;
            //        }
            //    }
            //}

            bool done = false;
            while (!done)
            {
                done = true;

                for (int i = 0; i < weightsWeight.Length - 1; i++)
                {
                    if (weightsWeight[i] == weightsWeight[i + 1] && weightBucket[i] != weightBucket[i + 1])
                    {
                        for (int j = 0; j <= weightBucket[i].Length - 1 && j <= weightBucket[i + 1].Length - 1; j++)
                        {
                            if (weightBucket[i][j] > weightBucket[i + 1][j])
                            {
                                SortSameWeight(weightBucket, i);
                                done = false;
                            }
                            else if (weightBucket[i][j] == weightBucket[i + 1][j])
                            {
                                if (weightBucket[i].Length > 1)
                                {
                                    if(int.Parse(weightBucket[i][j + 1].ToString()) == 0)
                                    {
                                        SortSameWeight(weightBucket, i);
                                        done = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //for (int i = 0; i < weightsWeight.Length - 1; i++)
            //{
            //    if (weightsWeight[i] == weightsWeight[i + 1] && weightBucket[i] != weightBucket[i + 1])
            //    {
            //        for (int j = 0; j <= weightBucket[i].Length - 1 && j <= weightBucket[i + 1].Length - 1; j++)
            //        {
            //            if (weightBucket[i][j] > weightBucket[i + 1][j])
            //            {
            //                string tempObjectWeight = weightBucket[i];
            //                weightBucket[i] = weightBucket[i + 1];
            //                weightBucket[i + 1] = tempObjectWeight;
            //                i--;
            //                break;
            //            }
            //            else if (weightBucket[i][j] == weightBucket[i + 1][j])
            //            {
            //                if (int.Parse(weightBucket[i][j + 1].ToString()) == 0 || int.Parse(weightBucket[i + 1][j + 1].ToString()) == 0)
            //                {
            //                    string tempObjectWeight = weightBucket[i];
            //                    weightBucket[i] = weightBucket[i + 1];
            //                    weightBucket[i + 1] = tempObjectWeight;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private static void SortSameWeight(string[] weightBucket, int i)
        {
            string tempObjectWeight = weightBucket[i];
            weightBucket[i] = weightBucket[i + 1];
            weightBucket[i + 1] = tempObjectWeight;
        }
    }
}
