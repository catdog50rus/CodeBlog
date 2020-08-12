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
        #region Поля и конструктор

        /// <summary>
        /// Коллекция элементов
        /// </summary>
        public List<T> Items { get; }

        /// <summary>
        /// Счетчик элементов коллекции
        /// </summary>
        protected int Count => Items.Count;

        /// <summary>
        /// Счетчик количества выполненных замен
        /// </summary>
        protected int SwapCount { get; set; }

        /// <summary>
        /// Счетчик количества выполненных сравнений
        /// </summary>
        protected int ComparisonCount { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public AlgorithmBase()
        {
            Items = new List<T>();
            SwapCount = 0;
            ComparisonCount = 0;
        }

        #endregion

        #region Интерфейс

        /// <summary>
        /// Сортировка элементов
        /// </summary>
        public void Sort()
        {
            //Устанавливаем счетчики
            SwapCount = 0;
            ComparisonCount = 0;

            //Вызываем метод сортировки
            MakeSort();
        }

        #endregion

        #region Вспомогательные методы и реализация

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

                SwapCount++;
            }
        }

        /// <summary>
        /// Базовая реализация сортировки
        /// </summary>
        protected virtual void MakeSort()
        {
            Items.Sort();
        }

        #endregion
    }
}
