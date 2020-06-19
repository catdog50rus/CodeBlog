using System.Collections;

namespace ConsoleAppData.LinkedList.Model
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class LinkedList<T> : IEnumerable
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
        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public LinkedList(T data)
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
        /// Добавть элемент в начало списка
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
        /// Вставить элемент в список после конкретного элемента
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data)
                        {
                            Next = current.Next
                        };
                        current.Next = item;
                        Count++;
                        return;
                    }
                    current = current.Next;
                }

            }
        }

        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                }
                else
                {
                    var current = Head.Next;
                    var previous = Head;
                    while (current != null)
                    {
                        if (current.Data.Equals(data))
                        {
                            previous.Next = current.Next;
                            Count--;
                            return;
                        }
                        previous = current;
                        current = current.Next;
                    }
                }
            }
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
            return $"Linked List: {Count} элементов";
        }
        #endregion
    }
}
