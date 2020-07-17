using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.Dictionary.Model
{
    /// <summary>
    /// Единичный элемент словаря
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="Tvalue"></typeparam>
    public class Item<TKey, Tvalue> 
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public TKey Key { get;  }
        /// <summary>
        /// Значение
        /// </summary>
        public Tvalue Value { get;}

        public Item(TKey key, Tvalue value)
        {
            Key = key;
            Value = value;
        }
        public override int GetHashCode() => Key.GetHashCode();

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
