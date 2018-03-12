using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
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

       
        
    }
}
