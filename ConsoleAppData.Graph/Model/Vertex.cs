using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Graph.Model
{
    class Vertex<T>
    {
        public int VertexId { get; }
        public T Data { get; }

        public Vertex(int id)
        {
            if (id > 0)
            {
                VertexId = id;
            }
            else throw new ArgumentOutOfRangeException("id должно быть положительным числом");
            
        }
        public Vertex(int id, T data) : this(id)
        {
            Data = data;
        }

        public override string ToString()
        {
            return $"Точка: {VertexId}: {Data}"; 
        }
    }
}
