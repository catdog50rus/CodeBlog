using ConsoleAppData.Queue.Queue;
using System;
using System.Collections.Generic;
using ConsoleAppData.Queue.Model;
using ConsoleAppData.Queue.Deque;

namespace ConsoleAppData.Queue
{
    class Program
    {
        static void Main()
        {
            //var listQueue = new ListQueue<int>();
            //listQueue.Enqueue(1);
            //listQueue.Enqueue(3);
            //listQueue.Enqueue(4);
            //listQueue.Enqueue(6);
            //listQueue.Enqueue(9);
            //DisplayQueue(listQueue);
            //Console.WriteLine("Добавим в очередь элемент '7'");
            //listQueue.Enqueue(7);
            //DisplayItem(listQueue);
            //listQueue.Clear();
            //DisplayQueue(listQueue);

            //var arrayQueue = new ArrayQueue<string>(10);
            //arrayQueue.Enqueue("1");
            //arrayQueue.Enqueue("2");
            //arrayQueue.Enqueue("5");
            //arrayQueue.Enqueue("6");
            //arrayQueue.Enqueue("ten");
            //DisplayQueue(arrayQueue);
            //Console.WriteLine("Добавим в очередь элемент 'seven'");
            //arrayQueue.Enqueue("seven");
            //DisplayItem(arrayQueue);
            //arrayQueue.Clear();
            //DisplayQueue(arrayQueue);

            //var linkedListQueue = new LinkedQueue<int>();
            //linkedListQueue.Enqueue(1);
            //linkedListQueue.Enqueue(3);
            //linkedListQueue.Enqueue(4);
            //linkedListQueue.Enqueue(6);
            //linkedListQueue.Enqueue(9);
            //DisplayQueue(linkedListQueue);
            //Console.WriteLine("Добавим в очередь элемент '7'");
            //linkedListQueue.Enqueue(7);
            //DisplayItem(linkedListQueue);
            //linkedListQueue.Clear();
            //DisplayQueue(linkedListQueue);

            //var listDeque = new ListDeque<int>();
            //listDeque.AddFirst(1);
            //listDeque.AddFirst(3);
            //listDeque.AddFirst(4);
            //listDeque.AddLast(6);
            //listDeque.AddLast(9);
            //DisplayItem(listDeque);
            //DisplayQueue(listDeque);
            //Console.WriteLine();
            //listDeque.AddLast(5);
            //DisplayItem(listDeque);
            //Console.WriteLine(listDeque.RemoveFirst());
            //DisplayItem(listDeque);


            var linkedDeque = new LinkedListDeque<int>();
            linkedDeque.AddFirst(1);
            linkedDeque.AddFirst(3);
            linkedDeque.AddFirst(4);
            linkedDeque.AddLast(6);
            linkedDeque.AddLast(9);
            DisplayItem(linkedDeque);
            DisplayQueue(linkedDeque);
            Console.WriteLine();
            linkedDeque.AddLast(5);
            DisplayItem(linkedDeque);
            Console.WriteLine(linkedDeque.RemoveFirst());
            DisplayItem(linkedDeque);

        }

        static void DisplayItem<T>(IQueue<T> queue)
        {
            if (queue.GetCount() > 0)
            {
                Console.WriteLine($"Первый элемент в очереди: {queue.Peek()}");
            }
            else
            {
                Console.WriteLine("Очередь пуста!");
            }
            Console.WriteLine();
        }
        
        static void DisplayQueue<T>(IQueue<T> queue)
        {
            Console.WriteLine(queue);
            var lenght = queue.GetCount();
            if (lenght > 0)
            {
                Console.WriteLine($"Первый элемент: {queue.Peek()}");
                Console.WriteLine($"Извлечение элементов:");
                for (int i = 0; i < lenght; i++)
                {
                    if (i == lenght - 1)
                    {
                        Console.Write($"{queue.Dequeue()}");
                    }
                    else
                    {
                        Console.Write($"{queue.Dequeue()}, ");
                    }

                }
            }
            else
            {
                Console.WriteLine("Очередь пуста!");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void DisplayItem<T>(IDeque<T> deque)
        {
            Console.WriteLine(deque);
            if (deque.GetCount() > 0)
            {
                Console.WriteLine($"Первый элемент очереди: {deque.First()}");
                Console.WriteLine($"Последний элемент очереди: {deque.Last()}");
            }
            else
            {
                Console.WriteLine("Список пуст!");
            }
            Console.WriteLine();
        }

        static void DisplayQueue<T>(IDeque<T> deque)
        {
            Console.WriteLine(deque);
            var lenght = deque.GetCount();
            if (lenght > 0)
            {
                Console.WriteLine($"Извлечение элементов с начала очереди:");
                for (int i = 0; i < lenght; i++)
                {
                    Console.Write($"{deque.RemoveFirst()}, ");

                }
            }
            else
            {
                Console.WriteLine("Очередь пуста!");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
