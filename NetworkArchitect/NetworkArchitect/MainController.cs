using NetworkArchitect.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class MainController
    {
        public void ReadFile()
        {
            Console.Write("Please enter a file location for NetworkArchitect: ");
            string fileLocation = Console.ReadLine(), line = "";

            fileLocation = FileUtility.CheckFileLocation(fileLocation);

            StreamReader stream = new StreamReader(fileLocation);
            Regex r = new Regex("^[a-zA-Z0-9]*$");

            for (int i = 0; (line = stream.ReadLine()) != null; i++)
            {
                if(i == 0 && r.IsMatch(line))

                if (i == 0 &&) //Sockets
                {

                }
            }
        }
    }
}
