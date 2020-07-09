using ConsoleAppData.Set.Model;
using ConsoleAppData.Set.Set;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppData.Set
{
    class Program
    {
        static void Main()
        {
            ListSet<int> listSet = new ListSet<int> {1, 2, 5, 6, 7, 9, 12, 13};
            listSet.Add(16);
            listSet.DisplaySet();
            Console.WriteLine();

            ListSet<int> listSet2 = new ListSet<int> {14, 3, 6, 8, 9, 10};
            listSet2.Add(2);
            listSet2.DisplaySet();
            Console.WriteLine();

            ListSet<int> listSubset = new ListSet<int> { 1, 2, 5 };

            Console.WriteLine("Union");
            listSet.Union(listSet2).DisplaySet();
            Console.WriteLine();

            Console.WriteLine("Intersection");
            listSet.Intersection(listSet2).DisplaySet();
            Console.WriteLine();

            Console.WriteLine("Difference");
            listSet.Difference(listSet2).DisplaySet();
            Console.WriteLine();

            Console.WriteLine("SymmetricDifference");
            listSet.SymmetricDifference(listSet2).DisplaySet();
            Console.WriteLine();

            Console.Write("Содержит ли множество: ");
            listSet.DisplaySet();
            Console.Write("подмножество: ");
            listSubset.DisplaySet();
            Console.WriteLine(listSet.IsSubset(listSubset));


        }



    }
}
