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
            public bool isRemoved = false;
            public int balanceFactor = 0;
        }
        public class AVLTree
        {

        }
        private int _count = 0;
        private int counter = 0;
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
            if (currNode.isRemoved)
            {
                currNode.data = val;
                currNode.isRemoved = false;
            }
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
            UpdateBalanceFactor();

            return nodePlaced;
        }
        private static void UpdateBalanceFactor()
        {

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
        private bool FindLeaf(T val, ref Node curr)
        {
            bool returnNow = false;
            if (val.CompareTo(curr.data) == 0)
            {
                curr.isRemoved = true;
                _count--;
                return true;
            }
            if (curr != null)
            {
                if (val.CompareTo(curr.data) < 0 && !returnNow)
                    returnNow = FindLeaf(val, ref curr.leftLeaf);

                if (val.CompareTo(curr.data) > 0 && !returnNow)
                    returnNow = FindLeaf(val, ref curr.rightLeaf);
            }
            return returnNow;            
        }
        public void Clear()
        {
            root = null;
            _count = 0;
        }
        public int Count
        {
            get
            {
                _count = 0;
                Counter(root);
                return _count;
            }

            set { _count = value; }

        }
        private void Counter(Node node)
        {
            if (node != null)
            {
                Node def = new Node { data = '0'};
                if (node.isRemoved) _count--;
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
            counter = 0;
            StringBuilder stringBuilder = new StringBuilder();
            T[] list = new T[Count];

            ArrayLooper(list, root);

            BubbleSort(list);

            for (int i = 0; i < Count; i++)
                stringBuilder.Append((i < Count - 1) ? list[i] + ", " : list[i] + "");

            return stringBuilder.ToString();
        }
        public T[] ToArray()
        {
            counter = 0;
            T[] list = ArrayLooper(new T[Count], root);

            BubbleSort(list);

            return list;
        }
        private T[] ArrayLooper(T[] list, Node node)
        {
            if (node != null)
            {
                if (!node.isRemoved)
                {
                    counter++;
                    list[counter - 1] = (T)node.data;
                }
                ArrayLooper(list, node.leftLeaf);
                ArrayLooper(list, node.rightLeaf);
            }
            return list;
        }
        private static void BubbleSort(T[] inputArray)
        {
            bool done = false;
            while (!done)
            {
                int counter = 0;
                done = true;
                while (counter < inputArray.Length - 1)
                {
                    if (inputArray[counter + 1].CompareTo(inputArray[counter]) < 0)
                    {
                        T tempObject = inputArray[counter + 1];
                        inputArray[counter + 1] = inputArray[counter];
                        inputArray[counter] = tempObject;
                        done = false;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
        }
        public string PreOrder()
        {
            counter = 0;
            StringBuilder stringBuilder = new StringBuilder();
            T[] list = new T[Count];

            ArrayLooper(list, root);

            for (int i = 0; i < Count; i++)
                stringBuilder.Append((i < Count - 1) ? list[i] + ", " : list[i] + "");

            return stringBuilder.ToString();
        }
        public string PostOrder()
        {
            counter = 0;
            StringBuilder stringBuilder = new StringBuilder();
            T[] list = new T[Count];

            AddPostOrder(list, root);

            for (int i = 0; i < Count; i++)
                stringBuilder.Append((i < Count - 1) ? list[i] + ", " : list[i] + "");

            return stringBuilder.ToString();
        }

        private void AddPostOrder(T[] list, Node node)
        {
            if (node != null)
            {
                AddPostOrder(list, node.leftLeaf);
                AddPostOrder(list, node.rightLeaf);
                list[counter] = (T)node.data;
                counter++;
            }
        }
    }
}
