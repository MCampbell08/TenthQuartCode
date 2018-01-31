using System;
using System.Diagnostics;

namespace WeightForWeight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string weights = "1 200 2 4 4 6 6 7 7 9 27 18 72 81 91 425 31064 7920 67407";

            weights = WeightSort.OrderWeight(weights);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(weights);
        }
    }
}
