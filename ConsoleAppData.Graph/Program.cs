using ConsoleAppData.Graph.Graph;
using ConsoleAppData.Graph.Model;
using System;
using System.Collections.Generic;

namespace ConsoleAppData.Graph
{
    class Program
    {
        static void Main()
        {

            var graph = new Graph<string>();

            var v1 = new Vertex<string>(1, "Москва");
            var v2 = new Vertex<string>(2, "Владимир");
            var v3 = new Vertex<string>(3, "Тверь");
            var v4 = new Vertex<string>(4, "Санкт-Петербург");
            var v5 = new Vertex<string>(5, "Муром");
            var v6 = new Vertex<string>(6, "Нижний Новгород");
            var v7 = new Vertex<string>(7, "Ленинград");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            graph.AddEdge(v1, v2, 180);
            graph.AddEdge(v1, v3, 120);
            graph.AddEdge(v3, v4, 500);
            graph.AddEdge(v2, v5, 115);
            graph.AddEdge(v2, v6, 190);
            graph.AddEdge(v6, v5, 200);
            graph.AddEdge(v5, v6, 200);

            PrintMatrix(graph);
            Console.WriteLine();
            Console.WriteLine();

            PrintVertexList(graph, v1);
            PrintVertexList(graph, v2);
            PrintVertexList(graph, v3);
            PrintVertexList(graph, v4);
            PrintVertexList(graph, v5);
            PrintVertexList(graph, v6);
            PrintVertexList(graph, v7);
            Console.WriteLine();
            Console.WriteLine();

            PrintRoute(graph, v1, v6);
            PrintRoute(graph, v2, v4);

        }

        static void PrintMatrix<T>(Graph<T> graph)
        {
            var matrix = graph.GetMatrix();
            Console.Write($"  ");
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write($"{graph.V[i].VertexId} ");
            }
            Console.WriteLine();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write($"{graph.V[i].VertexId} ");
                for (int j = 0; j < graph.EdgeCount; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        static void PrintVertexList<T>(Graph<T> graph, Vertex<T> vertex)
        {
            var vertexList = graph.GetVertexList(vertex);
            Console.Write($"{vertex.VertexId}: ");
            foreach (var v in vertexList)
            {
                Console.Write($"{v}, ");
            }
            Console.WriteLine();
        }

        static void PrintRoute<T>(Graph<T> graph, Vertex<T> start, Vertex<T> finish)
        {
            var route = graph.Wave(start, finish);
            if(route != null)
            {
                Console.WriteLine($"Маршрут {start.Data} - {finish.Data} построен!");
                int routeLenght = 0;
                var matrix = graph.GetMatrix();
                int startId = start.VertexId;
                foreach (var item in route)
                {
                    routeLenght += matrix[startId - 1, item.VertexId - 1];
                    Console.WriteLine($"   {item}, расстояние: {matrix[startId - 1, item.VertexId - 1]}км.");
                    startId = item.VertexId;
                }
                Console.WriteLine($"Общая протяженность маршрута: {routeLenght}км.");
            }
            else Console.WriteLine($"Маршрут {start.Data} - {finish.Data} не найден!");
            Console.WriteLine();
        }
    }
}
