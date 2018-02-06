using System;
using System.Collections.Generic;
using System.Text;

namespace L5_Knapsack
{
    public class KnapsackModel
    {
        public List<Tuple<string, int, int>> Items { get; set; }
        public int MaximumCapacity { get; set; }
        public int UniqueItemAmount { get; set; }
    }
}
