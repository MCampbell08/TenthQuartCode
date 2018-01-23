using System;
using System.Collections.Generic;
using System.Text;

namespace KataAmount
{
    public class JohnAnn
    {
        public static List<long> John(long n)
        {
            List<long> kataList = new List<long>();

            for (int i = 0; i <= n; i++)
            {
                if (i <= 1) { 
                    kataList.Add(0);
                }
                else
                    kataList.Add(i - kataList[i] - 1);
            }

            return kataList;
        }
        public static List<long> Ann(long n)
        {
            List<long> kataList = new List<long>();

            for (int i = 1; i <= n;  i++)
            {
                if (i == 1)
                    kataList.Add(i);
                else
                    kataList.Add(i - kataList[i - 2]);
            }

            return kataList;
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
