using System;

namespace L1_Isomorphic_Strings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "";
            Console.Write("Please specify a file path to check: ");
            
            while (!System.IO.Directory.Exists(filePath = Console.ReadLine()))
            {
                Console.Write("Try again: ");
            }
            IsomorphicController isomorphicController = new IsomorphicController(filePath);
            isomorphicController.FindIsomorphs();
        }
    }
}
