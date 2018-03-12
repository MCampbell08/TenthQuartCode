using NetworkArchitect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Socket
    {
        public string ID { get; set; }
        public List<Edge> Edges { get; set; }

        public override string ToString()
        {
            return ID;
        }
    }
}
