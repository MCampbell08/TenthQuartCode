using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RemoveRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expected = "10, 1337";
            int[] expectedArray = new int[] { 10, 1337 };
            int expectedCount = 2;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);

            bst.Remove(24);

            string actual = bst.InOrder();
            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            //Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveLeftBranchRoot()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int[] expectedArray = new int[] { 7, 8, 9, 11, 12, 13, 24, 90, 100, 110, 1337, 1350, 1400, 1500 };
            int expectedCount = expectedArray.Length;

            bst.Add(24);
            bst.Add(10);
            bst.Add(1337);
            bst.Add(8);
            bst.Add(12);
            bst.Add(100);
            bst.Add(1400);
            bst.Add(7);
            bst.Add(9);
            bst.Add(11);
            bst.Add(13);
            bst.Add(90);
            bst.Add(110);
            bst.Add(1350);
            bst.Add(1500);

            bst.Remove(10);

            int actualCount = bst.Count;
            int[] actualArray = bst.ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            //Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(bst.ToArray()));
        }
        [TestMethod]
        public void DLL_ListOfOne()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(24);
            int expectedCount = 1;
            string expectedString = "24";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void DLL_ListOfTen_GetAt5()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(24);
            list.Add(3);
            list.Add(6);
            list.Add(0);
            list.Add(6);
            list.Add(17);
            list.Add(100);
            list.Add(2014);
            list.Add(122778);
            list.Add(42);

            int expectedReturn = 17;
            int expectedCount = 10;
            string expectedString = "24, 3, 6, 0, 6, 17, 100, 2014, 122778, 42";

            int actualReturn = list.Get(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
