using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppData.Queue.Model;
using ConsoleAppData.LinkedList.TwoWayLinkedList;

namespace ConsoleAppData.Queue.Deque
{
    public class LinkedListDeque<T> : IDeque<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Элементы очереди
        /// </summary>
        private readonly TwoWayLinkedList<T> items;

        /// <summary>
        /// Первый элемент очереди
        /// </summary>
        private T Head => items.Head.Data;

        /// <summary>
        /// Последний элемент очереди
        /// </summary>
        private T Tail => items.Tail.Data;

        /// <summary>
        /// Счетчик элементов
        /// </summary>
        private int Count => items.Count;

        /// <summary>
        /// Конструкторы
        /// </summary>
        public LinkedListDeque()
        {
            items = new TwoWayLinkedList<T>();
        }
        public LinkedListDeque(T data) : base()
        {
            items.Add(data);
        }

        #endregion

        /// <summary>
        /// Добавить в очередь первый элемент
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(T data)
        {
            items.AppendHead(data);
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
        /// Очистить очередь
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Получить первый элемент очереди
        /// </summary>
        /// <returns></returns>
        public T First()
        {
           return items.Head.Data;
        }

        /// <summary>
        /// Получить счетчик элементов очереди
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return items.Count;
        }

        /// <summary>
        /// Получить последний элемент очереди
        /// </summary>
        /// <returns></returns>
        public T Last()
        {
            return items.Tail.Data;
        }

        /// <summary>
        /// Получить первый элемент очереди и удалить его из очереди
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            var item = Head;
            items.RemoveFirst();
            return item;
        }

        /// <summary>
        /// Получить последний элемент очереди и удалить его из очереди
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            var item = Tail;
            items.RemoveLast();
            return item;
        }


        #region Вспомогательные методы

        public override string ToString()
        {
            return $"Queue на TwoWayLinkedList<T> c {Count} элементами";
        }
        #endregion
    }
}
