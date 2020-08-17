using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib.RadixSort
{
    /// <summary>
    /// Реализация по-разрядной сортировки начиная со старшего разряда
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RadixSortMSD<T> : RadixSort<T> where T : IComparable
    {
        /// <summary>
        /// Максимальное количество разрядов в коллекции
        /// </summary>
        private int maxLength;

        public RadixSortMSD() { }
        public RadixSortMSD(IEnumerable<T> items) : base(items) { }

        /// <summary>
        /// Отсортировать коллекцию
        /// </summary>
        protected override void MakeSort()
        {
            var result = new List<T>();
            maxLength = GetLength(Items);
            result.AddRange(SortCollection(Items, maxLength - 1));
            Items.Clear();
            Items.AddRange(result);
        }

        /// <summary>
        /// Сортировка коллекции
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        private List<T> SortCollection(List<T> collection, int step)
        {
            //Получаем максимальное количество разрядов чисел из коллекции
            var result = new List<T>();
            var groups = new List<Queue<T>>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new Queue<T>());
            }

            //Распределение элементов по корзинам
            //Распределение идет на основе разряда справа налево
            foreach (var item in collection)
            {
                int i = item.GetHashCode();
                int value = (i % (int)Math.Pow(10, step + 1)) / (int)Math.Pow(10, step);
                groups[value].Enqueue(item);
            }

            //Перебор элементов корзинах
            //Элементы отсортированы по старшему разряду
            //Проверяем количество элементов в каждой корзине и рекурсивно сортируем их
            foreach (var group in groups)
            {
                if (group.Count == 0) continue;
                if (group.Count == 1)
                {
                    result.AddRange(group);
                    group.Clear();
                    continue;
                }
                
                if (group.Count > 1)
                {
                    var list = new List<T>();
                    list.AddRange(group);
                    if (step > 0)
                    {
                        group.Clear();
                        result.AddRange(SortCollection(list, step - 1));
                    }
                    else
                    {
                        result.AddRange(group);
                        group.Clear();
                    }
                }
            }
            return result;
        } 
    }
}
