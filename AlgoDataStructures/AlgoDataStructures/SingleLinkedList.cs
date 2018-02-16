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
                Last.nextNode = n;
            _count++;
        }
        public void Insert(T val, int index)
        {
            Node currNode, nextNode, prevNode = null;

            CheckInbounds(index);

            currNode = root;
            for (int i = 0; i < index; i++)
            {
                if (i == index - 2)
                    prevNode = currNode.nextNode;
                currNode = currNode.nextNode;
            }
            if (index == 0)
                root = new Node { data = val, nextNode = currNode };
            else {
                nextNode = currNode;

                currNode = new Node { data = val, nextNode = nextNode };
                prevNode.nextNode = currNode;
            }
            _count++;
        }
        public int Count { get { return _count; }}
        public T Get(int index)
        {
            CheckInbounds(index);

            Node node = root;
            for (int i = 0; i < index; i++)
                node = node.nextNode;
            return (T)node.data;
        }
        public T Remove()
        {
            Node node = root;

            root = root.nextNode;

            _count--;

            return (T)node.data;
        }
        public T RemoveAt(int index)
        {
            CheckInbounds(index);

            Node node = root;

            for (int i = 0; i < index; i++)
                node = node.nextNode;

            _count--;

            return (T)node.data;
        }
        public T RemoveLast()
        {
            Node node = root, nextNode = null;

            for (int i = 0; i < Count - 2; i++)
                node = node.nextNode;
            nextNode = node.nextNode;
            node.nextNode = null;

            _count--;

            return (T)nextNode.data;
        }
        public override string ToString()
        {
            if (root == null)
                return "";

            StringBuilder stringBuilder = new StringBuilder();
            Node node = root;

            stringBuilder.Append(node.data + ", ");

            for (int i = 0; i < Count - 1; i++)
            {
                node = node.nextNode;
                if (i < Count - 2)
                    stringBuilder.Append(node.data + ", ");
                else
                    stringBuilder.Append(Last.data);
            }

            return stringBuilder.ToString();
        }
        public void Clear()
        {
            root = null;
            _count = 0;
        }
        public int Search(T val)
        {
            Node node = root;

            for (int i = 0; i < Count - 1; i++)
            {
                if (node.data.Equals((object)val))
                    return i;
                node = node.nextNode;
            }

            return -1;
        }
        private void CheckInbounds(int index)
        {
            if (index < 0 || index == Count || index > Count)
                throw new IndexOutOfRangeException();
        }
    }
}
