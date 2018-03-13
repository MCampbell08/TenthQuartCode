using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;

namespace AlgoDataTests
{
    [TestClass]
    public class UnitTest1
    {
        public string ArrayToString(int [] avl)
        {
            return string.Join(", ", avl);
        }
        private DoubleLinkedList<int> CreateDLLTen()
        {
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();

            dll.Add(24);
            dll.Add(3);
            dll.Add(6);
            dll.Add(0);
            dll.Add(6);
            dll.Add(17);
            dll.Add(100);
            dll.Add(2014);
            dll.Add(122778);
            dll.Add(42);

            return dll;
        }
        private DoubleLinkedList<int> CreateDLLOne()
        {
            DoubleLinkedList<int> dll = new DoubleLinkedList<int>();

            dll.Add(24);

            return dll;
        }
        private SingleLinkedList<int> CreateSLLTen()
        {
            SingleLinkedList<int> sll = new SingleLinkedList<int>();

            sll.Add(24);
            sll.Add(3);
            sll.Add(6);
            sll.Add(0);
            sll.Add(6);
            sll.Add(17);
            sll.Add(100);
            sll.Add(2014);
            sll.Add(122778);
            sll.Add(42);

            return sll;
        }

        [TestMethod]
        public void DLL_ListOfTen_GetAt5()
        {
            DoubleLinkedList<int> list = CreateDLLTen();
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
        [TestMethod]
        public void SLL_ListOfTen_RemoveAt5()
        {
            SingleLinkedList<int> list = CreateSLLTen();
            int expectedReturn = 17;
            int expectedCount = 9;
            string expectedString = "24, 3, 6, 0, 6, 100, 2014, 122778, 42";

            int actualReturn = list.RemoveAt(5);
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void DLL_ListOfOne()
        {
            DoubleLinkedList<int> list = CreateDLLOne();
            int expectedCount = 1;
            string expectedString = "24";

            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
