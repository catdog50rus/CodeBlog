using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.BinaryHeap.Model
{
    interface IBinaryHeap<T> : IComparable, IEnumerable<T>
    {
        /// <summary>
        /// Счетчик элементов
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Получить текущий приоритетный элемент
        /// </summary>
        /// <returns></returns>
        public T Peek();

        /// <summary>
        /// Получить из очереди приоритетный элемент и удалить его
        /// </summary>
        /// <returns></returns>
        public T GetMax();

        /// <summary>
        /// Добавить элемент в очередь
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item);
    }
}
