using System;
using System.Collections;
using ConsoleAppData.Dictionary.Model;

namespace ConsoleAppData.Dictionary.Dictionary
{
    /// <summary>
    /// Реализация словаря
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class Dict<TKey, TValue> : IMapable<TKey, TValue>
    {
        #region Поля и конструкторы

        /// <summary>
        /// Массив элементов словаря
        /// </summary>
        private Item<TKey, TValue>[] items;
        /// <summary>
        /// Счетчик элементов = длина массива
        /// </summary>
        public int Count => items.Length;

        public Dict(int size)
        {
            items = new Item<TKey, TValue>[size];
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить элемент в словарь
        /// </summary>
        /// <param name="item"></param>
        public void Add(Item<TKey, TValue> item)
        {
            //Получаем хеш
            var hash = GetHash(item.Key);
            //Если элемента с таким хеш нет, добавляем элемент
            if (items[hash] == null) items[hash] = item;

            //Если элемент с таким хеш есть, проверяем совпадают ли ключи
            //Если ключ совпадает, то выходим.
            else if (items[hash].Key.Equals(item.Key)) return;
            //Если ключ уникальный, начинаем искать свободную ячейку слева на-право
            else
            {
                bool placed;// = false;
                ///Пытаемся установить элемент в свободную ячейку правее ячейки хеш
                placed = SetItem(item, hash, items.Length);
                //Если свободной ячейки не нашлось, ищем свободную ячейку левее хеш от 0
                if (!placed)
                {
                    placed = SetItem(item, hash);
                    if (!placed) Console.WriteLine("Словарь полон!");
                }
            }

        }

        /// <summary>
        /// Очистить словарь
        /// </summary>
        public void Clear()
        {
            items = new Item<TKey, TValue>[Count];
        }

        /// <summary>
        /// Удалить элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key)
        {
            //Получаем хеш
            var hash = GetHash(key);

            //Получаем индекс хеш ячейки с элементом
            var index = GetItem(key, hash);
            //Если индекс существует, удаляем значение ячейки по этому индексу
            if (index != -1)
            {
                items[index] = null;
            }
            //Если приходит -1, значит искомый элемент не найден
            else
            {
                Console.WriteLine("Элемент не найден!");
            }

        }

        /// <summary>
        /// Найти элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Search(TKey key)
        {
            //Получаем Хеш
            var hash = GetHash(key);

            //Получаем индекс искомого элемента
            var index = GetItem(key, hash);
            //Если индекс найден, возвращаем значение элемента
            if (index != -1)
            {
                return items[index].Value;
            }
            //Если приходит -1 возвращаем пустое значение
            else
            {
                return default;
            }
        }

        #endregion

        #region Вспомогательные методы

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] != null)
                {
                    yield return items[i];
                }
            }
        }

        /// <summary>
        /// Хеш функция
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetHash(TKey key)
        {
            return key.GetHashCode() % items.Length;
        }

        /// <summary>
        /// Проверка на наличие элемента
        /// Если элемента нет, добавляем элемент
        /// </summary>
        /// <param name="item"></param>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool SetItem(Item<TKey, TValue> item, int hash, int index = 0)
        {
            //начальное и конечное значение для цикла
            int ifirst, ilast;
            if (index == 0) { ifirst = 0; ilast = hash; }
            else { ifirst = hash; ilast = items.Length; }

            //Проходим циклом в поиске свободной ячейки
            for (int i = ifirst; i < ilast; i++)
            {
                //Если ячейка найдена возвращаем true
                if (items[i] == null)
                {
                    items[i] = item;
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Получить индекс искомого элемента
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        private int GetItem(TKey key, int hash)
        {
            //Запрашиваем индекс правее Хеш ячейки
            var index = GetIndex(key, hash, Count);
            //Если индекс найден, возвращаем его
            if (index != -1) return index;
            //Если приходит -1, ищем индекс слева от 0 до хеш
            //И возвращаем результат
            else return GetIndex(key, 0, hash);
        }

        /// <summary>
        /// Найти индекс элемента правее или левее значения хеш
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ifirst"></param>
        /// <param name="ilast"></param>
        /// <returns></returns>
        private int GetIndex(TKey key, int ifirst, int ilast)
        {
            for (int i = ifirst; i < ilast; i++)
            {
                //Если очередной элемент не пустой, проверяем ключи
                if (items[i] != null)
                {
                    //Если ключи совпадают, возвращаем найденный индекс
                    if (items[i].Key.Equals(key))
                    {
                        return i;
                    }
                }


            }
            //Если поиск не дал результата, возвращаем -1
            return -1;
        }

        #endregion

    }
}
