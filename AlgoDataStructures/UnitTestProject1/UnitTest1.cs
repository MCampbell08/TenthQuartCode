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
            Assert.AreEqual(ArrayToString(expectedArray), ArrayToString(actualArray));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DLL_ListOfTen_GetAt5()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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
