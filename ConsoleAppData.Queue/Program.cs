using ConsoleAppData.Queue.Queue;
using System;
using ConsoleAppData.Queue.Model;

namespace ConsoleAppData.Queue
{
    class Program
    {
        static void Main()
        {
            var listQueue = new ListQueue<int>();
            listQueue.Enqueue(1);
            listQueue.Enqueue(3);
            listQueue.Enqueue(4);
            listQueue.Enqueue(6);
            listQueue.Enqueue(9);
            DisplayQueue(listQueue);
            Console.WriteLine("Добавим в очередь элемент '7'");
            listQueue.Enqueue(7);
            DisplayItem(listQueue);
            listQueue.Clear();
            DisplayQueue(listQueue);

            var arrayQueue = new ArrayQueue<string>(10);
            arrayQueue.Enqueue("1");
            arrayQueue.Enqueue("2");
            arrayQueue.Enqueue("5");
            arrayQueue.Enqueue("6");
            arrayQueue.Enqueue("ten");
            DisplayQueue(arrayQueue);
            Console.WriteLine("Добавим в очередь элемент 'seven'");
            arrayQueue.Enqueue("seven");
            DisplayItem(arrayQueue);
            arrayQueue.Clear();
            DisplayQueue(arrayQueue);

            var linkedListQueue = new LinkedQueue<int>();
            linkedListQueue.Enqueue(1);
            linkedListQueue.Enqueue(3);
            linkedListQueue.Enqueue(4);
            linkedListQueue.Enqueue(6);
            linkedListQueue.Enqueue(9);
            DisplayQueue(linkedListQueue);
            Console.WriteLine("Добавим в очередь элемент '7'");
            linkedListQueue.Enqueue(7);
            DisplayItem(linkedListQueue);
            linkedListQueue.Clear();
            DisplayQueue(linkedListQueue);

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

    }
}
