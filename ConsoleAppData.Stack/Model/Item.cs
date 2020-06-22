using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Stack.Model
{
    /// <summary>
    /// Ячейка списка
    /// </summary>
    public class Item<T>
    {
        private T data = default;

        /// <summary>
        /// Данные, хранимые в ячейке
        /// </summary>
        public T Data
        {
            get { return data; }
            set
            {
                data = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public Item<T> Previous { get; set; }

        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
