using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmLib.Model;

namespace AlgorithmLib.CoctailSort
{
    public class CoctailSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public override void Sort()
        {
            int left = 0;
            int right = Count - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {

                }
            }
        }
    }
}
