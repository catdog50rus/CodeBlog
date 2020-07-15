using ConsoleAppData.HashTable.SuperHash;
using System;

namespace ConsoleAppData.Set.Set
{
    /// <summary>
    /// Реализация множества на основе Хеш - таблицы
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTableSet<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Хеш таблица
        /// </summary>
        private SuperHash<T> items;
        /// <summary>
        /// Счетчик элементов хеш таблицы
        /// </summary>
        private int Count => items.GetHashSize();

        public HashTableSet(int size)
        {
            items = new SuperHash<T>(size);
        }
        public HashTableSet(int size, T data) : this(size)
        {
            items.Add(data);
        }
        public HashTableSet(int size, T[] data) : this(size)
        {
            foreach (var item in data)
            {
                Add(item);
            }
        }
        #endregion

        #region Открытие методы

        /// <summary>
        /// Добавить элемент во множество
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (!items.Search(data)) items.Add(data);
        }

        /// <summary>
        /// Очистить множество
        /// </summary>
        public void Clear()
        {
            items = new SuperHash<T>(Count);
        }

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="data"></param>
        public void Remove(T data)
        {

            items.Remove(data);
        }

        /// <summary>
        /// Объединение множеств
        /// </summary>
        /// <returns></returns>
        public HashTableSet<T> Union(HashTableSet<T> set)
        {
            int resSize = Count + set.Count;
            HashTableSet<T> result = new HashTableSet<T>(resSize);
            for (int i = 0; i < Count; i++)
            {
                var list = items.GetItem(i);
                foreach (var item in list)
                {
                    result.Add(item);
                }
            }
            for (int i = 0; i < set.Count; i++)
            {
                var list = set.items.GetItem(i);
                foreach (var item in list)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Пересечение множеств
        /// </summary>
        /// <returns></returns>
        public HashTableSet<T> Intersection(HashTableSet<T> set)
        {
            int resSize = (Count >= set.Count) ? Count : set.Count;
            HashTableSet<T> result = new HashTableSet<T>(resSize);
            for (int i = 0; i < Count; i++)
            {

                var list = items.GetItem(i);
                foreach (var item in list)
                {
                    if (set.items.Search(item))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Разность множеств
        /// </summary>
        /// <returns></returns>
        public HashTableSet<T> Difference(HashTableSet<T> set)
        {
            int resSize = Count;
            HashTableSet<T> result = new HashTableSet<T>(resSize);
            for (int i = 0; i < Count; i++)
            {

                var list = items.GetItem(i);
                foreach (var item in list)
                {
                    if (!set.items.Search(item))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Симметричная разность
        /// </summary>
        public HashTableSet<T> SymmetricDifference(HashTableSet<T> set)
        {
            var temp = Intersection(set);
            var tempUnion = Union(set);
            return tempUnion.Difference(temp);
        }

        /// <summary>
        /// Содержит ли множество заданное подмножество
        /// </summary>
        public bool IsSubset(HashTableSet<T> set)
        {

            for (int i = 0; i < set.Count; i++)
            {

                var list = set.items.GetItem(i);
                foreach (var item in list)
                {
                    if (!items.Search(item))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Вывести множество на консоль
        /// </summary>
        public void DisplaySet()
        {
            items.DisplayHashTable();
            Console.WriteLine();
        }

        #endregion

    }
}
