using System;
using System.Collections.Generic;
using System.Text;

namespace L5_Knapsack
{
    public class KnapsackCalculator
    {
        private KnapsackModel knapsack = new KnapsackModel() { Items = new List<Tuple<string, int, int>>(), MaximumCapacity = new int(), UniqueItemAmount = new int() };
        private int[,] knapsackCollection;
        private string[,] knapsackCollectionNames;

        public void FillKnapsack()
        {
            Console.Write("Please enter a file path: ");

            string filePath = Console.ReadLine();
            string line = "";
            int counter = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                    knapsack.MaximumCapacity = int.Parse(line);
                else if (counter == 1)
                    knapsack.UniqueItemAmount = int.Parse(line);
                else
                {
                    string[] itemInfo = line.Split(',');
                    knapsack.Items.Add(new Tuple<string, int, int>(itemInfo[0].Trim(), int.Parse(itemInfo[1].Trim()), int.Parse(itemInfo[2].Trim())));
                }
                counter++;
            }
            CalculateKnapsack();
        }
        private void CalculateKnapsack()
        {
            knapsackCollection = new int[knapsack.UniqueItemAmount + 1, knapsack.MaximumCapacity + 1];
            knapsackCollectionNames = new string[knapsack.UniqueItemAmount + 1, knapsack.MaximumCapacity + 1];

            for (int i = 0; i <= knapsack.Items.Count; i++)
            {
                for (int j = 0; j <= knapsack.MaximumCapacity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        knapsackCollection[i, j] = 0;
                        knapsackCollectionNames[i, j] = "";
                    }
                    else if (knapsack.Items[i - 1].Item2 <= j)
                    {
                        knapsackCollection[i, j] = Math.Max(knapsack.Items[i - 1].Item3 + knapsackCollection[i - 1, j - knapsack.Items[i - 1].Item2], knapsackCollection[i - 1, j]);
                        knapsackCollectionNames[i, j] = (knapsack.Items[i - 1].Item3 + knapsackCollection[i - 1, j - knapsack.Items[i - 1].Item2] > knapsackCollection[i - 1, j]) ? knapsack.Items[i - 1].Item1 + " | " + knapsackCollectionNames[i - 1, j - knapsack.Items[i - 1].Item2] : knapsackCollectionNames[i - 1, j];
                    }
                    else
                    {
                        knapsackCollection[i, j] = knapsackCollection[i - 1, j];
                        knapsackCollectionNames[i, j] = knapsackCollectionNames[i - 1, j];
                    }
                }
            }
            DisplayKnapsack();
        }
        private void DisplayKnapsack()
        {
            List<string> knapsackItemList = new List<string>(knapsackCollectionNames[knapsack.UniqueItemAmount, knapsack.MaximumCapacity].Split('|'));

            for (int i = knapsackItemList.Count - 1; i >= 0; i--)
            {
                if (knapsackItemList[i] != " ")
                {
                    knapsackItemList[i] = knapsackItemList[i].Trim();
                    Console.WriteLine(knapsackItemList[i].Trim());
                }
            }

            int weight = 0;
            foreach(Tuple<string, int, int> tempTuple in knapsack.Items)
            {
                if (knapsackItemList.Contains(tempTuple.Item1))
                {
                    weight += tempTuple.Item2;
                }
            }
            Console.WriteLine(weight + " pounds");
            Console.WriteLine("$" + knapsackCollection[knapsack.UniqueItemAmount, knapsack.MaximumCapacity]);
        }
    }
}
