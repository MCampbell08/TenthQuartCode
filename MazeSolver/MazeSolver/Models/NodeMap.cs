using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Models
{
    public class NodeMap<T>
    {
        public NodeMap() { }
        public NodeMap(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (T nodeVertex in vertices)
                AddVertex(nodeVertex);

            foreach (Tuple<T, T> nodeEdges in edges)
                AddEdge(nodeEdges);
        }
        public Dictionary<T, HashSet<T>> ConnectingList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T nodeVertex)
        {
            ConnectingList[nodeVertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> nodeEdge)
        {
            if (ConnectingList.ContainsKey(nodeEdge.Item1) && ConnectingList.ContainsKey(nodeEdge.Item2))
            {
                ConnectingList[nodeEdge.Item1].Add(nodeEdge.Item2);
                ConnectingList[nodeEdge.Item2].Add(nodeEdge.Item1);
            }
        }
    }
}
