using ConsoleAppData.Dictionary.Dictionary;
using ConsoleAppData.Dictionary.EasyMap;
using ConsoleAppData.Dictionary.Model;
using System;
using System.Collections.Generic;

namespace ConsoleAppData.Dictionary
{
    class Program
    {
        static void Main()
        {
            var easyMap = new EasyMap<int, string>
            {
                new Item<int, string>(1, "Один"),
                new Item<int, string>(2, "Два"),
                new Item<int, string>(3, "Три"),
                new Item<int, string>(4, "Четыре"),
                new Item<int, string>(5, "Пять")
            };


            Console.WriteLine("Вывод EasyMap");
            Print(easyMap);

            Console.WriteLine("Поиск элемента по ключу 3");
            Console.WriteLine(easyMap.Search(3) ?? "Не найдено");
            Console.WriteLine();


            Console.WriteLine("Поиск элемента по ключу 7");
            Console.WriteLine(easyMap.Search(7) ?? "Не найдено");
            Console.WriteLine();

            Console.WriteLine("Удалим элемент с ключом 2 и выведем результат");
            easyMap.Remove(2);
            Print(easyMap);

            Console.WriteLine("Очистим словарь");
            easyMap.Clear();
            Print(easyMap);

            Console.WriteLine("Dict------------------");

            var dict = new Dict<int, string>(10)
            {
                new Item<int, string>(1, "Один"),
                new Item<int, string>(2, "Два"),
                new Item<int, string>(3, "Три"),
                new Item<int, string>(4, "Четыре"),
                new Item<int, string>(5, "Пять"),
                new Item<int, string>(11, "Одиннадцать"),
                new Item<int, string>(12, "Двенадцать"),
                new Item<int, string>(22, "Двадцать Два")
            };
            dict.Add(new Item<int, string>(23, "Двадцать три"));
            dict.Add(new Item<int, string>(111, "Сто одиннадцать"));

            Console.WriteLine("Вывод Dict");
            Print(dict);

            Console.WriteLine($"Словарь имеет максимальный размер = {dict.Count}");
            Console.WriteLine("Пробуем добавить еще элемент (44, Сорок четыре)");
            dict.Add(new Item<int, string>(44, "Сорок четыре"));
            Console.WriteLine("Вывод Dict");
            Print(dict);

            Console.WriteLine("Поиск элемента по ключу 3");
            Console.WriteLine(dict.Search(3) ?? "Не найдено");
            Console.WriteLine();


            Console.WriteLine("Поиск элемента по ключу 7");
            Console.WriteLine(dict.Search(7) ?? "Не найдено");
            Console.WriteLine();

            Console.WriteLine("Удалим элемент с ключом 2 и выведем результат");
            dict.Remove(2);
            Print(dict);

            Console.WriteLine("Поиск элемента по ключу 22");
            Console.WriteLine(dict.Search(22) ?? "Не найдено");
            Console.WriteLine();

            Console.WriteLine("Удалим элемент с ключом 22 и выведем результат");
            dict.Remove(22);
            Print(dict);

            Console.WriteLine("Удалим элемент с ключом 23 и выведем результат");
            dict.Remove(23);
            Print(dict);

            Console.WriteLine("Очистим словарь");
            dict.Clear();
            Print(dict);


        }





        static void Print<Tkey, TValue>(IMapable<Tkey, TValue> map)
        {
            int index = 0;
            if(map.Count > 0)
            {
                foreach (var item in map)
                {
                    index++;
                    if (map.Count == index) Console.Write($"{item}");
                    else Console.Write($"{item}, ");
                }
            }
            if(map.Count == 0 || index == 0) Console.WriteLine("Словарь пуст!");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
