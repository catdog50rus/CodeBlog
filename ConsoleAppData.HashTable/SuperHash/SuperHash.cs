using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.HashTable.SuperHash
{
    public class SuperHash<T>
    {
        private readonly Item<T>[] items;

        public SuperHash(int size)
        {
            items = new Item<T>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            }
        }


        public void Add(T item)
        {
            var key = GetHash(item);
            items[key].Nodes.Add(item);
        }

        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key]?.Nodes.Contains(item)??false;
        }


        private int GetHash(T item)
        {
            return item.GetHashCode() % (items.Length);
        }

        /// <summary>
        /// Распечатать HashTable
        /// </summary>
        public void DisplayHashTable()
        {
            for (int i = 0; i < items.Length / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var key = i * 10 + j;
                    if (items[key].Nodes.Count>0)
                    {
                        foreach (var item in items[key].Nodes)
                        {
                            Console.Write($"{key}: {item}, ");
                        }
                    }
                    else
                    {
                        Console.Write($"{key}: ----, ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
