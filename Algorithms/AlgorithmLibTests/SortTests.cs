﻿using AlgorithmLib.BubbleSort;
using AlgorithmLib.CoctailSort;
using AlgorithmLib.InsertSort;
using AlgorithmLib.ShellSort;
using AlgorithmLib.BinTreeSeacrhSort;
using AlgorithmLib.BinHeapSort;
using AlgorithmLib.SelectionSort;
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
        readonly int Count = 10000;

        //Arrange
        readonly InsertSort<int> insert = new InsertSort<int>();
        readonly CocktailSort<int> cocktail = new CocktailSort<int>();
        readonly BubbleSort<int> bubble = new BubbleSort<int>();
        readonly ShellSort<int> shell = new ShellSort<int>();
        readonly BinTreeSearchSort<int> bts = new BinTreeSearchSort<int>();
        readonly BinHeapSort<int> heap = new BinHeapSort<int>();
        readonly AlgorithmBase<int> baseSort = new AlgorithmBase<int>();
        readonly SelectionSort<int> selection = new SelectionSort<int>();
        readonly GnomeSort<int> gnome = new GnomeSort<int>();

        #region TestsInit
        [TestInitialize]
        public void Init()
        {
            items.Clear();
            for (int i = 0; i < Count; i++)
            {
                items.Add(rnd.Next(0, 10000));
            }

            insert.Items.AddRange(items);

            cocktail.Items.AddRange(items);

            bubble.Items.AddRange(items);

            shell.Items.AddRange(items);

            bts.Items.AddRange(items);
            heap.Items.AddRange(items);
            baseSort.Items.AddRange(items);
            selection.Items.AddRange(items);
            gnome.Items.AddRange(items);

            items.Sort();
        }
        #endregion

        #region Tests


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

        [TestMethod()]
        public void ShellSortTest()
        {

            //Act
            shell.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], shell.Items[i]);
            }
        }

        [TestMethod()]
        public void BinTreeSearchSortTest()
        {

            //Act
            bts.Sort();

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
            heap.Sort();

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
            baseSort.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], baseSort.Items[i]);
            }
        }

        [TestMethod()]
        public void SelectionSortTest()
        {

            //Act
            selection.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], selection.Items[i]);
            }
        }
        
        [TestMethod()]
        public void GnomeSortTest()
        {

            //Act
            gnome.Sort();

            //Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i], gnome.Items[i]);
            }
        }

        #endregion
    }
}