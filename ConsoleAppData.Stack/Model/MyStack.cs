using System;

namespace ConsoleAppData.Stack.Model
{
    /// <summary>
    /// Реализация Стека на элементах модели Item
    /// Односвязный список
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Текущий элемент Стека
        /// </summary>
        private Item<T> _current;

        /// <summary>
        /// Счетчик количества элементов Стека
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Признак заполнения Стека
        /// </summary>
        public bool IsEmpty => Count == 0;

        public MyStack() => CreateNewStack();

        public MyStack(T data)
        {
            _current = new Item<T>(data);
            Count = 1;
        }
        #endregion

        #region Методы

        /// <summary>
        /// Добавление элемента в Стек
        /// </summary>
        /// <param name="data"></param>
        public void Push(T data)
        {
            var item = new Item<T>(data)
            {
                Previous = _current
            };
            _current = item;
            Count++;
        }

        /// <summary>
        /// Получение текущего элемента Стека и его удаление
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var item = GetItem();
            _current = _current.Previous;
            Count--;
            return item.Data;
        }

        /// <summary>
        /// Получение текущего элемента Стека
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return GetItem().Data;
        }

        /// <summary>
        /// Очистка Стека
        /// </summary>
        public void Clear()
        {
            CreateNewStack();
        }

        /// <summary>
        /// Получение клона текущего Стека
        /// </summary>
        /// <returns></returns>
        public MyStack<T> Clone()
        {
            var newStack = new MyStack<T>
            {
                _current = _current,
                Count = Count

            };
            return newStack;
        }
        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Проверка на заполненность и получение текущего элемента Стека
        /// </summary>
        /// <returns></returns>
        private Item<T> GetItem()
        {
            if (!IsEmpty)
            {
                return _current;
            }
            else
            {
                throw new NullReferenceException("Stack empty");
            }
        }

        /// <summary>
        /// Создание/очистка Стека
        /// </summary>
        private void CreateNewStack()
        {
            _current = default;
            Count = 0;
        }

        /// <summary>
        /// Переопределение ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Count > 1) return $"Стек с {Count} элементами";
            if (Count == 1) return $"Стек с 1 элементом";
            else return $"Стек пустой";
        }
        #endregion
    }
}
