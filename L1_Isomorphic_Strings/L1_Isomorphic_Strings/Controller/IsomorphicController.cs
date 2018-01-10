using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace L1_Isomorphic_Strings
{
    public class IsomorphicController
    {
        private StringBuilder textToFile = new StringBuilder();
        private Isomorph isomorph = new Isomorph()
        {
            ExactIsomorphs        = new Dictionary<string, string>(),
            RefinedLooseIsomorphs = new Dictionary<string, string>(),
            NonIsomorphs          = new List<string>(),
            OrderedExactIsomorphs = new List<KeyValuePair<string, string>>(),
            OrderedLooseIsomorphs = new List<KeyValuePair<string, string>>()
        };

        public IsomorphicController(string filePath)
        {
            this.FilePath = filePath;
        }
        public void Run()
        {
            GetIsomorphs();
            RefineLooseIsomorphs();

            SeperateIsomorphs(isomorph.OrderedExactIsomorphs, isomorph.ExactIsomorphs);
            SeperateIsomorphs(isomorph.OrderedLooseIsomorphs, isomorph.RefinedLooseIsomorphs);

            DisplayIsomorphs(isomorph.OrderedExactIsomorphs);
            DisplayIsomorphs(isomorph.OrderedLooseIsomorphs);
            DisplayIsomorphs(isomorph.NonIsomorphs);

            using (StreamWriter file = new StreamWriter(@".\files\Output.txt"))
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach(char c in textToFile.ToString())
                {
                    stringBuilder.Append(c);
                    if (c == '\n')
                    {
                        file.WriteLine(stringBuilder);
                        stringBuilder.Clear();
                    }
                }
            }
        }
        private void GetIsomorphs()
        {
            string line = "";
            StreamReader stream = new StreamReader(FilePath);
            while ((line = stream.ReadLine()) != null)
            {
                Dictionary<string, int> tempDic = new Dictionary<string, int>();
                string value = "";
                int counter = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (!tempDic.ContainsKey(line[i].ToString()))
                    {
                        tempDic.Add(line[i].ToString(), counter);
                        value += " " + counter.ToString();
                        counter++;
                    }
                    else
                    {
                        value += " " + tempDic[line[i].ToString()];
                    }
                }
                value.TrimStart();
                isomorph.ExactIsomorphs.Add(line, value);
            }
        }
        private void RefineLooseIsomorphs()
        {
            foreach (string key in isomorph.ExactIsomorphs.Keys)
            {
                List<int> formattedValue = new List<int>();
                Dictionary<string, int> tempDic = new Dictionary<string, int>();
                int counter = 1;
                string value = "";
                
                for (int i = 0; i < key.Length; i++)
                {
                    if (!tempDic.ContainsKey(key[i].ToString()))
                    {
                        tempDic.Add(key[i].ToString(), counter);
                    }
                    else
                    {
                        tempDic[key[i].ToString()] = tempDic[key[i].ToString()] + 1;
                    }
                }
                foreach (KeyValuePair<string, int> keyValuePair in tempDic)
                {
                    formattedValue.Add(keyValuePair.Value);
                }
                formattedValue.Sort();
                foreach (int val in formattedValue)
                    value += " " + val.ToString();

                value.TrimStart();
                isomorph.RefinedLooseIsomorphs.Add(key, value);
            }
        }
        private void SeperateIsomorphs(List<KeyValuePair<string, string>> orderedIsomorphs, Dictionary<string, string> dictionaryChosen)
        {
            foreach (KeyValuePair<string, string> keyValPair in dictionaryChosen)
            {
                int counter = 0;
                foreach (KeyValuePair<string, string> keyValPairComparer in dictionaryChosen)
                {
                    if (keyValPair.Value == keyValPairComparer.Value) counter++;
                }
                if (counter > 1)
                {
                    orderedIsomorphs.Add(keyValPair);
                }
                else
                {
                    isomorph.NonIsomorphs.Add(keyValPair.Key.ToString());
                }
            }
            foreach (string s in isomorph.NonIsomorphs)
            {
                if (dictionaryChosen.ContainsKey(s)) dictionaryChosen.Remove(s);
            }
        }
        private void DisplayIsomorphs(List<KeyValuePair<string, string>> list)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            List<string> alreadyDisplayedKeys = new List<string>();

            StringBuilder isomorphText = new StringBuilder();

            isomorphText.Append((list[0].Value.Contains("0") ? "Exact Isomorphs" : "Loose Isomorphs") + "\n");

            foreach (KeyValuePair<string, string> keyValPair in list)
            {
                List<string> stringList = new List<string>();

                if (!alreadyDisplayedKeys.Contains(keyValPair.Value))
                {
                    alreadyDisplayedKeys.Add(keyValPair.Value);

                    foreach (KeyValuePair<string, string> keyValPairComparer in list)
                    {
                        if (keyValPairComparer.Value == keyValPair.Value) stringList.Add(keyValPairComparer.Key.ToString());
                    }
                    stringList.Sort();
                    dictionary.Add(keyValPair.Value, stringList);
                }
            }
            List<string> values = new List<string>();

            foreach (KeyValuePair<string, List<string>> kvp in dictionary)
                values.Add(kvp.Key);

            values.Sort();

            foreach (string value in values) {
                if (dictionary.ContainsKey(value))
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.Append(value + ": ");
                    foreach (string ogKey in dictionary[value])
                        stringBuilder.Append(ogKey + " ");

                    isomorphText.Append(stringBuilder.ToString().Trim() + "\n");
                }
            }
            textToFile.Append(isomorphText.Append("\n"));
        }
        private void DisplayIsomorphs(List<string> list)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Non-isomorphs\n");

            List<string> usedKeys = new List<string>();

            list.Sort();

            foreach (KeyValuePair<string, string> exactPair in isomorph.OrderedExactIsomorphs)
                if (list.Contains(exactPair.Key))
                    list.Remove(exactPair.Key);

            foreach (KeyValuePair<string, string> loosePair in isomorph.OrderedLooseIsomorphs)
                if (list.Contains(loosePair.Key))
                    list.Remove(loosePair.Key);

            foreach (string key in list)
            {
                if (!usedKeys.Contains(key)) {
                    usedKeys.Add(key);
                    stringBuilder.Append(key + " ");
                }
            }
            textToFile.Append(stringBuilder.ToString().Trim() + "\n");
        }
        public string FilePath { get; set; }

    }
}
