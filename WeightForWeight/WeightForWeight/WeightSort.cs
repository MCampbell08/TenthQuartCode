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
            List<int> weightsWeight = new List<int>();

            foreach(string s in weightBucket)
            {
                int amount = 0;
                foreach (char c in s)
                {
                    amount += Int32.Parse(c.ToString());
                }
                weightsWeight.Add(amount);
            }

            for (int i = 0; i < weightBucket.Length - 1; i++)
            {
                weightsWeight.Sort();
            }

            return null;
        }
    }
}
