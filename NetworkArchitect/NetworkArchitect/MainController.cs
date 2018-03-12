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
        private List<Socket> mainSockets = new List<Socket>();
        private List<Tuple<Socket, Tuple<Socket, int>>> socketConnection = new List<Tuple<Socket, Tuple<Socket, int>>>();
        private Regex r = new Regex("^[a-zA-Z0-9]+$");
        public void ReadFile()
        {
            Console.Write("Please enter a file location for NetworkArchitect: ");
            string fileLocation = Console.ReadLine(), line = "";

            fileLocation = FileUtility.CheckFileLocation(fileLocation);

            StreamReader stream = new StreamReader(fileLocation);

            for (int i = 0; (line = stream.ReadLine()) != null; i++)
            {
                if (i == 0) //Sockets
                    AddSockets(line);
                else
                    AddSocketConnections(line);
            }
        }
        private void AddSockets(string line)
        {
            string[] sockets = line.Split(',');

            foreach (string s in sockets)
            {
                if (!r.IsMatch(s))
                    throw new Exception("One of sockets are invalid, please fix and try again.");
                mainSockets.Add(new Socket() { ID = s.Trim() });
            }
        }
        private void AddSocketConnections(string line)
        {
            string[] sockets = line.Split(',');
            string[] socketInfo = null;

            foreach (string s in sockets)
            {
                if (s != sockets[0])
                {
                    socketInfo = s.Split(':');
                    socketConnection.Add(new Tuple<Socket, Tuple<Socket, int>>(new Socket() { ID = sockets[0] }, new Tuple<Socket, int>(new Socket() { ID = socketInfo[0] }, Int32.Parse(socketInfo[1]))));
                }
            }
        }
    }
}
