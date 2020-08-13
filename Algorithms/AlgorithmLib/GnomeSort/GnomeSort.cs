using AlgorithmLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLib.GnomeSort
{
    /// <summary>
    /// Реализация Гномьей сортировки
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GnomeSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public GnomeSort() { }
        public GnomeSort(IEnumerable<T> items) : base(items) { }

        protected override void MakeSort()
        {
            int index = 1;
            while (index < Count)
            {

                if (Compare(Items[index -1], Items[index]) == 1) 
                {
                    Swap(index, index - 1);
                    index--;
                } 
                else
                {
                    index++;
                }
                if (index == 0) index++;
            }
        }
    }
    
}
