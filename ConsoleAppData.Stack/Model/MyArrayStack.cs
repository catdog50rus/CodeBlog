using System;

namespace ConsoleAppData.Stack.Model
{
    /// <summary>
    /// Реализация Стек на массиве
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyArrayStack<T>
    {
        #region Поля и конструкторы
        /// <summary>
        /// Массив данных
        /// </summary>
        private T[] _items;

        /// <summary>
        /// Позиция последнего элемента
        /// </summary>
        private int _current =-1;

        /// <summary>
        /// Счетчик количества элементов
        /// </summary>
        public int Count => _current + 1;

        /// <summary>
        /// Размер Стека
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Признак пустого Стека
        /// </summary>
        public bool IsEmpty => _current == -1;


        public MyArrayStack(int size = 10)
        {
            Size = size;
            _items = new T[Size];
        }

        public MyArrayStack(T data, int size = 10) : this(size)
        {
            _current = 0;
            _items[_current] = data;
            
        }
        #endregion

        #region Методы

        /// <summary>
        /// Добавить элемент в Стек
        /// </summary>
        /// <param name="data"></param>
        public void Push(T data)
        {
            if(++_current < Size)
            {
                _items[_current] = data;
            }
            else
            {
                throw new StackOverflowException("Стек переполнен");
            }
        }

        /// <summary>
        /// Получить элемент Стека и удалить его
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {

            var item = GetItem();
            _items[_current] = default;
            _current--;
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
            _items = default;
        }

        /// <summary>
        /// Получить клон Стека
        /// </summary>
        /// <returns></returns>
        public MyArrayStack<T> Clone()
        {
            var newStack = new MyArrayStack<T>(Size);

            for (int i = 0; i < Size; i++)
            {
                newStack._items[i] = _items[i];
            }
            newStack._current = _current;
            return newStack;
        }
        #endregion

        #region Вспомогательный методы

        /// <summary>
        /// Проверить Стек на заполненность и получить последний элемент
        /// </summary>
        /// <returns></returns>
        private T GetItem()
        {
            if (!IsEmpty)
            {
                var item = _items[_current];
                return item;
            }
            else
            {
                throw new NullReferenceException("Stack empty");
            }
        }

        /// <summary>
        /// Переопределение ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Count > 1) return $"Стек на Array<T> с {Count} элементами";
            if (Count == 1) return $"Стек на Array<T> с 1 элементом";
            else return $"Стек на Array<T> пустой";
        }
        #endregion
    }
}
