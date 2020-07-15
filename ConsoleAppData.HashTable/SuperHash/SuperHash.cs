using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppData.HashTable.SuperHash
{
    public class SuperHash<T>
    {
        #region Поля и конструкторы
        /// <summary>
        /// Основа таблица массив элементов типа Item
        /// Элемент типа Item<T> основан на List<T>
        /// </summary>
        private readonly Item<T>[] items;

        public SuperHash(int size)
        {
            items = new Item<T>[size];
            //Инициализируем массив элементами
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            }
        }
        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в таблицу
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            var key = GetHash(item);
            items[key].Nodes.Add(item);
        }

        /// <summary>
        /// Удалить элемент из таблицы
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            var key = GetHash(item);
            items[key].Nodes.Remove(item);
        }

        /// <summary>
        /// Найти элемент в таблице
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key]?.Nodes.Contains(item) ?? false;
        }
        #endregion

        /// <summary>
        /// Хеш - функция
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetHash(T item)
        {
            return item.GetHashCode() % (items.Length);
        }

        /// <summary>
        /// Распечатать HashTable
        /// </summary>
        public void DisplayHashTable()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (i % 20 == 0) Console.WriteLine();
                if (items[i].Nodes.Count > 0)
                {
                    foreach (var item in items[i].Nodes)
                    {
                        Console.Write($"{item}, ");
                    }
                }
            }
        }

        /// <summary>
        /// Получить размер таблицы
        /// </summary>
        /// <returns></returns>
        public int GetHashSize()
        {
            return items.Length;
        }

        /// <summary>
        /// Получить коллекцию элементов по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> GetItem(int key)
        {
            return items[key].Nodes.ToList<T>();
        }

    }
}
