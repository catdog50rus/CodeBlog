using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib.Model
{
    /// <summary>
    /// Базовый класс алгоритмов сортировки
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AlgorithmBase<T> where T : IComparable
    {
        /// <summary>
        /// Коллекция элементов
        /// </summary>
        public List<T> Items { get; set; }

        public int Count => Items.Count;

        public AlgorithmBase()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Меняем элементы местами
        /// </summary>
        /// <param name="posA"></param>
        /// <param name="posB"></param>
        protected void Swap(int posA, int posB)
        {
            //Проверка индексов
            if (posA < Items.Count && posB < Items.Count)
            {
                var temp = Items[posA];
                Items[posA] = Items[posB];
                Items[posB] = temp;
            }
        }

        /// <summary>
        /// Базовая реализация сортировки
        /// </summary>
        public virtual void Sort()
        {
            Items.Sort();
        }
    }
}
