using System;
using System.Collections.Generic;
using ConsoleAppData.BinarySearchTree.BST;
using ConsoleAppData.BinarySearchTree.Model;

namespace ConsoleAppData.BinarySearchTree
{
    class Program
    {
        static void Main()
        {
            var tree = new BSTree<int>(new List<int> { 5, 3, 7, 1, 2, 8, 6, 9, 4 });
            tree.Add(8);
            Console.WriteLine();

            Console.WriteLine("Префиксный обход дерева");
            Print(tree.PreOrder());

            Console.WriteLine("Постфиксный обход дерева");
            Print(tree.PostOrder());

            Console.WriteLine("Инфиксный обход дерева");
            Print(tree.InOrder());

            Console.WriteLine("Бэкфиксный обход дерева");
            Print(tree.BackOrder());
        }

        static void Print<T>(List<T> tree) where T: IComparable
        {
            int index = 0;
            foreach (var item in tree)
            {
                index++;
                if (index < tree.Count)
                {
                    Console.Write($"{item}, ");
                }
                else
                {
                    Console.Write($"{item}");
                }
  
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
