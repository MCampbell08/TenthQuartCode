using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace L1_Isomorphic_Strings
{
    public class IsomorphicController
    {
        private Dictionary<string, string> IsomorphDictionary = new Dictionary<string, string>();

        public IsomorphicController(string filePath)
        {
            this.FilePath = filePath;
        }
        public void FindIsomorphs()
        {
            string line = "";
            StreamReader stream = new StreamReader(FilePath);
            while ((line = stream.ReadLine()) != null)
            {
                string value = "";
                string tempKey = "";
                int counter = 0;
                foreach(char c in line)
                {
                    if (!tempKey.Contains(c.ToString()))
                    {
                        value += counter.ToString();
                    }
                }
            }
        }
        public string FilePath { get; set; }

    }
}
