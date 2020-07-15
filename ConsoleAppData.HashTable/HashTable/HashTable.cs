using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.HashTable.HashTable
{
    public class HashTable<TKey, TValue> 
    {
       
        private readonly List<TValue>[] values;

        public HashTable(int size)
        {
            values = new List<TValue>[size];
                
        }

        public void Add(TKey key, TValue value)
        {
            var k = GetHash(key);
            if (values[k] == null)
            {
                values[k] = new List<TValue>();
            }
            values[k].Add(value);
        }

        public bool Search(TKey key, TValue value)
        {
            var k = GetHash(key);
            return values[k]?.Contains(value)?? false;
        }

        /// <summary>
        /// Распечатать HashTable
        /// </summary>
        public void DisplayHashTable()
        {
            for (int i = 0; i < values.Length / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var key = i * 10 + j;
                    if(values[key] != null)
                    {
                        Console.Write("(");
                        foreach (var item in values[key])
                        {
                            Console.Write($"{item}, ");
                        }
                        Console.Write("), ");
                    }
                    else
                    {
                        Console.Write("null, ");
                    }
                }
                Console.WriteLine();
            }
        }

        private int GetHash(TKey key)
        {
            int keylock = 0;
            for (int i = 0; i < key.ToString().Length; i++)
            {
                keylock += (int)key.ToString()[i];
            }
            return keylock % values.Length;
        }



       
    }
}
