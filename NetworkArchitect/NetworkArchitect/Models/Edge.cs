using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect.Models
{
    public class Edge : IComparable<Edge>
    {
        public Socket SourceSocket { get; set; }
        public Socket DestinationSocket { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight - other.Weight;
        }
    }
}
