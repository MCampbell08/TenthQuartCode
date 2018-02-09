using System;

namespace SpecialMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountSpecMult(0, 30);
        }

        public static long CountSpecMult(long n, long mxval)
        {
            long finalResult = 0;
            int counter = 1;

            bool[] array = new bool[mxval];
            for (int i = 0; i < array.Length - 1; i++)
                array[i] = true;

            for (int i = 2; i < Math.Sqrt(mxval); i++)
            {
                array[i] = true;
                int tempNum = counter * i;
                for (int j = (i*i); j < mxval; j+=tempNum)
                {
                    array[j] = false;
                    counter++;
                }
            }
            for(int num = 0; num < array.Length - 1; num++)
            {
                if (array[num]) {
                    Console.Write(num + ", ");
                }
            }

            return finalResult;
        }
    }
}
