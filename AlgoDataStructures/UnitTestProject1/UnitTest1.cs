using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void RemoveRoot()
        //{
        //    BinarySearchTree<int> bst = new BinarySearchTree<int>();
        //    string expected = "10, 1337";
        //    int[] expectedArray = new int[] { 10, 1337 };
        //    int expectedCount = 2;

        //    bst.Add(24);
        //    bst.Add(10);
        //    bst.Add(1337);

        //    bst.Remove(24);

        //    string actual = bst.InOrder();
        //    int actualCount = bst.Count;
        //    int[] actualArray = bst.ToArray();

        //    Assert.AreEqual(expectedCount, actualCount);
        //    //Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod]
        //public void RemoveLeftBranchRoot()
        //{
        //    BinarySearchTree<int> bst = new BinarySearchTree<int>();
        //    int[] expectedArray = new int[] { 7, 8, 9, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };
        //    int expectedCount = expectedArray.Length;

        //    bst.Add(24);
        //    bst.Add(10);
        //    bst.Add(1337);
        //    bst.Add(8);
        //    bst.Add(12);
        //    bst.Add(100);
        //    bst.Add(1400);
        //    bst.Add(7);
        //    bst.Add(9);
        //    bst.Add(11);
        //    bst.Add(13);
        //    bst.Add(90);
        //    bst.Add(110);
        //    bst.Add(1350);
        //    bst.Add(1500);

        //    bst.Remove(10);

        //    int actualCount = bst.Count;
        //    int[] actualArray = bst.ToArray();

        //    Assert.AreEqual(expectedCount, actualCount);
        //    //Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
        //}
        //[TestMethod]
        //public void DLL_ListOfOne()
        //{
        //    DoubleLinkedList<int> list = new DoubleLinkedList<int>();
        //    list.Add(24);
        //    int expectedCount = 1;
        //    string expectedString = "24";

        //    int actualCount = list.Count;
        //    string actualString = list.ToString();

        //    Assert.AreEqual(expectedCount, actualCount);
        //    Assert.AreEqual(expectedString, actualString);
        //}
        //[TestMethod]
        //public void DLL_ListOfTen_GetAt5()
        //{
        //    DoubleLinkedList<int> list = new DoubleLinkedList<int>();
        //    list.Add(24);
        //    list.Add(3);
        //    list.Add(6);
        //    list.Add(0);
        //    list.Add(6);
        //    list.Add(17);
        //    list.Add(100);
        //    list.Add(2014);
        //    list.Add(122778);
        //    list.Add(42);

        //    int expectedReturn = 17;
        //    int expectedCount = 10;
        //    string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

        //    int actualReturn = list.Get(5);
        //    int actualCount = list.Count;
        //    string actualString = list.ToString();

        //    Assert.AreEqual(expectedReturn, actualReturn);
        //    Assert.AreEqual(expectedCount, actualCount);
        //    Assert.AreEqual(expectedString, actualString);
        //}

        private string ArrayToString(int[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                    stringBuilder.Append(array[i].ToString());
                else
                    stringBuilder.Append(array[i].ToString() + ", ");
            }

            return stringBuilder.ToString();
        }

        [TestMethod]
        public void AddThreeValuesToTree()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesSingleRightRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(1337);
            avl.Add(24);
            avl.Add(10);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesSingleLeftRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(10);
            avl.Add(24);
            avl.Add(1337);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesDoubleLeftRightRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(1337);
            avl.Add(10);
            avl.Add(24);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThreeValuesDoubleRightLeftRotation()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(10);
            avl.Add(1337);
            avl.Add(24);

            string expected = "24, 10, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLeftLeaf()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            avl.Remove(10);

            string expected = "24, 1337";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRightLeaf()
        {
            AVLTree<int> avl = new AVLTree<int>();

            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);

            avl.Remove(1337);

            string expected = "24, 10";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveLeftBranchRoot()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(10);

            string expected = "24, 11, 1337, 8, 12, 100, 1400, 7, 9, 13, 90, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRightBranchRoot()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(1337);

            string expected = "24, 10, 1350, 8, 12, 100, 1400, 7, 9, 11, 13, 90, 110, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveRootFromLargeTree()
        {
            AVLTree<int> avl = new AVLTree<int>();
            avl.Add(24);
            avl.Add(10);
            avl.Add(1337);
            avl.Add(8);
            avl.Add(12);
            avl.Add(100);
            avl.Add(1400);
            avl.Add(7);
            avl.Add(9);
            avl.Add(11);
            avl.Add(13);
            avl.Add(90);
            avl.Add(110);
            avl.Add(1350);
            avl.Add(1500);

            avl.Remove(24);

            string expected = "90, 10, 1337, 8, 12, 100, 1400, 7, 9, 11, 13, 110, 1350, 1500";
            string actual = ArrayToString(avl.ToArray());

            Assert.AreEqual(expected, actual);
        }
    }
}
