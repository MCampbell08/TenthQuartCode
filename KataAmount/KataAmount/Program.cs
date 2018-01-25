using System;
using System.Collections.Generic;

namespace KataAmount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<long> list = JohnAnn.Ann(15);

            foreach(long l in list)
            {
                Console.Write(l + ", ");
            }
        }
    }
}
