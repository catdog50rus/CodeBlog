using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ConsoleAppData.BinaryHeap.Model;

namespace ConsoleAppData.BinaryHeap.Heap
{
    /// <summary>
    /// Реализация двоичной кучи
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> : IBinaryHeap<T>
          where T : IComparable
    {
        #region Поля и конструкторы

        /// <summary>
        /// Список элементов
        /// </summary>
        private readonly List<T> items;

        /// <summary>
        /// Корневой элемент
        /// </summary>
        private T Parent => items[0];

        /// <summary>
        /// Счетчик элементов
        /// </summary>
        public int Count => items.Count;

        public Heap()
        {
            items = new List<T>();
        }

        public Heap(IEnumerable<T> list) : this()
        {
            items.AddRange(list);
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Получить текущий приоритетный элемент
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count > 0)
            {
                return Parent;
            }
            else return default;
        }

        /// <summary>
        /// Добавить элемент в очередь
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            items.Add(item);
            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);
            while (currentIndex > 0 && items[parentIndex].CompareTo(item) == -1)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        /// <summary>
        /// Получить из очереди приоритетный элемент и удалить его
        /// </summary>
        /// <returns></returns>
        public T GetMax()
        {
            var result = Peek();
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        #endregion

        #region Вспомогательные методы и реализация

        /// <summary>
        /// Реализация сортировки очереди по приоритету
        /// </summary>
        /// <param name="index"></param>
        private void Sort(int index)
        {
            int maxIndex, leftIndex, rightIndex;
            while (index < Count)
            {
                maxIndex = index;
                leftIndex = 2 * index + 1;
                rightIndex = 2 * index + 2;

                if (leftIndex < Count && items[leftIndex].CompareTo(items[maxIndex]) == 1)
                {
                    maxIndex = leftIndex;
                }
                if (rightIndex < Count && items[rightIndex].CompareTo(items[maxIndex]) == 1)
                {
                    maxIndex = rightIndex;
                }
                if (maxIndex == index) break;
                Swap(index, maxIndex);
                index = maxIndex;

            }
        }

        /// <summary>
        /// Реализация замены элементов местами
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="parentIndex"></param>
        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;
        }

        /// <summary>
        /// Реализация расчета корневого индекса
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        /// <summary>
        /// Реализация вывода очереди на консоль
        /// </summary>
        public void PrintHeap()
        {

            for (int i = 0; i < Count - 1; i++)
            {
                Console.Write($"{items[i]}, ");
            }
            Console.WriteLine(items[Count - 1]);

            Console.WriteLine();
        }

        #region Переопределение методов

        public int CompareTo(object obj)
        {
            if (obj is T item)
            {
                return Parent.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Несовпадение типов");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (Count > 0)
            {
                yield return GetMax();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion



        #endregion


    }
}
