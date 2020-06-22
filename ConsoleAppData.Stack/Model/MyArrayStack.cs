using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Stack.Model
{
    public class MyArrayStack<T>
    {
        private T[] _items;
        public int Count { get; private set; } = -1;
        public int Size { get; }
        public bool IsEmpty => Count == -1;

        public MyArrayStack(int size = 10)
        {
            Size = size;
            _items = new T[Size];
        }

        public MyArrayStack(T data, int size = 10) : this(size)
        {
            _items[0] = data;
            Count = 1;
        }

        public void Push(T data)
        {
            if(Count < Size)
            {
                Count++;
                _items[Count] = data;
                
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
            _items[Count] = default;
            Count--;
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
        //public T[] Clone()
        //{
        //    var newStack = new MyArrayStack<T>[Size];
        //    for (int i = 0; i < Size; i++)
        //    {
        //        newStack[i] = _items[i];
        //    }
        //    return newStack;
        //}


        private T GetItem()
        {
            if (!IsEmpty)
            {
                var item = _items[Count];
                return item;
            }
            else
            {
                throw new NullReferenceException("Stack empty");
            }
        }

        public override string ToString()
        {
            if (Count > 0) return $"Стек на Array<T> с {Count + 1} элементами";
            if (Count == 0) return $"Стек на Array<T> с 1 элементом";
            else return $"Стек на Array<T> пустой";
        }
    }
}
