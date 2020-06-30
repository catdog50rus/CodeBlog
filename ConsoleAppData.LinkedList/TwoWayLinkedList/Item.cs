using ConsoleAppData.LinkedList.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.LinkedList.TwoWayLinkedList
{
    /// <summary>
    /// Элемент двусвязного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Item<T> : ItemModel<T>
    {
        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public Item<T> Next { get; set; }

        /// <summary>
        /// Предыдущая ячейка списка
        /// </summary>
        public Item<T> Pervious { get; set; }

        public Item(T data) : base(data) { }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
