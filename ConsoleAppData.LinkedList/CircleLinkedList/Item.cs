using ConsoleAppData.LinkedList.Model;

namespace ConsoleAppData.LinkedList.CircleLinkedList
{
    /// <summary>
    /// Ячейка кольцевого списка
    /// </summary>
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

        public Item(T data): base(data)
        {
            
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
