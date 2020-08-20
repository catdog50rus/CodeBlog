using AlgorithmLib.Model;
using System;
using System.Collections.Generic;

namespace AlgorithmLib.BubbleSort
{
    /// <summary>
    /// Реализация алгоритма сортировки пузырьком
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public BubbleSort() { }
        public BubbleSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            int count = Count;
            //Цикл проходов по общему количеству элементов
            for (int j = 0; j < count; j++)
            {
                //Цикл прохода по всем элементам
                //Сравниваем рядом стоящие элементы,
                //в случае необходимости меняем элементы местами
                for (int i = 0; i < count -j -1; i++)
                {
                    
                    T a = Items[i];
                    T b = Items[i + 1];
                    if (Compare(a,b) == 1)
                    {
                        //Вызов метода перестановки местами элементов из базового класса
                        Swap(i, i + 1);
                    }
                    
                }
            }
        }
    }
}
