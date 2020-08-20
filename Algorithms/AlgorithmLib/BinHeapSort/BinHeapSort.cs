using AlgorithmLib.Model;
using ConsoleAppData.BinaryHeap.Heap;
using System;
using System.Collections.Generic;

namespace AlgorithmLib.BinHeapSort
{
    /// <summary>
    /// Реализация сортировки методом Бинарной кучи
    /// Бинарная куча реализована ранее в структурах данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinHeapSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public BinHeapSort() { }
        public BinHeapSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            //Создаем экземпляр бинарной кучи с убывающим приоритетом
            //И передаем в нее коллекцию
            Heap<T> heap = new Heap<T>(Items, -1);
            //Создать экземпляр массива для отсортированной коллекции
            List<T> sorted = new List<T>();
            sorted.AddRange(heap.GetList());

            Items.Clear();
            //Возвращаем в коллекцию отсортированный список
            Items.AddRange(sorted);
        }
    }
}
