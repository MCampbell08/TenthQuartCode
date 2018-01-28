using System;

namespace WeightForWeight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string weights = "103  123 4444 99 2000";

            weights = WeightSort.OrderWeight(weights);
        }
    }
}
