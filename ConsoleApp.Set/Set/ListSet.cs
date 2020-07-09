using System;
using ConsoleAppData.Set.Model;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace ConsoleAppData.Set.Set
{
    /// <summary>
    /// Множество Set на List<T>
    /// </summary>
    public class ListSet<T> : ISetable<T>, IEnumerable
    {
        #region Поля и конструкторы
        /// <summary>
        /// Элементы
        /// </summary>
        private readonly List<T> items;

        /// <summary>
        /// Счетчик элементов
        /// </summary>
        private int Count => items.Count;

        /// <summary>
        /// Конструкторы
        /// </summary>
        public ListSet()
        {
            items = new List<T>();
        }
        public ListSet(T data) : base()
        {
            items.Add(data);
        }
        public ListSet(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (!items.Contains(data))
            {
                items.Add(data);
            }
        }

        /// <summary>
        /// Очистить
        /// </summary>
        public void Clear()
        {
            items.Clear();
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
        /// Разность множеств
        /// </summary>
        /// <returns></returns>
        public ListSet<T> Difference(ListSet<T> set)
        {
            return new ListSet<T>(items.Except(set.items));
        }

        /// <summary>
        /// Пересечение множеств
        /// </summary>
        /// <returns></returns>
        public ListSet<T> Intersection(ListSet<T> set)
        {
            return new ListSet<T>(items.Intersect(set.items));
        }

        /// <summary>
        /// Содержит ли множество заданное подмножество
        /// </summary>
        public bool IsSubset(ListSet<T> set)
        {
            return set.items.All(i => items.Contains(i));
        }

        /// <summary>
        /// Симметричная разность
        /// </summary>
        public ListSet<T> SymmetricDifference(ListSet<T> set)
        {
            var temp = Intersection(set);
            var tempUnion = Union(set);
            return tempUnion.Difference(temp);
        }

        /// <summary>
        /// Объединение множеств
        /// </summary>
        /// <returns></returns>
        public ListSet<T> Union(ListSet<T> set)
        {
            return new ListSet<T>(items.Union(set.items));
        }

        /// <summary>
        /// Выводит в консоль заданное множество
        /// </summary>
        public void DisplaySet()
        {
            for (int i = 0; i < Count; i++)
            {
                if (i < Count - 1)
                {
                    Console.Write($"{items[i]}, ");
                }
                else
                {
                    Console.Write($"{items[i]}");
                }

            }
            Console.WriteLine();
        }

        #endregion

        #region Вспомогательные методы

        public int GetCount()
        {
            return Count;
        }

        public T GetItem(int i)
        {
            return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion
    }
}
