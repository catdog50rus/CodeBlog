using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmLib.Model;

namespace AlgorithmLib.ShellSort
{
    public class ShellSort<T> : AlgorithmBase<T> where T : IComparable
    {
        /// <summary>
        /// Реализация алгоритма сортировки Шелла
        /// </summary>
        protected override void MakeSort()
        {
            //Находим шаг
            int step = Count / 2;
            //Запускаем цикл
            //Разбиваем коллекцию на под коллекции в соответствии с шагом
            while (step > 0)
            {
                //Перебираем под коллекции
                for (int i = step; i < Count; i++)
                {
                    int j = i;
                    //Сортируем под коллекции
                    while ((j >= step) && Items[j].CompareTo(Items[j - step]) == -1)
                    {
                        Swap(j, j - step);
                        j -= step;
                    }
                    ComparisonCount++;
                }
                step /= 2;
            }
        }
    }
}
