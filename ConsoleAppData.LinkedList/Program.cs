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
                5
            };

            //list.Delete(5);
            Console.WriteLine(list);

            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }


        }
    }
}
