using System;
using System.Collections.Generic;
using System.Text;

namespace KataAmount
{
    public class JohnAnn
    {
        public static List<long> John(long n)
        {
            List<long> kataList = KataList(n, true);

            return kataList;
        }
        public static List<long> Ann(long n)
        {
            List<long> kataList = KataList(n, false);

            return kataList;
        }
        private static List<long> KataList(long n, bool isJohn)
        {
            List<long> johnList = new List<long> { 0 };
            List<long> annList = new List<long> { 1 };

            for (int i = 1; i < n; i++)
            {
                johnList.Add(i - annList[(int)johnList[i - 1]]);
                annList.Add(i - johnList[(int)annList[i - 1]]);
            }            

            return (isJohn) ? johnList : annList;
        }
        public static long SumJohn(long n)
        {
            long sumOfKatas = 0;

            return sumOfKatas;
        }
        public static long SumAnn(long n)
        {
            long sumOfKatas = 0;

            foreach (long l in Ann(n))
            {
                sumOfKatas += l;
            }
            
            return sumOfKatas;
        }
    }  
}
