using ConsoleAppData.Set.Set;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Set.Model
{
    public interface ISetable<T>
    {

        /// <summary>
        /// Добавить элемент
        /// </summary>
        public void Add(T data);

        /// <summary>
        /// Удалить элемент
        /// </summary>
        public void Remove(T data);

        /// <summary>
        /// Очистить
        /// </summary>
        public void Clear();

        /// <summary>
        /// Объединение множеств
        /// </summary>
        /// <returns></returns>
        public ListSet<T> Union(ListSet<T> set);

        /// <summary>
        /// Пересечение множеств
        /// </summary>
        /// <returns></returns>
        public ListSet<T> Intersection(ListSet<T> set);

        /// <summary>
        /// Разность множеств
        /// </summary>
        /// <returns></returns>
        public ListSet<T> Difference(ListSet<T> set);

        /// <summary>
        /// Содержит ли множество заданное подмножество
        /// </summary>
        public bool IsSubset(ListSet<T> set);

        /// <summary>
        /// Симметричная разность
        /// </summary>
        public ListSet<T> SymmetricDifference(ListSet<T> set);

        public void DisplaySet();
    }
}
