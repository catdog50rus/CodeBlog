using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmLib.CoctailSort;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib.CoctailSort.Tests
{
    [TestClass()]
    public class CoctailSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            //Arrange
            var cocktail = new CocktailSort<int>();
            var items = new List<int>();

            var rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                items.Add(rnd.Next(0, 100));
            }
            cocktail.Items.AddRange(items);
            items.Sort();

            //Act
            cocktail.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], cocktail.Items[i]);
            }
        }
    }
}