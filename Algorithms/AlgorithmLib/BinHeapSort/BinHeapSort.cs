using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppData.BinaryHeap.Heap;
using AlgorithmLib.Model;

namespace AlgorithmLib.BinHeapSort
{
    /// <summary>
    /// Реализация сортировки методом Бинарной кучи
    /// Бинарная куча реализована ранее в структурах данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinHeapSort<T> : AlgorithmBase<T> where T : IComparable
    {
        protected override void MakeSort()
        {
            Heap<T> heap = new Heap<T>(Items);
            //Создать экземпляр массива для отсортированной коллекции
            T [] sorted = new T[Count];
            int j = Count - 1;
            //Запускаем цикл сортировки
            //Получаем максимальные значения и записываем их в массив справа налево
            for (int i = 0; i < Count; i++)
            {
                sorted[j] = heap.GetMax();
                j--;
            }
            Items.Clear();
            //Возвращаем в коллекцию отсортированный массив
            Items.AddRange(sorted);

        }
    }
}
