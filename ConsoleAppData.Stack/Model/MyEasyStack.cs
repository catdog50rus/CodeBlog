using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppData.Stack.Model
{
    /// <summary>
    /// Реализация Стек на List<T>
    /// </summary>
    public class MyEasyStack<T>
    {
        #region Поля и конструктор
        /// <summary>
        /// основа Стека
        /// </summary>
        private List<T> _items;

        /// <summary>
        /// Счетчик элементов
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Флаг заполненности
        /// </summary>
        public bool IsEmpty => _items.Count == 0;

        public MyEasyStack()
        {
            _items = new List<T>();
        }
        #endregion

        #region Методы
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Получить элемент Стека и удалить его
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {

            var item = GetItem();
            _items.Remove(item);
            return item;
        }

        /// <summary>
        /// Получить элемент Стека
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return GetItem();
        }

        /// <summary>
        /// Очистить Стек
        /// </summary>
        public void Clear()
        {
            _items = null;
        }

        /// <summary>
        /// Получить клон Стека
        /// </summary>
        /// <returns></returns>
        public MyEasyStack<T> Clone()
        {
            var newStack = new MyEasyStack<T>
            {
                _items = new List<T>(_items)
            };
            return newStack;
        }
        #endregion

        #region Вспомогательный методы
        public override string ToString()
        {
            return $"Стек на List<T> с {Count} элементами";
        }

        private T GetItem()
        {
            if (!IsEmpty)
            {
                var item = _items.LastOrDefault();
                return item;
            }
            else
            {
                throw new NullReferenceException("Stack empty");
            }
        }
        #endregion


    }
}
