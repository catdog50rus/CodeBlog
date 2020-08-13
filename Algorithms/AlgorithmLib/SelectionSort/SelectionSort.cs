using System;
using System.Collections.Generic;
using AlgorithmLib.Model;

namespace AlgorithmLib.SelectionSort
{
    /// <summary>
    /// Реализация сортировки методом SelectionSort
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectionSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public SelectionSort() { }
        public SelectionSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            int minIndex;
            //Запускаем цикл по всей коллекции
            for (int i = 0; i < Count - 1; i++)
            {
                //Находим минимальный индекс не отсортированной части коллекции
                minIndex = i;
                //Запускаем цикл сравнения элемента с индексом minIndex
                //с элементами не сортированной части коллекции
                for (int j = i + 1; j < Count; j++)
                {
                    //Если находим элемент меньше чем выбранный, присваиваем новое значение minIndex
                    if (Compare(Items[minIndex], Items[j]) == 1)
                    {
                        minIndex = j;
                    }
                    
                }
                //
                if (minIndex != i) Swap(i, minIndex);
            }
        }
    }
}
