using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Models
{
    public class Nodes
    {
        public string Name { get; set; }
        public bool StartingPoint { get; set; }
        public bool FinishingPoint { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
