using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution(356));
        }

        public static string Solution(int n)
        {
            string[] romanNumerals = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            int[] romanNumeralInts = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

            StringBuilder result = new StringBuilder();

            while (n > 0)
            {
                for (int i = romanNumeralInts.Length - 1; i >= 0; i--)
                {
                    string romanNumeral = romanNumerals[i];
                    int romanNumeralInt = romanNumeralInts[i];

                    if (n >= romanNumeralInt)
                    {
                        result.Append(romanNumeral);
                        n -= romanNumeralInt;
                        break;
                    }
                }
            }

            return result.ToString();
        }
    }
}
