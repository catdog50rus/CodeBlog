using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Graph.Model
{
    interface IGraph<T>
    {

        public void AddVertex(Vertex<T> vertex);
        public void AddEdge(Vertex<T> from, Vertex<T> to, int weight);

        public int[,] GetMatrix();
    }
}
