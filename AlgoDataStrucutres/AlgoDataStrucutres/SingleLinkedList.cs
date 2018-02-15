using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStrucutres
{
    public class SingleLinkedList <T>
    {
        public class Node
        {
            public Node prevNode = null;
            public Node nextNode = null;
            public object data = null;
        }
        private int _count = 0;

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
                {
                    Node temp = curr;
                    curr = curr.nextNode;
                    curr.prevNode = temp;
                }
                return curr;
            }

        }
        public void Add(T val)
        {
            Node n = new Node { data = val };

            if (root == null)
                root = n;
            else
                //Last.prevNode = Last;
                Last.nextNode = n;
            _count++;
        }
        public void Insert(T val, int index)
        {
            if (index < 0 || index == Count || index > Count)
                throw new IndexOutOfRangeException();

            Node n = new Node { data = val };
            for (int i = 0; i < index; i++)
            {
                n = n.nextNode;
            }
            //n.prevNode = n;
            Node nextNode = n.nextNode;
            n.nextNode = new Node { data = val };
            _count++;
        }
        public int Count { get { return _count; }}
        public T Get(int index)
        {
            if (index < 0 || index == Count || index > Count)
                throw new IndexOutOfRangeException();
            
            Node node = root;
            for (int i = 0; i < index; i++)
            {
                node = node.nextNode;
            }
            return (T)node.data;
        }
        public T Remove()
        {
            Node node = Last;

            for (int i = Count; i > -1; i--)
            {
                if (node.prevNode != null)
                {
                    node = node.prevNode;
                }
            }
            return (T)node.data;
        }
    }
}
