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
