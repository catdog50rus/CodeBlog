using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgorithmLib.Model;

namespace AlgorithmLib.MergeSort
{
    /// <summary>
    /// Реализация сортировки слиянием
    /// MergeSort
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public MergeSort() { }
        public MergeSort(IEnumerable<T> items) : base(items) { }


        protected override void MakeSort()
        {
            var result = Sort(Items);
            Items.Clear();
            Items.AddRange(result);
        }

        /// <summary>
        /// Реализация сортировки
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<T> Sort(List<T> items)
        {
            //Если в коллекции всего один элемент
            //просто возвращаем этот элемент
            if (items.Count == 1) return items;
            
            //Разбиваем коллекцию пополам
            var mid = items.Count / 2;
            var left = items.Take(mid).ToList();
            var rigth = items.Skip(mid).ToList();

            //Рекурсивно вызываем слияние получившихся коллекций
            return Merge(Sort(left), Sort(rigth));
        }

        /// <summary>
        /// Реализация слияние коллекций с сортировкой по возрастанию
        /// </summary>
        /// <param name="left"></param>
        /// <param name="rigth"></param>
        /// <returns></returns>
        private List<T> Merge(List<T> left, List<T> rigth)
        {
            //Общая длинна обоих коллекций
            int length = left.Count + rigth.Count;
            //Указатели коллекций
            int leftPointer = 0;
            int rigthPointer = 0;
            //Результирующая коллекция
            var result = new List<T>();

            //Проходим по всем элементам обоих коллекций
            for (int i = 0; i < length; i++)
            {
                //Проверяем, что указатели в пределах коллекций
                if (leftPointer < left.Count && rigthPointer < rigth.Count)
                {
                    //Если элемент левой коллекции меньше элемента правой, добавляем его
                    //Передвигаем указатель
                    if (Compare(left[leftPointer], rigth[rigthPointer]) == -1)
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                    //Иначе, добавляем элемент правый коллекции
                    //Передвигаем указатель
                    else
                    {
                        result.Add(rigth[rigthPointer]);
                        rigthPointer++;
                    }
                }
                //Если один из указателей вышел за границу коллекции
                //Проверяем какой именно указатель вышел и добавляем оставшуюся часть другой коллекции
                //Выходим из цикла
                else
                {
                    if (rigthPointer < rigth.Count)
                    {
                        result.AddRange(rigth.Skip(rigthPointer));
                        break;
                    }
                    else
                    {
                        result.AddRange(left.Skip(leftPointer));
                        break;
                    }
                }
            }

            //Возвращаем результирующую коллекцию
            return result;
        }
    }
}
