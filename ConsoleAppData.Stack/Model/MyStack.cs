using System;

namespace ConsoleAppData.Stack.Model
{
    public class MyStack<T>
    {
        private Item<T> _current;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public MyStack() => CreateNewStack();

        public MyStack(T data)
        {
            _current = new Item<T>(data);
            Count = 1;
        }

        public void Push(T data)
        {
            var item = new Item<T>(data)
            {
                Previous = _current
            };
            _current = item;
            Count++;
        }

        public T Pop()
        {
            var item = GetItem();
            _current = _current.Previous;
            Count--;
            return item.Data;
        }

        public T Peek()
        {
            return GetItem().Data;
        }

        public void Clear()
        {
            CreateNewStack();
        }

        public MyStack<T> Clone()
        {
            var newStack = new MyStack<T>
            {
                _current = _current,
                Count = Count

            };
            return newStack;
        }

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
        private void CreateNewStack()
        {
            _current = null;
            Count = 0;
        }
        public override string ToString()
        {
            return $"Стек на LinkedList<T> с {Count} элементами";
        }
    }
}
