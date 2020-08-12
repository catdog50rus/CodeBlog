using AlgorithmLib.BubbleSort;
using AlgorithmLib.CoctailSort;
using AlgorithmLib.InsertSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AlgorithmTests
{
    [TestClass()]
    public class SortTests
    {
        readonly Random rnd = new Random();
        readonly List<int> items = new List<int>();

        //Arrange
        readonly InsertSort<int> insert = new InsertSort<int>();
        readonly CocktailSort<int> cocktail = new CocktailSort<int>();
        readonly BubbleSort<int> bubble = new BubbleSort<int>();

        [TestInitialize]
        public void Init()
        {
            items.Clear();
            for (int i = 0; i < 100; i++)
            {
                items.Add(rnd.Next(0, 1000));
            }

            insert.Items.AddRange(items);

            cocktail.Items.AddRange(items);

            bubble.Items.AddRange(items);

            items.Sort();
        }
        
        [TestMethod()]
        public void InsertSortTest()
        {
            //Act
            insert.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], insert.Items[i]);
            }
        }

        [TestMethod()]
        public void CocktailSortTest()
        {

            //Act
            cocktail.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], cocktail.Items[i]);
            }
        }

        [TestMethod()]
        public void BubbleSortTest()
        {

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