using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStrucutres
{
    public class SingleLinkedList <T>
    {
        public class Node
        {
            public Node nextNode = null;
            public object data = null;
            private int _count = 0;
        }

        private Node root = null;
        private Node First { get { return root; } }
        private Node Last
        {
            get
            {
                Node curr = root;
                if (curr == null)
                    return null;
                while (curr.nextNode != null)
                    curr = curr.nextNode;

                return curr;
            }
        }
        public void Add(T val)
        {
            Node n = new Node { data = val };

            if (root == null)
                root = n;
            else
                Last.nextNode = n;
        }
        public void Insert(T val, int index)
        {
            Node n = new Node { data = val };
            for (int i = 0; i < index; i++)
            {

            }
        }
    }
}
