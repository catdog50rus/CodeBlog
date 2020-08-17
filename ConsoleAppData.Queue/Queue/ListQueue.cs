using System.Collections.Generic;
using System.Linq;
using ConsoleAppData.Queue.Model;

namespace ConsoleAppData.Queue.Queue
{
    /// <summary>
    /// Queue на List<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListQueue<T> : IQueue<T>
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
        /// Счетчик элементов очереди
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// Конструкторы
        /// </summary>
        public ListQueue() 
        {
            items = new List<T>();
        }
        public ListQueue(T data):this()
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
            items.Remove(item);
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
            items.Clear();
        }

        public int GetCount()
        {
            return Count;
        }
        #endregion

        #region Вспомогательные методы

        public override string ToString()
        {
            return $"Queue на List<T> c {Count} элементами";
        }
        #endregion
    }
}