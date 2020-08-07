using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppData.Graph.Model;

namespace ConsoleAppData.Graph.Graph
{
    /// <summary>
    /// Реализация Графов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Graph<T> : IGraph<T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Список вершин
        /// </summary>
        public List<Vertex<T>> V { get; }

        /// <summary>
        /// Список ребер (связей)
        /// </summary>
        public List<Edge<T>> E { get; }

        /// <summary>
        /// Счетчик вершин
        /// </summary>
        public int VertexCount => V.Count;

        /// <summary>
        /// Счетчик ребер
        /// </summary>
        public int EdgeCount => E.Count;

        public Graph()
        {
            V = new List<Vertex<T>>();
            E = new List<Edge<T>>();
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить вершину
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex is null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }
            else V.Add(vertex);


        }

        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="weight"></param>
        public void AddEdge(Vertex<T> from, Vertex<T> to, int weight = 1)
        {
            if (from is null)
            {
                throw new ArgumentNullException(nameof(from));
            }
            else if (to is null)
            {
                throw new ArgumentNullException(nameof(to));
            }
            else
            {
                var edge = new Edge<T>(from, to, weight);
                E.Add(edge);
            }

        }

        /// <summary>
        /// Получить матрицу
        /// </summary>
        /// <returns></returns>
        public int[,] GetMatrix()
        {
            var matrix = new int[V.Count, E.Count];

            foreach (var edge in E)
            {
                var row = edge.From.VertexId - 1;
                var column = edge.To.VertexId - 1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        /// <summary>
        /// Получить Список
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public List<Vertex<T>> GetVertexList(Vertex<T> vertex)
        {
            var result = new List<Vertex<T>>();
            foreach (var edge in E)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        /// <summary>
        /// Волновой обход графа
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public List<Vertex<T>> Wave(Vertex<T> start, Vertex<T> finish)
        {
            var result = new List<Vertex<T>>();
            var list = new List<Vertex<T>> { start };
            int count = 0;
            bool isResult = false;

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                count = i;
                foreach (var v in GetVertexList(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                        if (list.Contains(finish))
                        {
                            isResult = true;
                        }
                    }
                    
                }
                if (isResult) break;
            }

            if (isResult)
            {
                for (int i = 0; i < count + 1; i++)
                {
                    result.Add(list[i]);
                }
                result.Add(list[^1]);
                return result;
            }
            else return null;
        }

        #endregion






    }
}
