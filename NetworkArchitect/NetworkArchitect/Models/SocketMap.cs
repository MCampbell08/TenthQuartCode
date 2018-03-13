using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Models
{
    public class SocketMap
    {
        public int VerticesAmount { get; set; }
        public int EdgesAmount { get; set; }
        public Edge[] Edges { get; set; }
        public SocketMap(int vertices, int edges)
        {
            VerticesAmount = vertices;
            EdgesAmount = edges;

            Edges = new Edge[EdgesAmount];
            for (int i = 0; i < EdgesAmount; i++)
                Edges[i] = new Edge();
        }
        //public Socket Find(Subset[] subsets, Socket socket, int i)
        //{
        //    if (subsets[i].Parent != socket)
        //        subsets[i].Parent = Find(subsets, subsets[i].Parent);

        //    return subsets[i].Parent;
        //}
        //public void Union(Subset[] subsets, Socket x, Socket y)
        //{
        //    Socket xRoot = Find(subsets, x);
        //    Socket yRoot = Find(subsets, y);

        //    if (subsets[xRoot].Rank < subsets[yRoot].Rank)
        //        subsets[xRoot].Parent = yRoot;
        //    else if (subsets[xRoot].Rank > subsets[yRoot].Rank)
        //        subsets[yRoot].Parent = xRoot;
        //    else
        //    {
        //        subsets[yRoot].Parent = xRoot;
        //        subsets[xRoot].Rank++;
        //    }
        //}
        //public void MinimumSpanningTree()
        //{
        //    Edge[] resultTree = new Edge[VerticesAmount];
        //    int e = 0, edgePicker = 0;

        //    for (int i = 0; i < VerticesAmount; i++)
        //        resultTree[i] = new Edge();

        //    Array.Sort(Edges);

        //    Subset[] subsets = new Subset[VerticesAmount];
        //    for (int i = 0; i < VerticesAmount; i++)
        //        subsets[i] = new Subset();

        //    for (int verticesCounter = 0; verticesCounter < VerticesAmount; verticesCounter++)
        //    {
        //        subsets[verticesCounter].Parent = verticesCounter;
        //        subsets[verticesCounter].Rank = 0;
        //    }

        //    while(e < VerticesAmount - 1)
        //    {
        //        Edge tempEdge = new Edge();
        //        tempEdge = Edges[edgePicker++];

        //        int x = Find(subsets, tempEdge.SourceSocket)
        //    }

        //}
    }
}
