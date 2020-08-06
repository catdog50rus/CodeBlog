using System;
using ConsoleAppData.PrefixTree.Trie;

namespace ConsoleAppData.PrefixTree
{
    class Program
    {
        static void Main()
        {
            var trie = new Trie<int>();
            trie.Add("Привет", 50);
            trie.Add("мир", 100);
            trie.Add("приз", 150);
            trie.Add("Мираж", 120);
            trie.Add("кирпич", 120);
            trie.Add("Кирка", 100);
            trie.Add("Проект", 110);
            trie.Add("Прокол", 100);
            Console.WriteLine();

            RemoveWord(trie,"Мираж");
            RemoveWord(trie, "Мираж");
            RemoveWord(trie, "Кураж");

            Console.WriteLine();

            SearchWord(trie, "Проект");
            SearchWord(trie, "Мираж");
            SearchWord(trie, "Мир");
            SearchWord(trie, "кирпич");

            Console.WriteLine();


        }

        static void SearchWord<T>(Trie<T> trie, string word)
        {
            Console.WriteLine($"Найдем элемент '{word}'");
            var searchResult = trie.Search(word);
            if (searchResult.Item1)
            {
                Console.WriteLine($"Найден элемент '{word}', префикс: '{searchResult.Item3}', вес {searchResult.Item2}");
            }
            else
            {
                Console.WriteLine($"Элемент '{word}' не найден!");
            }
            Console.WriteLine();
        }

        static void RemoveWord<T>(Trie<T> trie, string word)
        {
            Console.WriteLine($"Удаляем элемент '{word}'");
            if (trie.Remove(word))
            {
                Console.WriteLine($"Элемент '{word}' успешно удален!");
            }
            else
            {
                Console.WriteLine($"Элемент '{word}' не найден!");

            }
            Console.WriteLine();
        }

    }
}
