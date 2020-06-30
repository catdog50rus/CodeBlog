using ConsoleAppData.LinkedList.Model;
using System.Collections;

namespace ConsoleAppData.LinkedList.CircleLinkedList
{
    /// <summary>
    /// Кольцевой связный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircleLinkedList<T> : ILinkedListable<T>
    {
        #region Поля и Конструкоры

        /// <summary>
        /// Элемент списка
        /// </summary>
        public Item<T> Item { get; private set; }

        /// <summary>
        /// Счетчик элементов списка
        /// </summary>
        public int Count { get; private set; }

        public CircleLinkedList() { }

        public CircleLinkedList(T data)
        {
            SetItem(data);
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в конец списка
        /// </summary>
        /// <param name="data">Ячейка списка</param>
        public void Add(T data)
        {
            if (Count == 0) SetItem(data);
            else 
            {
                var next = new Item<T>(data)
                {
                    Next = Item,
                    Pervious = Item.Pervious
                };
                
                Item.Pervious.Next = next;
                Item.Pervious = next;
                Count++;
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
                Next = Item,
                Pervious = Item.Pervious
            };
            Item = item;
            Count++;
        }

        /// <summary>
        /// Вставить элемент в список после конкретного элемента
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            if (Count > 0)
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
            

        }

        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data)
        {
            if (Count > 0)
            {
                var item = Find(data);
                if (item != null)
                {
                    if (Item.Data.Equals(data))
                    {
                        Item.Pervious = item.Pervious.Next;
                        Item = item.Next;
                    }
                    else
                    {
                        item.Next.Pervious = item.Pervious;
                        item.Pervious.Next = item.Next;
                    }
                    
                    Count--;
                }
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
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Item = default;
            Count = 0;
        }

        /// <summary>
        /// Развернуть список
        /// </summary>
        /// <returns></returns>
        public CircleLinkedList<T> Reverse()
        {
            var result = new CircleLinkedList<T>();
            var current = Item;
            for (int i = 0; i < Count; i++)
            {
                result.Add(current.Pervious.Data);
                //result.Item.
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
        private void SetItem(T data)
        {
            Item = new Item<T>(data);
            Item.Next = Item;
            Item.Pervious = Item;
            Count = 1;
        }

        /// <summary>
        /// Найти в списке указанный элемент
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private Item<T> Find(T target)
        {
            if (Count != default)
            {
                var current = Item;
                for (int i = 0; i < Count; i++)
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
            var current = Item;
            for (int i = 0; i < Count; i++)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        public override string ToString()
        {
            return $"Circle Linked List: {Count} элементов";
        }

        #endregion 
    }
}
