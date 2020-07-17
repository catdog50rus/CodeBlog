using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleAppData.BinarySearchTree.Model
{
    /// <summary>
    /// Элемент бинарного дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> : IComparable
        where T: IComparable
    {
        /// <summary>
        /// Данные элемента
        /// </summary>
        public T Data { get; }
        /// <summary>
        /// Левый отпрыск элемента
        /// </summary>
        public Node<T> Left { get; private set; }
        /// <summary>
        /// Правый отпрыск элемента
        /// </summary>
        public Node<T> Right { get; private set; }

        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Добавление данных элемента. методом рекурсивного обхода дерева
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var node = new Node<T>(data);
            //Сравниваем добавляемый элемент с текущим для определения его местоположения
            if (node.Data.CompareTo(Data) == -1)
            {
                if(Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public int CompareTo(object obj)
        {
            if(obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new ArgumentException("Несовпадение типов");
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
