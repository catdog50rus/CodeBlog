using System;
using System.Collections.Generic;
using ConsoleAppData.BinaryHeap.Heap;

namespace ConsoleAppData.BinaryHeap
{
    class Program
    {
        static void Main()
        {          
            var rnd = new Random();
            var startItems = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                startItems.Add(rnd.Next(-1000, 1000));
            }
            var binheap = new Heap<int>(startItems);

            Console.WriteLine("Выведем текущее состояние:");
            binheap.PrintHeap();
            Console.WriteLine();

            Console.WriteLine("Добавим еще 100 элементов и выведем текущее состояние");
            for (int i = 0; i < 100; i++)
            {
                binheap.Add(rnd.Next(-1000,1000));
            }
            binheap.PrintHeap();
            Console.WriteLine();

            Console.WriteLine("Получим по приоритету первые 50 элементов");
            for (int i = 0; i < 50; i++)
            {
                if (i == binheap.Count)
                {
                    Console.WriteLine("Элементы закончились!");
                    return;
                }
                Console.WriteLine(binheap.GetMax());
            }
            Console.WriteLine();

            Console.WriteLine("Получим по приоритету оставшиеся элементы");
            while (binheap.Count > 0)
            {
                Console.WriteLine(binheap.GetMax());
            }

        }
    }
}
