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


            var person1 = new Person("Коля", 20);
            var person2 = new Person("Толя", 25);
            var person3 = new Person("Оля", 22, 1);
            var person4 = new Person("Валя", 20, 1);
            var person5 = new Person("Валя", 20, 0);
            var person6 = new Person("Витя", 20, 0);
            var hashTable = new HashTable<int, Person>(10);
            hashTable.Add(person1.Id, person1);
            hashTable.Add(person2.Id, person2);
            hashTable.Add(person3.Id, person3);
            hashTable.Add(person4.Id, person4);
            hashTable.Add(person5.Id, person5);
            hashTable.Add(person6.Id, person6); 

            hashTable.DisplayHashTable();
            Console.WriteLine();

            Console.WriteLine($"Таблица содержит {person1}  по ключу {person1.Id}? {hashTable.Search(person1.Id, person1)}");
            Console.WriteLine($"Таблица содержит {person4}  по ключу {person4.Id}? {hashTable.Search(person4.Id, person4)}");
            Console.WriteLine();


            var superHash = new SuperHash.SuperHash<Person>(100);
            

            superHash.Add(person1);
            superHash.Add(person2);
            superHash.Add(person3);
            superHash.Add(person4);
            superHash.Add(person5);
            superHash.Add(person6);


            superHash.DisplayHashTable();

            Console.WriteLine();


            Console.WriteLine($"Таблица содержит значение {new Person("Коля", 20, 0)}? {superHash.Search(new Person("Коля", 20, 0))}");
            Console.WriteLine($"Таблица содержит значение {new Person("Коля", 20, 1)}? {superHash.Search(new Person("Коля", 20, 1))}");
            Console.WriteLine($"Таблица содержит значение {person5}? {superHash.Search(person5)}");

            Console.WriteLine();


        }
        

    }
}
