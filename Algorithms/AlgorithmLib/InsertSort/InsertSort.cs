using System;
using AlgorithmLib.Model;

namespace AlgorithmLib.InsertSort
{
    /// <summary>
    /// Реализация сортировки ставками
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertSort<T> : AlgorithmBase<T> where T:IComparable
    {
        protected override void MakeSort()
        {
            //Запускаем цикл, проходящий по коллекции слева направо
            //начиная со второго элемента
            for (int i = 1; i < Count; i++)
            {
                T tmp = Items[i];
                int j = i;
                //Запускаем цикл, сравнивающий выбранный элемент
                //с элементами отсортированной коллекции слева
                //Если элемент меньше чем элемент слева, то меняем их местами
                //Выход из цикла по установке элемента на свое место
                while (j > 0 && tmp.CompareTo(Items[j - 1]) == - 1)
                {
                    Swap(j - 1, j);
                    j--;
                }
                ComparisonCount++;
            }
        }

    }
}
