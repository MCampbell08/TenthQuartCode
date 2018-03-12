using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIntoSquares
{
    class Program
    {
        public static void Main(string[] args)
        {
            Decompose(11);
        }

        public static string Decompose(long n)
        {
            List<long> decomposedArray = DecomposeRecursive(n, n * n);

            if (decomposedArray == null)
                return "";

            decomposedArray.Remove(decomposedArray.Count);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (long l in decomposedArray)
                stringBuilder.Append(l.ToString() + " ");

            return stringBuilder.ToString();
        }
        private static List<long> DecomposeRecursive(long n, long remainder)
        {
            if(remainder == 0)
                return new List<long>() { n };

            for(long i = n - 1; i > 0; i--)
            {
                if((remainder - i * i) >= 0)
                {
                    List<long> recursedList = DecomposeRecursive(i, (remainder - i * i));

                    if (recursedList != null)
                    {
                        recursedList.Add(n);
                        return recursedList;
                    }
                }
            }
            return null;
        }
    }
}
