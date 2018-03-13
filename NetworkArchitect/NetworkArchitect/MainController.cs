using NetworkArchitect.Models;
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
        private List<Tuple<Socket, Tuple<Socket, int>>> socketConnectors = new List<Tuple<Socket, Tuple<Socket, int>>>();
        private SocketMap socketMap = null;
        private Regex r = new Regex("^[a-zA-Z0-9]+$");
        private int verticesAmount = 0, edgesAmount = 0, edgesCounter = 0;
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
            socketMap = new SocketMap(verticesAmount, edgesAmount);
            AddSocketToTree();
            DisplaySockets();
        }
        private void DisplaySockets()
        {
            Console.WriteLine("Socket | Connected To Socket | Length");
            for(int i = 0; i < socketMap.Edges.Length; i++)
            {
                Console.WriteLine("{0, 6} | {1, 19} | {2, 6}", socketMap.Edges[i].SourceSocket, socketMap.Edges[i].DestinationSocket, socketMap.Edges[i].Weight);
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
                verticesAmount++;
            }
        }
        private void AddSocketConnections(string line)
        {
            string[] sockets = line.Split(',');
            string[] socketInfo = null;
            
            for (int i = 0; i < sockets.Length; i++)
            {
                if (i != 0)
                {
                    socketInfo = sockets[i].Split(':');
                    socketConnectors.Add(new Tuple<Socket, Tuple<Socket, int>> ( new Socket() { ID = sockets[0]}, new Tuple<Socket, int>( new Socket() { ID = socketInfo[0]}, Int32.Parse(socketInfo[1]))));
                    edgesAmount++;
                }
            }
        }
        private void AddSocketToTree()
        {
            for (int i = 0; i < socketMap.Edges.Length; i++)
            {
                socketMap.Edges[i].SourceSocket = socketConnectors[i].Item1;
                socketMap.Edges[i].DestinationSocket = socketConnectors[i].Item2.Item1;
                socketMap.Edges[i].Weight = socketConnectors[i].Item2.Item2;
            }
        }
    }
}
