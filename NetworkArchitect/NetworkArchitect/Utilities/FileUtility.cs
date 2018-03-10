using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Utility
{
    public class FileUtility
    {
        public static string CheckFileLocation(string fileLocation)
        {
            while (!File.Exists(fileLocation))
            {
                Console.Write("Please enter a VALID file location for MazeSolver: ");
                fileLocation = Console.ReadLine();
            }

            return fileLocation;
        }
    }
}
