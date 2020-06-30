using ConsoleAppData.Queue.Model;
using System.Linq;

namespace ConsoleAppData.Queue.Queue
{
    /// <summary>
    /// Queue на массиве
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayQueue<T> : IQueue<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Элементы очереди
        /// </summary>
        private readonly T[] items;

        /// <summary>
        /// Первый элемент очереди
        /// </summary>
        private T Head => items.First();

        /// <summary>
        /// Счетчик элементов очереди
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Конструкторы
        /// </summary>
        public ArrayQueue(int length)
        {
            items = new T[length];
        }
        public ArrayQueue(int length, T data) : this(length)
        {
            items[0] = data;
            count++;
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в очередь
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(T data)
        {
            if (count < items.Length)
            {
                items[count] = data;
                count++;
            }
        }

        /// <summary>
        /// Извлечь элемент из очереди
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            var item = Head;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    items[i] = items[i + 1];
                }
                count--;
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
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    items[i] = default;
                }
                count = 0;
            }
        }

        public int GetCount()
        {
            return count;
        }
        #endregion

        #region Вспомогательные методы

        public override string ToString()
        {
            return $"Queue на Array<T> c {count} элементами";
        }
        #endregion
    }
}
