using ConsoleAppData.BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.BinarySearchTree.BST
{
    /// <summary>
    /// Реализация бинарного дерева поиска
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BSTree<T> : IBSTreeable<T>
        where T: IComparable
    {
        #region Поля и конструкторы

        /// <summary>
        /// Корневой элемент дерева
        /// </summary>
        public Node<T> Root { get; private set; }
        /// <summary>
        /// Счетчик элементов
        /// </summary>
        private int count = 0;

        public BSTree()
        {

        }
        public BSTree(T data)
        {
            Add(data);
        }
        /// <summary>
        /// Конструктор для инициализации дерева коллекцией
        /// </summary>
        /// <param name="list"></param>
        public BSTree(IEnumerable<T> list)
        {
            List<T> nodes = new List<T>();
            nodes.AddRange(list);
            foreach (var item in nodes)
            {
                Add(item);
            }
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                count = 1;
            }
            else
            {
                Root.Add(data);
                count++;
            }
        }

        /// <summary>
        /// Префиксный обход (Копирование)
        /// Элемент / Левое поддерево / Правое поддерево
        /// </summary>
        /// <returns></returns>
        public List<T> PreOrder()
        {
            if (Root == null) return new List<T>();

            return PreOrder(Root);
        }

        /// <summary>
        /// Постфиксный обход (Удаление)
        /// Левое поддерево / Правое поддерево / Элемент
        /// </summary>
        /// <returns></returns>
        public List<T> PostOrder()
        {
            if (Root == null) return new List<T>();

            return PostOrder(Root);
        }

        /// <summary>
        /// Инфиксный обход (Сортировка по возрастанию)
        /// Левое поддерево / Элемент / Правое поддерево
        /// </summary>
        /// <returns></returns>
        public List<T> InOrder()
        {
            if (Root == null) return new List<T>();

            return InOrder(Root);
        }
        
        /// <summary>
        /// Бэкфиксный обход (Сортировка по убыванию)
        /// </summary>
        /// <returns></returns>
        public List<T> BackOrder()
        {
            if (Root == null) return new List<T>();

            return BackOrder(Root);
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Получить количество элементов дерева
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return count;
        }

        public override string ToString()
        {
            return Root.ToString(); 
        }

        /// <summary>
        /// Префиксный обход дерева с помощью рекурсии
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> PreOrder(Node<T> node)
        {
            var result = new List<T>
            {
                node.Data
            };
            if (node.Left != null)
            {
                result.AddRange(PreOrder(node.Left));
            }
            if (node.Right != null)
            {
                result.AddRange(PreOrder(node.Right));
            }

            return result;
        }
        /// <summary>
        /// Постфиксный обход дерева с помощью рекурсии
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> PostOrder(Node<T> node)
        {
            var result = new List<T>();
            if (node.Left != null)
            {
                result.AddRange(PostOrder(node.Left));
            }
            if (node.Right != null)
            {
                result.AddRange(PostOrder(node.Right));
            }
            result.Add(node.Data);
            return result;
        }
        /// <summary>
        /// Инфиксный обход дерева с помощью рекурсии
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> InOrder(Node<T> node)
        {
            var result = new List<T>();
            if (node.Left != null)
            {
                result.AddRange(InOrder(node.Left));
            }
            result.Add(node.Data);
            if (node.Right != null)
            {
                result.AddRange(InOrder(node.Right));
            }
            return result;
        }
        /// <summary>
        /// Бэкфиксный обход дерева с помощью рекурсии
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<T> BackOrder(Node<T> node)
        {
            var result = new List<T>();
            if (node.Right != null)
            {
                result.AddRange(BackOrder(node.Right));
            }
            result.Add(node.Data);
            if (node.Left != null)
            {
                result.AddRange(BackOrder(node.Left));
            }
            
            return result;
        }

        #endregion
    }
}
