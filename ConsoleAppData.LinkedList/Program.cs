using ConsoleAppData.LinkedList.Model;
using System;

namespace ConsoleAppData.LinkedList
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int>
            {
                1,
                5,
                9,
                7,
                3
            };
            Console.WriteLine("Исходный список");
            PrintList(list);

            Console.WriteLine("Добавим элемент '5' в конец списка");
            list.Add(5);
            PrintList(list);

            Console.WriteLine("Удалим первый в списке элемент '5'");
            list.Delete(5);
            PrintList(list);

            Console.WriteLine("Добавим в начало списка элемент '0'");
            list.AppendHead(0);
            PrintList(list);

            Console.WriteLine("Добавим в список элемент '13' после элемента '9'");
            list.InsertAfter(9, 13);
            PrintList(list);

            Console.WriteLine("Найдем в списке первый элемент '13'");
            var a = list.FindFirst(13);
            PrintFind(a);

            Console.WriteLine("Найдем в списке первый элемент '10'");
            var b = list.FindFirst(10);
            PrintFind(b);

        }

        private static void PrintFind(Item<int> a)
        {
            if (a != null)
            {
                Console.WriteLine($"Найден элемент списка: {a.Data}");
                Console.WriteLine($"Следующий элемент в списке: {a.Next}");
            }
            else
            {
                Console.WriteLine("Элемент в списке не найден!");
            }
            Console.WriteLine();
        }

        private static void PrintList(LinkedList<int> list)
        {
            Console.WriteLine(list);
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
