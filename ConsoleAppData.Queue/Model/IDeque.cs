using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Queue.Model
{
    public interface IDeque<T>
    {
        public void AddFirst(T data);

        public void AddLast(T data);

        public T RemoveFirst();
        public T RemoveLast();

        public T First();
        public T Last();

        public void Clear();

        public int GetCount();
        
    }
}
