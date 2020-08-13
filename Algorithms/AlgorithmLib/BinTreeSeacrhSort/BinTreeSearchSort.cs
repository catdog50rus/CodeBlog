using System;
using System.Collections.Generic;
using AlgorithmLib.Model;
using ConsoleAppData.BinarySearchTree.BST;

namespace AlgorithmLib.BinTreeSeacrhSort
{
    /// <summary>
    /// Реализация сортировки Бинарным деревом поиска
    /// Бинарное дерево поиска ранее реализовано в структурах данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinTreeSearchSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public BinTreeSearchSort() { }
 
        public BinTreeSearchSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            var tree = new BSTree<T>(Items);
            var sorted = tree.InOrder();
            Items.Clear();
            Items.AddRange(sorted);
        }
    }
}
