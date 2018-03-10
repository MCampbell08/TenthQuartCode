using MazeSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Utilites
{
    public class QueueSearcher
    {
        public HashSet<T> BFSearch<T>(NodeMap<T> nodeMap, T rootNode)
        {
            HashSet<T> visitedNodes = new HashSet<T>();

            if (!nodeMap.ConnectingList.ContainsKey(rootNode))
                return visitedNodes;

            Queue<T> queue = new Queue<T>();
            queue.Enqueue(rootNode);

            while (queue.Count > 0)
            {
                var nodeVertex = queue.Dequeue();

                if (visitedNodes.Contains(nodeVertex))
                    continue;

                visitedNodes.Add(nodeVertex);

                foreach (T neighborNode in nodeMap.ConnectingList[nodeVertex])
                    if (!visitedNodes.Contains(neighborNode))
                        queue.Enqueue(neighborNode);
            }

            return visitedNodes;
        }

        public Func<T, IEnumerable<T>> ShortestPath<T>(NodeMap<T> nodeMap, T rootNode)
        {
            var previousNode = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(rootNode);

            while (queue.Count > 0)
            {
                var nodeVertex = queue.Dequeue();

                foreach (T neighborNode in nodeMap.ConnectingList[nodeVertex])
                {
                    if (previousNode.ContainsKey(neighborNode))
                        continue;

                    previousNode[neighborNode] = nodeVertex;
                    queue.Enqueue(neighborNode);
                }
            }

            Func<T, IEnumerable<T>> shortestPath = v =>
            {
                var path = new List<T>();
                var currNode = v;
                if (currNode != null)
                {
                    while (!currNode.Equals(rootNode))
                    {
                        path.Add(currNode);
                        currNode = previousNode[currNode];
                    };

                    path.Add(rootNode);
                    path.Reverse();
                }

                return path;
            };

            return shortestPath;
        }
    }
}
