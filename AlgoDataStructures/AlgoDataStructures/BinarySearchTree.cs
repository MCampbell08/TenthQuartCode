using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public class Node
        {
            public Node leftLeaf = null;
            public Node rightLeaf = null;
            public Node parentLeaf = null;
            public object data = null;
        }
        private int _count = 0;
        private Node root = null;
        public void Add(T val)
        {
            Node node = new Node { data = val }, currNode = root, prevNode = root;

            if (root == null)
                root = node;
            else
            {
                bool nodePlaced = false;

                while (!nodePlaced)
                    nodePlaced = PlaceNode(val, node, ref currNode, ref prevNode);
            }
        }
        private static bool PlaceNode(T val, Node node, ref Node currNode, ref Node prevNode)
        {
            bool nodePlaced = false;
            if (val.CompareTo(currNode.data) < 0)
            {
                if (currNode.leftLeaf != null)
                {
                    prevNode = currNode;
                    currNode = currNode.leftLeaf;
                    currNode.parentLeaf = prevNode;
                }
                else
                {
                    currNode.leftLeaf = node;
                    currNode.leftLeaf.parentLeaf = currNode;
                    nodePlaced = true;
                }
            }
            else if (val.CompareTo(currNode.data) >= 0)
            {
                if (currNode.rightLeaf != null)
                {
                    prevNode = currNode;
                    currNode = currNode.rightLeaf;
                    currNode.parentLeaf = prevNode;
                }
                else
                {
                    currNode.rightLeaf = node;
                    currNode.rightLeaf.parentLeaf = currNode;
                    nodePlaced = true;
                }
            }

            return nodePlaced;
        }
        public bool Contains(T val)
        {
            if (root == null)
                return false;

            return ContainsLeaf(val, ref root);
        }
        private bool ContainsLeaf(T val, ref Node curr)
        {
            if (curr == null)
                return false;

            if (val.CompareTo(curr.data) == 0)
                return true;

            if (val.CompareTo(curr.data) < 0)
            {
                return ContainsLeaf(val, ref curr.leftLeaf);
            }
            if (val.CompareTo(curr.data) > 0)
            {
                return ContainsLeaf(val, ref curr.rightLeaf);
            }

            return false;
        }
        public void Remove(T val)
        {
            FindLeaf(val, ref root);
        }
        private void FindLeaf(T val, ref Node curr)
        {
            if (val.CompareTo(curr.data) == 0)
            {
                curr = null;
                _count--;
            }

            if (curr != null)
            {
                if (val.CompareTo(curr.data) < 0)
                    FindLeaf(val, ref curr.leftLeaf);

                if (val.CompareTo(curr.data) > 0)
                    FindLeaf(val, ref curr.rightLeaf);
            }
        }
        public void Clear()
        {
            root = null;
            _count = 0;
        }
        public int Count
        {
            get {
                Counter(root);
                return _count;
            }

            set { _count = value; }

        }
        private void Counter(Node node)
        {
            if (node != null)
            {
                _count++;
                Counter(node.leftLeaf);
                Counter(node.rightLeaf);
            }
        }
        public int Height()
        {
            return LoopingHeight(root);
        }
        private int LoopingHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int lefth = LoopingHeight(node.leftLeaf);
            int righth = LoopingHeight(node.rightLeaf);

            if (lefth > righth)
            {
                return lefth + 1;
            }
            else
            {
                return righth + 1;
            }
        }
        public string InOrder()
        {
            StringBuilder stringBuilder = new StringBuilder();
            T[] list = new T[Count];


            AddInOrder(list, root);

            return stringBuilder.ToString();
        }
        private T[] AddInOrder(T[] list, Node node)
        {
            if (node != null)
            {
                if (list.Length == 0)
                {
                    list[0] = (T)node.data;
                }
                else
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (list[i].CompareTo(node.data) <= 0)
                        {
                            list[i + 1] = (T)node.data;
                        }
                        else
                        {
                            list[i + 1] = list[i];
                            list[i] = node.data;
                        }
                    }
                    Counter(node.leftLeaf);
                    Counter(node.rightLeaf);
                }
            }
            return list;
        }
    }
}
