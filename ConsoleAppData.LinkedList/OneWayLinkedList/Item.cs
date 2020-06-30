using ConsoleAppData.LinkedList.Model;

namespace ConsoleAppData.LinkedList.OneWayLinkedList
{
    /// <summary>
    /// Ячейка односвязного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Item<T> : ItemModel<T>
    {

        /// <summary>
        /// Следующая ячека списка
        /// </summary>
        public Item<T> Next { get; set; }

        /// <summary>
        /// Используем конструктор базоваго класса
        /// </summary>
        /// <param name="data"></param>
        public Item(T data) : base(data)
        {

        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
