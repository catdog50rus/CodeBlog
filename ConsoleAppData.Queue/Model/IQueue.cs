using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Queue.Model
{
    public interface IQueue<T>
    {
        public void Enqueue(T data);

        public T Dequeue();

        public T Peek();

        public void Clear();

        public int GetCount();
        
    }
}
