using System;

namespace ConsoleAppData.HashTable.HashTable
{
    /// <summary>
    /// HashTable на плохой Hash-функции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BadHashTable<T> : IHashable<T>
    {
        #region Поля и конструкторы
        
        /// <summary>
        /// Массив элементов HashTable
        /// </summary>
        private readonly T[] items;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="size"></param>
        public BadHashTable(int size)
        {
            items = new T[size];
        }

        #endregion

        #region Интерфейс

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            var key = GetHash(item);
            items[key] = item;
        }

        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key].Equals(item);
        }

        /// <summary>
        /// Получить элемент по значению Hash
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetItem(int key)
        {
            return items[key];
        }

        /// <summary>
        /// Распечатать HashTable
        /// </summary>
        public void DisplayHashTable()
        {
            for (int i = 0; i < items.Length / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var key = i * 10 + j;

                    Console.Write($"{items[key]}, ");
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Вспомогательные методы 

        /// <summary>
        /// Hash функция
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetHash(T item)
        {
            return item.ToString().Length;
        }

        #endregion

    }
}
