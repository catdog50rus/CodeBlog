using System;
using System.Collections.Generic;

namespace AlgorithmLib.RadixSort
{
    /// <summary>
    /// Реализация по-разрядной сортировки
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RadixSortLSD<T> : BaseRadixSort<T> where T : IComparable
    {
        public RadixSortLSD() { }
        public RadixSortLSD(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            //Получаем максимальное количество разрядов чисел из коллекции
            int length = GetLength(Items);
            for (int step = 0; step < length; step++)
            {
                //Распределение элементов по корзинам
                //Распределение идет на основе разряда справа налево
                foreach (var item in Items)
                {
                    int i = item.GetHashCode();
                    int value = (i % (int)Math.Pow(10, step + 1)) / (int)Math.Pow(10, step);
                    groups[value].Enqueue(item);

                }
                //Очищаем коллекцию и заполняем ее элементами из корзины
                Items.Clear();
                Items.AddRange(AddItems(groups));
            }
        }
    }
}
