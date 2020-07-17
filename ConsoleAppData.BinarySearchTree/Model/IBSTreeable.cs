using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppData.BinarySearchTree.Model
{
    public interface IBSTreeable<T> where T:IComparable
    {
        /// <summary>
        /// Получить количество элементов
        /// </summary>
        /// <returns></returns>
        int GetCount();
        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="data"></param>
        void Add(T data);

        //Методы обхода бинарного дерева

        /// <summary>
        /// Префиксный обход
        /// </summary>
        /// <returns></returns>
        List<T> PreOrder();
        /// <summary>
        /// Постфиксный обход (Удаление элементов)
        /// </summary>
        /// <returns></returns>
        List<T> PostOrder();
        /// <summary>
        /// Инфиксный обход (Сортировка по возрастанию)
        /// </summary>
        /// <returns></returns>
        List<T> InOrder();
        /// <summary>
        /// Бэкфиксный обход (Сортировка по убыванию)
        /// </summary>
        /// <returns></returns>
        List<T> BackOrder();

    }
}
