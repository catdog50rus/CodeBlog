using System.Collections;

namespace ConsoleAppData.Dictionary.Model
{
    /// <summary>
    /// Интерфейс словаря
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IMapable<TKey, TValue> : IEnumerable
    {
        /// <summary>
        /// Счетчик элементов = длина массива
        /// </summary>
        public int Count { get;}

        /// <summary>
        /// Добавить элемент в словарь
        /// </summary>
        /// <param name="item"></param>
        public void Add(Item<TKey, TValue> item);

        /// <summary>
        /// Найти элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Search(TKey key);

        /// <summary>
        /// Удалить элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key);

        /// <summary>
        /// Очистить словарь
        /// </summary>
        public void Clear();
    }
}
