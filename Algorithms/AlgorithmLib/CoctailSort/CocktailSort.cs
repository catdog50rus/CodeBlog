using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmLib.Model;

namespace AlgorithmLib.CoctailSort
{
    /// <summary>
    /// Реализация шейкерной сортировки
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CocktailSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public CocktailSort() { }
        public CocktailSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            //Устанавливаем начальные границы
            int left = 0;
            int right = Count - 1;

            //Запускаем основной цикл
            //Условия выхода:
            // - попадаем на середину коллекции
            // - счетчик замен не меняется (новых замен не происходит)
            while (left < right)
            {
                int sc = SwapCount;
                //Проход слева направо
                for (int i = left; i < right; i++)
                {
                    if (Compare(Items[i], Items[i+1]) == 1)
                    {
                        Swap(i, i + 1);
                    }
                }
                right--;

                //Проход справа налево
                for (int i = right; i > left; i--)
                {
                    if (Compare(Items[i], Items[i - 1]) == -1)
                    {
                        Swap(i, i - 1);
                    }
                }
                left++;
                //Если новых замен не происходит
                //считаем коллекцию отсортированной и выходим
                if (sc == SwapCount) break;
            }
        }
    }
}
