using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.HashTable.HashTable
{
    interface IHashable<T>
    {
        public void Add(T item);

        public bool Search(T item);

        public T GetItem(int key);

        public void DisplayHashTable();


    }
}
