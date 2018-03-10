using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataStructures
{
    public class AVLTree<T> where T : IComparable
    {
        #region Subclasses
        public class Node
        {
            public Node leftLeaf = null;
            public Node rightLeaf = null;
            public Node parentLeaf = null;
            public object data = null;
            public bool isRemoved = false;
            public int balanceFactor = 0;
        }
        #endregion

        #region Private Variables
        private int _count = 0;
        private int counter = 0;
        private Node root = null;
        #endregion

        #region Public Methods
        public void Add(T val)
        {
            Node node = new Node { data = val };

            if (root == null)
                root = node;
            else
                root = Insert(root, node);
        }
        public bool Contains(T val)
        {
            if (root == null)
                return false;

            return ContainsLeaf(val, ref root);
        }
        public void Remove(T val)
        {
            root = FindLeaf(val, root);
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
        public int Height()
        {
            return LoopingHeight(root);
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
        public T[] ToArray()
        {
            counter = 0;
            int height = GetNodeHeight(root);
            T[] list = new T[Count];

            for (int i = 0; i <= height; i++)
                list = AddAtGivenLevel(root, i, list);

            return list;
        }
        #endregion

        #region Private Methods
        private Node Insert(Node currNode, Node newNode)
        {
            T val = (T)newNode.data;
            if (currNode == null)
            {
                currNode = newNode;
                return currNode;
            }
            else if (val.CompareTo(currNode.data) < 0)
            {
                currNode.leftLeaf = Insert(currNode.leftLeaf, newNode);
                currNode = BalanceTree(currNode);
            }
            else if (val.CompareTo(currNode.data) >= 0)
            {
                currNode.rightLeaf = Insert(currNode.rightLeaf, newNode);
                currNode = BalanceTree(currNode);
            }
            return currNode;
        }
        private Node BalanceTree(Node node)
        {
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.leftLeaf) > 0)
                    node = RotateLeftL(node);
                else
                    node = RotateLeftR(node);
            }
            else if (balanceFactor < -1)
            {

                if (GetBalanceFactor(node.rightLeaf) > 0)
                    node = RotateRightL(node);
                else
                    node = RotateRightR(node);
            }

            return node;
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
        private Node FindLeaf(T val, Node currNode)
        {
            if (currNode != null)
            {
                if (val.CompareTo(currNode.data) < 0)
                {
                    currNode.leftLeaf = FindLeaf(val, currNode.leftLeaf);
                    if(GetBalanceFactor(currNode) == -2)
                    {
                        if (GetBalanceFactor(currNode.rightLeaf) <= 0)
                            currNode = RotateRightR(currNode);
                        else
                            currNode = RotateRightL(currNode);
                    }
                }
                else if (val.CompareTo(currNode.data) > 0)
                {
                    currNode.rightLeaf = FindLeaf(val, currNode.rightLeaf);
                    if (GetBalanceFactor(currNode) == 2)
                    {
                        if (GetBalanceFactor(currNode.leftLeaf) <= 0)
                            currNode = RotateLeftL(currNode);
                        else
                            currNode = RotateLeftR(currNode);
                    }
                }
                else
                {
                    if (currNode.rightLeaf != null)
                    {
                        Node tempNode = currNode.rightLeaf;
                        while (tempNode.leftLeaf != null)
                            tempNode = tempNode.leftLeaf;

                        currNode.data = tempNode.data;
                        currNode.rightLeaf = FindLeaf((T)tempNode.data, currNode.rightLeaf);
                        if (GetBalanceFactor(currNode.leftLeaf) >= 0)
                            currNode = RotateLeftL(currNode);
                        else
                            currNode = RotateLeftR(currNode);
                    }
                    else
                    {
                        return currNode.leftLeaf;
                    }
                }
            }

            return currNode;
        }
        //private bool FindLaf(T val, ref Node curr)
        //{
        //    bool returnNow = false;
        //    if (val.CompareTo(curr.data) == 0)
        //    {
        //        curr.isRemoved = true;
        //        _count--;
        //        return true;
        //    }
        //    if (curr != null)
        //    {
        //        if (val.CompareTo(curr.data) < 0 && !returnNow)
        //        {
        //            returnNow = FindLeaf(val,  curr.leftLeaf);
        //            if(GetBalanceFactor(curr) == -2)
        //            {
        //                if (GetBalanceFactor(curr.rightLeaf) <= 0)
        //                    curr = RotateRightR(curr);
        //                else
        //                    curr = RotateRightL(curr);
        //            }
        //        }

        //        if (val.CompareTo(curr.data) > 0 && !returnNow)
        //        {
        //            returnNow = FindLeaf(val,  curr.rightLeaf);

        //            if (GetBalanceFactor(curr) == 2)
        //            {
        //                if (GetBalanceFactor(curr.leftLeaf) >= 0)
        //                    curr = RotateLeftL(curr);
        //                else
        //                    curr = RotateLeftR(curr);
        //            }
        //        }
        //    }
        //    return returnNow;
        //}
        private void Counter(Node node)
        {
            if (node != null)
            {
                Node def = new Node { data = '0' };
                if (node.isRemoved) _count--;
                _count++;
                Counter(node.leftLeaf);
                Counter(node.rightLeaf);
            }
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
        private int GetNodeHeight(Node node)
        {
            int height = 0;

            if (node != null && !node.isRemoved)
            {
                int leftSubNode = GetNodeHeight(node.leftLeaf);
                int rightSubNode = GetNodeHeight(node.rightLeaf);
                height = ((leftSubNode > rightSubNode) ? leftSubNode : rightSubNode) + 1;
            }

            return height;
        }
        private int GetBalanceFactor(Node node)
        {
            return GetNodeHeight(node.leftLeaf) - GetNodeHeight(node.rightLeaf);
        }
        private Node RotateLeftL(Node node)
        {
            Node leftPivotNode = node.leftLeaf;
            node.leftLeaf = leftPivotNode.rightLeaf;
            leftPivotNode.rightLeaf = node;

            return leftPivotNode;
        }
        private Node RotateRightR(Node node)
        {
            Node rightPivotNode = node.rightLeaf;
            node.rightLeaf = rightPivotNode.leftLeaf;
            rightPivotNode.leftLeaf = node;

            return rightPivotNode;
        }
        private Node RotateLeftR(Node node)
        {
            Node leftPivotNode = node.leftLeaf;
            node.leftLeaf = RotateRightR(leftPivotNode);

            return RotateLeftL(node);
        }
        private Node RotateRightL(Node node)
        {
            Node rightPivotNode = node.rightLeaf;
            node.rightLeaf = RotateLeftL(rightPivotNode);

            return RotateRightR(node);
        }
        private T[] AddAtGivenLevel(Node node, int level, T[] list)
        {
            if (node != null)
            {
                if (level == 1)
                {
                    list[counter] = (T)node.data;
                    counter++;
                }
                else if (level > 1)
                {
                    list = AddAtGivenLevel(node.leftLeaf, level - 1, list);
                    list = AddAtGivenLevel(node.rightLeaf, level - 1, list);
                }
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
        #endregion
    }
}
