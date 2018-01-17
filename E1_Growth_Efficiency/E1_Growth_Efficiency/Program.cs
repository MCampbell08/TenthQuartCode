using System;

namespace E1_Growth_Efficiency
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 6, 15, 20, 1, 9 };

            int min = array[0];
            int max = array[0];
            int average = 0;


            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
                if (array[i] > max)
                    max = array[i];

                average += array[i];
            }
            
            Console.WriteLine("Min: {0}, Max: {1}, Average: {2}", min, max, average / array.Length);
        }
    }
}
