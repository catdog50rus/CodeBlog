using System.Collections;
using ConsoleAppData.LinkedList.Model;

namespace ConsoleAppData.LinkedList.OneWayLinkedList
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OneWayLinkedList<T> : ILinkedListable<T>
    {
        #region Поля и Конструкоры
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail { get; private set; }
        
        /// <summary>
        /// Счетчик элементов списка
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Создать пустой список
        /// </summary>
        public OneWayLinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public OneWayLinkedList(T data)
        {
            SetHeadAndTail(data);
        }
        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в конец списка
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public void Add(T data)
        {

            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        /// <summary>
        /// Добавить элемент в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data)
        {

            var current = Find(data);
            if (current != null)
            {
                if (Head == current)
                {
                    Head = Head.Next;
                }
                else
                {
                    Head.Next = current.Next;
                }
                Count--;
                if (Head == null) Tail = null;

            }
        }

        /// <summary>
        /// Найти элемент по значению
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ItemModel<T> FindFirst(T target)
        {
            return Find(target);
        }

        /// <summary>
        /// Вставить элемент в список после конкретного элемента
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            var current = Find(target);
            if (current != null)
            {
                var item = new Item<T>(data)
                {
                    Next = current.Next
                };
                current.Next = item;
                Count++;
            }

        }

        
        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Установка данных в первую ячейку
        /// </summary>
        /// <param name="data"></param>
        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Найти в списке указанный элемент
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private Item<T> Find(T target)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        return current;

                    }
                    current = current.Next;
                }
            }
            return null;
        }

        /// <summary>
        /// Получить перечисление всех элементов списка
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"OneWay Linked List: {Count} элементов";
        }

        #endregion
    }
}
