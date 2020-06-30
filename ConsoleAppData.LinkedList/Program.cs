using ConsoleAppData.LinkedList.CircleLinkedList;
using ConsoleAppData.LinkedList.Model;
using ConsoleAppData.LinkedList.OneWayLinkedList;
using ConsoleAppData.LinkedList.TwoWayLinkedList;
using System;

namespace ConsoleAppData.LinkedList
{
    class Program
    {
        static void Main()
        {
            var list = new OneWayLinkedList<int>
            {
                1,
                5,
                9,
                7,
                3
            };

            //var list = new TwoWayLinkedList<int>
            //{
            //    1,
            //    5,
            //    9,
            //    7,
            //    3
            //};

            //var list = new CircleLinkedList<int>
            //{
            //    1,
            //    5,
            //    9,
            //    7,
            //    3
            //};


            Console.WriteLine("Исходный список");
            PrintList(list);

            Console.WriteLine("Добавим элемент '5' в конец списка");
            list.Add(5);
            PrintList(list);

            Console.WriteLine("Удалим первый в списке элемент '1'");
            list.Delete(1);
            list.Delete(5);
            list.Delete(9);
            list.Delete(7);
            list.Delete(3);
            list.Delete(5);
            PrintList(list);

            //Console.WriteLine("Добавим в начало списка элемент '0'");
            //list.AppendHead(0);
            //PrintList(list);

            Console.WriteLine("Удалим первый в списке элемент '0'");
            list.Delete(0);
            PrintList(list);

            //Console.WriteLine("Добавим в список элемент '13' после элемента '9'");
            //list.InsertAfter(9, 13);
            //PrintList(list);

            //Console.WriteLine("Найдем в списке элемент '13'");
            //PrintItem(list.FindFirst(13));

            //Console.WriteLine("Развернем список");
            //var reverseList = list.Reverse();
            //PrintList(reverseList);

            //Console.WriteLine("Найдем в развернутом списке элемент '9'");
            //PrintItem(reverseList.FindFirst(9));

            //Console.WriteLine("Очистим список");
            //list.Clear();
            //PrintList(list);

            //var nullList = new TwoWayLinkedList<int>(1);
            //nullList.Delete(1);
            //PrintList(nullList);

        }



        static void PrintList<T>(ILinkedListable<T> list)
        {
            Console.WriteLine(list);
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintItem<T>(T item)
        {
            if(item == null)
            {
                Console.WriteLine("Элемент не найден!");
            }
            else
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
