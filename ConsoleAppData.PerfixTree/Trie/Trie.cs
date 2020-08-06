using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppData.PrefixTree.Model;

namespace ConsoleAppData.PrefixTree.Trie
{
    /// <summary>
    /// Реализация префиксного дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Trie <T>
    {
        #region Поля и конструкторы

        /// <summary>
        /// корневой элемент
        /// </summary>
        private readonly Node<T> _root;
        /// <summary>
        /// Счетчик всех элементов(слов)
        /// </summary>
        private int _count = default;

        public Trie()
        {
            _root = new Node<T>('\0', default, "");
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить слово
        /// </summary>
        /// <param name="key">Слово</param>
        /// <param name="data">Параметр</param>
        public void Add(string key, T data)
        {
            AddNode(key.ToLower(), data, _root);
        }

        /// <summary>
        /// Удалить слово
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return RemoveNode(key.ToLower(), _root);
        }

        /// <summary>
        /// Найти слово (значение параметра по слову)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public (bool, T, string) Search(string key)
        {
            var result = SearchNode(key.ToLower(), _root);
            if (result.Item1) return (true, result.Item2, result.Item3);
            else return default;
        }

        /// <summary>
        /// Получить счетчик слов в дереве
        /// </summary>
        /// <returns></returns>
        public int GetCount() => _count;

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Рекурсивная реализация добавления слова в дерево
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="node"></param>
        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                    _count++;
                }
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {
                    AddNode(key.Substring(1), data, subnode);
                }
                else
                {
                    var newNode = new Node<T>(key[0], data, node.Prefix + key[0]);
                    node.SubNodes.Add(key[0], newNode);
                    AddNode(key.Substring(1),data, newNode);
                }
            }
        }

        /// <summary>
        /// Рекурсивная реализация удаления слова из дерева
        /// </summary>
        /// <param name="key"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool RemoveNode(string key, Node<T> node)
        {
            bool result = false;
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                    _count--;
                    result = true;
                }
                
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    result = RemoveNode(key.Substring(1), subnode);
                }

            }
            return result;
        }

        /// <summary>
        /// Рекурсивная реализация посика слова в дереве
        /// </summary>
        /// <param name="key"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private (bool,T, string) SearchNode(string key, Node<T> node)
        {
            var result = false;
            T value = default;
            string prefix = default;
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    result = true;
                    value = node.Data;
                    prefix = node.Prefix;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    var res = SearchNode(key.Substring(1), subnode);
                    result = res.Item1;
                    value = res.Item2;
                    prefix = res.Item3;
                }
            }
            return (result, value, prefix);
        }

        #endregion

    }
}
