using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmLib.BubbleSort;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib.BubbleSort.Tests
{
    [TestClass()]
    public class BubbleSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            //Arrange
            var bubble = new BubbleSort<int>();
            var items = new List<int>();

            var rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
               items.Add(rnd.Next(0, 100));
            }
            bubble.Items.AddRange(items);
            items.Sort();

            //Act
            bubble.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], bubble.Items[i]);
            }
        }
    }
}