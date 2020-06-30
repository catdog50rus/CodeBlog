using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppData.Queue.Model;
using System.Text;

namespace ConsoleAppData.Queue.Deque
{
    /// <summary>
    /// Deque на List<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListDeque<T> : IDeque<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Элементы очереди
        /// </summary>
        private readonly List<T> items;

        /// <summary>
        /// Первый элемент очереди
        /// </summary>
        private T Head => items.First();

        /// <summary>
        /// Последний элемент очереди
        /// </summary>
        private T Tail => items.Last();

        /// <summary>
        /// Счетчик элементов
        /// </summary>
        private int Count => items.Count;

        /// <summary>
        /// Конструкторы
        /// </summary>
        public ListDeque()
        {
            items = new List<T>();
        }
        public ListDeque(T data):this()
        {
            items.Add(data);
        }
        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить в очередь первый элемент
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(T data)
        {
            items.Insert(0, data);
        }

        /// <summary>
        /// Добавить в очередь последний элемент
        /// </summary>
        /// <param name="data"></param>
        public void AddLast(T data)
        {
            items.Add(data);
        }

        /// <summary>
        /// Получить первый элемент очереди и удалить его из очереди
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            var item = Head;
            items.Remove(Head);
            return item;
        }

        /// <summary>
        /// Получить последний элемент очереди и удалить его из очереди
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            var item = Tail;
            items.RemoveAt(Count - 1);
            return item;
        }

        /// <summary>
        /// Получить первый элемент очереди
        /// </summary>
        /// <returns></returns>
        public T First()
        {
            return Head;
        }

        /// <summary>
        /// Получить последний элемент очереди
        /// </summary>
        /// <returns></returns>
        public T Last()
        {
            return Tail;
        }

        /// <summary>
        /// Очистить очередь
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Получить счетчик элементов очереди
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Count;
        }
        #endregion

        #region
        public override string ToString()
        {
            return $"Deque на List<T> с {Count} элементами";
        }
        #endregion
    }
}
