using ConsoleAppData.HashTable.HashTable;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppData.HashTable
{
    class Program
    {
        static void Main()
        {
            var badHashTable = new BadHashTable<int>(100);

            badHashTable.Add(5);
            badHashTable.Add(55);
            badHashTable.Add(555);

            badHashTable.DisplayHashTable();

            Console.WriteLine();
            Console.WriteLine($"Таблица содержит значение 555? {badHashTable.Search(555)}");
            Console.WriteLine($"Таблица содержит значение 2? {badHashTable.Search(2)}");
            Console.WriteLine();

            var hashTable = new HashTable<int, int>(100);
            hashTable.Add(1, 1);
            hashTable.Add(10, 10);
            hashTable.Add(3, 100);
            hashTable.Add(2, 1);
            hashTable.Add(21, 10);
            hashTable.Add(222, 100); 
            hashTable.Add(24, 11);
            hashTable.Add(4, 110);
            hashTable.Add(44, 1100);

            hashTable.DisplayHashTable();
            Console.WriteLine();

            Console.WriteLine($"Таблица содержит значение 1  по ключу 1? {hashTable.Search(1, 1)}");
            Console.WriteLine($"Таблица содержит значение 10  по ключу 4? {hashTable.Search(4, 10)}");
            Console.WriteLine();


            var superHash = new SuperHash.SuperHash<Person>(100);
            var person = new Person("Коля", 20);

            superHash.Add(person);
            superHash.Add(new Person("Толя", 25));
            superHash.Add(new Person("Оля", 22, 1));
            superHash.Add(new Person("Валя", 20, 1));

            superHash.DisplayHashTable();

            Console.WriteLine();

            Console.WriteLine($"Таблица содержит значение new Person(Коля, 20, 0)? {superHash.Search(new Person("Коля", 20, 0))}");
            Console.WriteLine($"Таблица содержит значение Person(Коля, 20, 0)? {superHash.Search(person)}");


        }
        

    }
}
