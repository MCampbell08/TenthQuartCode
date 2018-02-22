using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class DoubleLinkedList<T>
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
            {
                Last.nextNode = n;
                if (Count != 1)
                    Last.prevNode = n.prevNode;
            }
            _count++;
        }
        public void Insert(T val, int index)
        {
            Node n, nextNode, prevNode;

            CheckInbounds(index);

            n = root;
            for (int i = 0; i < index; i++)
                n = n.nextNode;
            if (index == 0)
            {
                root = new Node { data = val, nextNode = n };
                root.nextNode.prevNode = root;
            }
            else
            {
                nextNode = n;
                prevNode = n.prevNode;

                n = new Node { data = val };

                prevNode.nextNode = n;
                nextNode.prevNode = n;
                n.nextNode = nextNode;
                n.prevNode = prevNode;
            }
            _count++;
        }
        public int Count { get { return _count; } }
        public T Get(int index)
        {
            CheckInbounds(index);

            Node node = FastestNodeSelection(index);

            return (T)node.data;
        }
        public T Remove()
        {
            Node node = root;

            root = root.nextNode;
            root.prevNode = null;

            _count--;

            return (T)node.data;
        }
        public T RemoveAt(int index)
        {
            CheckInbounds(index);
            Node node = FastestNodeSelection(index);

            node.prevNode.nextNode = node.nextNode;
            node.nextNode.prevNode = node.prevNode;

            _count--;

            return (T)node.data;
        }


        public T RemoveLast()
        {
            Node node = Last;

            node.prevNode.nextNode = null;

            _count--;

            return (T)node.data;
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
        private Node FastestNodeSelection(int index)
        {
            Node node = null;
            if (Count / 2 >= index)
            {
                node = root;
                for (int i = 0; i < index; i++)
                    node = node.nextNode;
            }
            else
            {
                node = Last;
                for (int i = Count; i > index; i--)
                    node = node.prevNode;
            }

            return node;
        }
    }
}
