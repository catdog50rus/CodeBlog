using System.Collections;

namespace ConsoleAppData.LinkedList.Model
{
    interface ILinkedListable<T> : IEnumerable
    {

        /// <summary>
        /// Добавить элемент в конец списка
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public void Add(T data);

        /// <summary>
        /// Добавть элемент в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data);

        /// <summary>
        /// Вставить элемент в список после конкретного элемента
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data);

        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data);

        /// <summary>
        /// Найти элемент по значению
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ItemModel<T> FindFirst(T target);

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear();

    }
}
