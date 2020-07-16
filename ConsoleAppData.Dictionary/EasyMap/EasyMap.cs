using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppData.Dictionary.Model;

namespace ConsoleAppData.Dictionary.EasyMap
{
    /// <summary>
    /// Простая реализация словаря на List
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class EasyMap<TKey, TValue> : IMapable<TKey, TValue>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Элементы словаря
        /// </summary>
        private readonly List<Item<TKey, TValue>> items;
        /// <summary>
        /// Список ключей
        /// </summary>
        private readonly List<TKey> keys;
        /// <summary>
        /// Счетчик количества элементов словаря
        /// </summary>
        public int Count => items.Count;

        public EasyMap()
        {
            items = new List<Item<TKey, TValue>>();
            keys = new List<TKey>();
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в словарь
        /// </summary>
        /// <param name="item"></param>
        public void Add(Item<TKey, TValue> item)
        {
            if (!keys.Contains(item.Key))
            {
                items.Add(item);
                keys.Add(item.Key);
            }
        }

        /// <summary>
        /// Удалить элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key)
        {
            if (keys.Contains(key))
            {
                items.Remove(items.Single(i => i.Key.Equals(key)));
                keys.Remove(key);
            }
        }

        /// <summary>
        /// Найти элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Search(TKey key)
        {
            if (keys.Contains(key))
            {
                return items.Single(i => i.Key.Equals(key)).Value;
            }
            else return default;
        }

        /// <summary>
        /// Очистить словарь
        /// </summary>
        public void Clear()
        {
            keys.Clear();
            items.Clear();
        }

        #endregion

        #region Вспомогательные методы

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        #endregion
    }
}
