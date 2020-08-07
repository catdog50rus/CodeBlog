using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Graph.Model
{
    class Edge<T>
    {
        public Vertex<T> From { get; }
        public Vertex<T> To { get; }
        public int Weight { get; }

        public Edge(Vertex<T> from, Vertex<T> to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Из {From} в {To}"; 
        }
    }
}
