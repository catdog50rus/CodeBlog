using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.PrefixTree.Model
{
    /// <summary>
    /// Класс элемента дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node <T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Символ ключа
        /// </summary>
        public char Symbol { get; private set; }
        /// <summary>
        /// Данные по ключу
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Флаг окончания слова
        /// </summary>
        public bool IsWord { get; set; }
        /// <summary>
        /// Префикс слова
        /// </summary>
        public string Prefix { get; private set; }
        /// <summary>
        /// Подветка на основе ключ/значение
        /// </summary>
        public Dictionary<char, Node<T>> SubNodes { get; private set; }

        public Node(char symbol, T data, string prefix)
        {
            Data = data;
            Symbol = symbol;
            Prefix = prefix;
            SubNodes = new Dictionary<char, Node<T>>();
        }

        #endregion

        /// <summary>
        /// Метод проверяющий наличие значения по символу ключа
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public Node<T> TryFind(char symbol)
        {
            if (SubNodes.TryGetValue(symbol, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $"{Data} [{SubNodes.Count}] [{Prefix}]";
        }
        public override bool Equals(object obj)
        {
            if(obj is Node<T> item)
            {
                return Data.Equals(item);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Data.ToString().GetHashCode();
        }
    }
}
