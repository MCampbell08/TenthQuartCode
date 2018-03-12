using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Models
{
    public class SocketMap
    {
        public List<Socket> Sockets { get; set; }

        public SocketMap(IEnumerable<string> initializeList)
        {
            foreach (string s in initializeList)
            {
                AddVertex(s);
            }
        }
        public SocketMap(SocketMap socketMap)
        {
            CopyFrom(socketMap);
        }
        public Socket AddVertex(string context)
        {
            Socket socket = new Socket() { ID = context };
            Sockets.Add(socket);

            return socket;
        }
        public Socket FindSocket(string s)
        {
            return Sockets.Find(n => n.ID == s);
        }
        public void CopyFrom(SocketMap socketMap)
        {
            Sockets.Clear();
            Sockets.AddRange(socketMap.Sockets);
        }
        public bool Contains(Socket socket)
        {
            return Sockets.Find(s => s.Equals(socket)) != null;
        }
        public void Remove(Socket socket)
        {
            Sockets.Remove(socket);
        }
    }
}
