using MazeSolver.Models;
using MazeSolver.Utilites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class SolveMaze
    {
        private static List<Nodes> mazeNodes = new List<Nodes>();
        private static List<Tuple<Nodes, Nodes>> nodeConnections = new List<Tuple<Nodes, Nodes>>();

        private void AddNodeNames(string line)
        {
            string[] nodeNames = line.Split(',');

            for (int i = 0; i < nodeNames.Length; i++)
                mazeNodes.Add(new Nodes { Name = nodeNames[i].Trim().ToString() });
        }
        private void AddNodePositions(string line)
        {
            string[] nodePos = line.Split(',');

            for (int i = 0; i < nodePos.Length; i++)
            {
                for (int j = 0; j < mazeNodes.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        if (mazeNodes[j].Name == nodePos[i].Trim().ToString())
                            mazeNodes[j].StartingPoint = true;
                    }
                    else
                    {
                        if (mazeNodes[j].Name == nodePos[i].Trim().ToString())
                            mazeNodes[j].FinishingPoint = true;
                    }
                }
            }
        }
        private void AddNodeAdjacents(string line)
        {
            string[] nodeAdjacents = line.Split(',');
            List<Nodes> nodesInLine = new List<Nodes>();
            Dictionary<Nodes, List<Nodes>> tempNodeConnections = new Dictionary<Nodes, List<Nodes>>();

            for (int i = 0; i < nodeAdjacents.Length; i++)
            {
                for (int j = 0; j < mazeNodes.Count; j++)
                {
                    if (nodeAdjacents[i].Equals(mazeNodes[j].Name))
                        nodesInLine.Add(mazeNodes[j]);
                }
            }
            Nodes leadNode = nodesInLine[0];
            nodesInLine.RemoveAt(0);
            tempNodeConnections.Add(leadNode, nodesInLine);

            for (int i = 0; i < tempNodeConnections.Values.ElementAt(0).Count; i++)
                nodeConnections.Add(new Tuple<Nodes, Nodes>(tempNodeConnections.Keys.ElementAt(0), tempNodeConnections.Values.ElementAt(0)[i]));
        }

        public void ReadFile()
        {
            Console.Write("Please enter a file location for MazeSolver: ");
            string fileLocation = Console.ReadLine(), line = "";

            fileLocation = FileUtility.CheckFileLocation(fileLocation);

            StreamReader stream = new StreamReader(fileLocation);
            for (int i = 0; (line = stream.ReadLine()) != null; i++)
            {
                if (i == 0) //Node Names
                    AddNodeNames(line);
                else if (i == 1)
                    AddNodePositions(line);
                else
                    AddNodeAdjacents(line);
            }
        }    
        public void Solve()
        {
            NodeMap<Nodes> nodeMap = new NodeMap<Nodes>(mazeNodes, nodeConnections);
            QueueSearcher queueSearcher = new QueueSearcher();
            Nodes startingNode = null;
            Nodes endingNode = null;

            foreach (Nodes node in mazeNodes)
            {
                if (node.StartingPoint)
                    startingNode = node;
                else if (node.FinishingPoint)
                    endingNode = node;
            }
            var shortestPath = queueSearcher.ShortestPath(nodeMap, startingNode);
            string returnedString = string.Join(", ", shortestPath(endingNode));

            if (returnedString != "")
                Console.WriteLine("Maze Solution: {0}", returnedString);
            else
                Console.WriteLine("Maze cannot be solved");

            
        }
    }
}
