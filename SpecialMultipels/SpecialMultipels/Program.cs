using System;

namespace SpecialMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            CountSpecMult(2, 100);
        }

        public static long CountSpecMult(long n, long mxval)
        {
            int count = 1;
            long prime = 1;

            for (int i = 2; count <= n; i++)
            {
                if (IsPrime(i))
                {
                    prime *= i;
                    count++;
                }
            }

            return (int)Math.Floor((double)(mxval / prime));
        }
        public static bool IsPrime(long n)
        {
            if (n == 2)
                return true;
            else if (n % 2 == 0)
                return false;

            for (long i = 3; i <= Math.Sqrt(n) + 1; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
