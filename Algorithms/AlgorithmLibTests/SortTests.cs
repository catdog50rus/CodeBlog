using AlgorithmLib.BubbleSort;
using AlgorithmLib.CoctailSort;
using AlgorithmLib.InsertSort;
using AlgorithmLib.ShellSort;
using AlgorithmLib.BinTreeSeacrhSort;
using AlgorithmLib.BinHeapSort;
using AlgorithmLib.SelectionSort;
using AlgorithmLib.RadixSort;
using AlgorithmLib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AlgorithmLib.GnomeSort;

namespace AlgorithmTests
{
    [TestClass()]
    public class SortTests
    {
        readonly Random rnd = new Random();
        readonly List<int> items = new List<int>();
        readonly int Count = 1000000;


        #region TestsInit
        [TestInitialize]
        public void Init()
        {
            items.Clear();
            for (int i = 0; i < Count; i++)
            {
                items.Add(rnd.Next(0, 10000));
            }

        }
        #endregion

        #region Tests


        //[TestMethod()]
        public void InsertSortTest()
        {
            //Act
            var insert = new InsertSort<int>();
            insert.Items.AddRange(items);
            insert.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], insert.Items[i]);
            }
        }

        //[TestMethod()]
        public void CocktailSortTest()
        {

            //Act
            var cocktail = new CocktailSort<int>();
            cocktail.Items.AddRange(items);
            cocktail.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], cocktail.Items[i]);
            }
        }

        //[TestMethod()]
        public void BubbleSortTest()
        {

            //Act
            var bubble = new BubbleSort<int>();
            bubble.Items.AddRange(items);
            bubble.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], bubble.Items[i]);
            }
        }

        [TestMethod()]
        public void ShellSortTest()
        {

            //Act
            var shell = new ShellSort<int>();
            shell.Items.AddRange(items);
            shell.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], shell.Items[i]);
            }
        }

        //[TestMethod()]
        public void BinTreeSearchSortTest()
        {

            //Act
            var bts = new BinTreeSearchSort<int>();
            bts.Items.AddRange(items);
            bts.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], bts.Items[i]);
            }
        }

        [TestMethod()]
        public void BinHeapSortTest()
        {

            //Act
            var heap = new BinHeapSort<int>();
            heap.Items.AddRange(items);
            heap.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], heap.Items[i]);
            }
        }

        [TestMethod()]
        public void BaseSortTest()
        {

            //Act
            var baseSort = new AlgorithmBase<int>();
            baseSort.Items.AddRange(items);
            baseSort.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], items[i]);
            }
        }

        //[TestMethod()]
        public void SelectionSortTest()
        {

            //Act
            var selection = new SelectionSort<int>();
            selection.Items.AddRange(items);
            selection.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], selection.Items[i]);
            }
        }
        
        //[TestMethod()]
        public void GnomeSortTest()
        {

            //Act
            var gnome = new GnomeSort<int>();
            gnome.Items.AddRange(items);
            gnome.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], gnome.Items[i]);
            }
        }

        [TestMethod()]
        public void RadixLSDSortTest()
        {

            //Act
            var radixLSD = new RadixSortLSD<int>();
            radixLSD.Items.AddRange(items);
            radixLSD.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], radixLSD.Items[i]);
            }
        }

        [TestMethod()]
        public void RadixMSDSortTest()
        {

            //Act
            var radixMSD = new RadixSortMSD<int>();
            radixMSD.Items.AddRange(items);
            radixMSD.Sort();
            items.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], radixMSD.Items[i]);
            }
        }

        #endregion
    }
}