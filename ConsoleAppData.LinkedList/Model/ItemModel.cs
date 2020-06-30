using System;

namespace ConsoleAppData.LinkedList.Model
{
    /// <summary>
    /// Базовая ячейка списка
    /// </summary>
    public class ItemModel<T>
    {
        private T data = default;

        /// <summary>
        /// Данные, хранимые в ячейке
        /// </summary>
        public T Data
        {
            get { return data; }
            private set
            {
                data = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public ItemModel(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
