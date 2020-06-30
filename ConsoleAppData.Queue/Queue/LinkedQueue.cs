using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleAppData.Queue.Model;
using ConsoleAppData.LinkedList.OneWayLinkedList;

namespace ConsoleAppData.Queue.Queue
{
    /// <summary>
    /// Очередь на Односвязнос списке.
    /// Реализация односвязного списка взята из соответствующего проекта
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedQueue<T> : IQueue<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Элементы очереди
        /// </summary>
        private readonly OneWayLinkedList<T> items;

        /// <summary>
        /// Первый элемент очереди
        /// </summary>
        private T Head => items.Head.Data;

        /// <summary>
        /// Счетчик элементов очереди
        /// </summary>
        private int Count => items.Count;

        /// <summary>
        /// Конструкторы
        /// </summary>
        public LinkedQueue()
        {
            items = new OneWayLinkedList<T>();
        }
        public LinkedQueue(T data) : this()
        {
            items.Add(data);
        }


        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в очередь
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(T data)
        {
            items.Add(data);
        }

        /// <summary>
        /// Извлечь элемент из очереди
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            var item = Head;
            if (Count > 0)
            {
                items.Delete(Head);
            }
            return item;

        }

        /// <summary>
        /// Получить текущий элемент очереди
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return Head;
        }

        /// <summary>
        /// Очистить очередь
        /// </summary>
        public void Clear()
        {
            if (Count > 0)
            {
                items.Clear();
            }
        }

        public int GetCount()
        {
            return Count;
        }
        #endregion

        #region Вспомогательные методы

        public override string ToString()
        {
            return $"Queue на OneWayLinkedList<T> c {Count} элементами";
        }
        #endregion
    }
}
