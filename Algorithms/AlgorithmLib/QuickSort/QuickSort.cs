using AlgorithmLib.Model;
using System;
using System.Collections.Generic;

namespace AlgorithmLib.QuickSort
{
    /// <summary>
    /// Реализация быстрой сортировки
    /// QuickSort
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public QuickSort() { }
        public QuickSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            base.MakeSort();
        }
    }
}
