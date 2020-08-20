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
            Sort(0, Count-1);
        }

        private void Sort(int left, int rigth)
        {
            if (left >= rigth) return;

            //Опорная точка
            var pivot = Sorting(left, rigth);
            //Рекурсивно сортируем коллекцию слева и справа от опорной точки
            Sort(left, pivot - 1);
            Sort(pivot + 1, rigth);
        }

        private int Sorting(int left, int rigth)
        {
            //Указатель
            var pointer = left;
            for (int i = left; i <= rigth; i++)
            {
                //Сортируем коллекцию, таким образом, чтобы 
                //меньшие элементы располагались левее указателя
                if(Compare(Items[i], Items[rigth]) == -1)
                {
                    Swap(pointer, i);
                    pointer++;
                }
            }
            Swap(pointer, rigth);


            return pointer;
        }
    }
}
