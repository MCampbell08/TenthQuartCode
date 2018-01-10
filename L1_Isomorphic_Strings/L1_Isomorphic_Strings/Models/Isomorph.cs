using System;
using System.Collections.Generic;
using System.Text;

namespace L1_Isomorphic_Strings
{
    public class Isomorph
    {
        public Dictionary<string, string> ExactIsomorphs { get; set; }
        public Dictionary<string, string> RefinedLooseIsomorphs { get; set; }
        public List<string> NonIsomorphs { get; set; }
        public List<KeyValuePair<string, string>> OrderedExactIsomorphs { get; set; }
        public List<KeyValuePair<string, string>> OrderedLooseIsomorphs { get; set; }
    }
}
