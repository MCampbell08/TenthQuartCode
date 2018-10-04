using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class MaxHeapPriorityQueue
    {
        private PQNode root;
        public class PQNode{
            public int Priority { get; set; }
            public int Value { get; set; }
            public PQNode NextNode { get; set; }
            public PQNode PrevNode { get; set; }
        }
        public void Enqueue(int priority, int value)
        {
            PQNode pQNode = new PQNode() { Priority = priority, Value = value };
            if (root == null)
                root = pQNode;
            else
            {
                PQNode tempPQNode = root;
                tempPQNode = AddPQNode(tempPQNode);
                tempPQNode.NextNode = pQNode;
                Count++;

                int counter = Count - 1;

                while (counter > 0)
                {
                    int i = (counter - 1) / 2;
                    if (Find(counter).Value.CompareTo(Find(i).Value) >= 0)
                        break;

                    SwitchPQNodes(counter, i);
                    counter = i;
                }
            }
        }
        public PQNode Peek()
        {
            if(root != null)
                return root;

            return null;
        }
        public PQNode Dequeue()
        {
            PQNode pQNode = root;

            root = root.NextNode;
            root.PrevNode = null;
            Count--;

            return root;
        }
        public int Count { get; private set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            PQNode pQNode = root;

            while (pQNode.NextNode != null)
            {
                stringBuilder.Append(pQNode.Priority + ":" + pQNode.Value + ", ");
                pQNode = pQNode.NextNode;
            }

            return stringBuilder.ToString();
        }
        private PQNode AddPQNode(PQNode pQNode)
        {
            while (pQNode.NextNode != null)
                pQNode = pQNode.NextNode;

            return pQNode;
        }
        private PQNode Find(int index)
        {
            PQNode temp = root;
            for (int i = 0; i < index; i++)
            {
                temp = temp.NextNode;
            }
            return temp;
        }
        private void SwitchPQNodes(int firstIndex, int secondIndex)
        {
            PQNode firstNode = Find(firstIndex);
            PQNode secondNode = Find(secondIndex);

            PQNode tempNode = firstNode;
            firstNode.NextNode = secondNode.NextNode;
            firstNode.PrevNode = secondNode.PrevNode;
            firstNode.Priority = secondNode.Priority;

            secondNode.NextNode = tempNode.NextNode;
            secondNode.PrevNode = tempNode.PrevNode;
            secondNode.Priority = tempNode.Priority;

        }
        
    }
}
