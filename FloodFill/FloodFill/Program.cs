using System;

namespace FloodFill
{
    class Program
    {
        static void Main(string[] args)
        {
            var actual = new int[,]
            {
                {1, 2, 3 },
                {1, 2, 2 },
                {2, 3, 2 }
            };
            var expected = new int[,]
                {{1,4,3},
                {1,4,4},
                {2,3,4}};
            Kata.FloodFill(actual, 0, 1, 4);

        }
    }
}
