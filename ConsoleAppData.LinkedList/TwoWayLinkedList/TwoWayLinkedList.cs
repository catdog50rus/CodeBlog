using System;
using ConsoleAppData.LinkedList.Model;
using System.Collections;

namespace ConsoleAppData.LinkedList.TwoWayLinkedList
{
    /// <summary>
    /// Двусвязный список
    /// </summary>
    public class TwoWayLinkedList<T> : ILinkedListable<T>
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
        public TwoWayLinkedList() { }

        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public TwoWayLinkedList(T data)
        {
            var item = new Item<T>(data);
            SetHead(item);
        }
        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в конец списка
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public void Add(T data)
        {
            var item = new Item<T>(data);
            if (Tail != null)
            {
                Tail.Next = item;
                item.Pervious = Tail;
                Tail = item;
                Count++;
            }
            else
            {
                SetHead(item);
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
            Head.Next.Pervious = Head;
            Count++;
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Head = default;
            Tail = default;
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
                if (Head.Equals(current))
                {
                    if (current.Next != null)
                    {
                        Head = Head.Next;
                        Head.Pervious = null;
                    }
                    else
                    {
                        Clear();
                    }
                }
                else if (Tail.Equals(current))
                {
                    Tail.Pervious.Next = current.Next;
                    Tail = current.Pervious;
                }
                else
                {
                    current.Pervious.Next = current.Next;
                    current.Next.Pervious = current.Pervious;
                }
                Count = Count == 0 ? 0 : --Count;
            }
            else
            {
                throw new Exception("Элемент не найден!");
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
                    Next = current.Next,
                    Pervious = current
                    
                };
                current.Next = item;
                item.Next.Pervious = item;
                Count++;
            }

        }

        /// <summary>
        /// Развернуть список
        /// </summary>
        /// <returns></returns>
        public TwoWayLinkedList<T> Reverse()
        {
            var result = new TwoWayLinkedList<T>();
            var current = Tail;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Pervious;
            }
            return result;
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Установка данных в первую ячейку
        /// </summary>
        /// <param name="data"></param>
        private void SetHead(Item<T> item)
        {
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
            };
        }

        public override string ToString()
        {
            return $"TwoWay Linked List: {Count} элементов";
        }

        #endregion  
    }
}
