using AlgorithmLib.Model;
using System;
using System.Collections.Generic;

namespace AlgorithmLib.RadixSort
{
    /// <summary>
    /// Реализация сортировки по-разрядно
    /// Базовый класс для двух видов сортировки
    /// начиная с младшего разряда и начиная со старшего разряда
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RadixSort<T> : AlgorithmBase<T> where T : IComparable
    {
        /// <summary>
        /// Лист очередей, включающий элементы коллекции по разряду
        /// </summary>
        protected List<Queue<T>> groups;

        public RadixSort() : base()
        {
            //Создаем и инициализируем коллекцию очередей по цифре разряда
            groups = new List<Queue<T>>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new Queue<T>());
            }
        }
        public RadixSort(IEnumerable<T> items) : base(items)
        {
            
        }

        /// <summary>
        /// Получить максимальную длину элемента в разрядах
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected int GetLength(IEnumerable<T> collection)
        {
            int length = 0;
            foreach (var item in collection)
            {
                int n = item.GetHashCode();
                int len = 0;
                if (n < 0)
                {
                    throw new ArgumentException("Поразрядная сортировка поддерживает только неотрицательные числа");
                }
                if (n == 0)
                {
                    len = 0;
                }
                else
                {
                    len = (int)Math.Log10(n) + 1;
                }
                if (len > length) length = len;
 
            }
            return length;
        }

        /// <summary>
        /// Заполнить коллекцию элементов из корзин
        /// </summary>
        /// <param name="groups"></param>
        /// <returns></returns>
        protected List<T> AddItems(List<Queue<T>> groups)
        {
            var collection = new List<T>();
            foreach (var group in groups)
            {
                var count = group.Count;
                for (int i = 0; i < count; i++)
                {
                    collection.Add(group.Dequeue());
                }
            }
            return collection;
        }
    }
}
