using System;
using System.Collections.Generic;

namespace MergeSort
{

    class Program<T>
    {
        public T[] MergeSort(T[] items)
        {
            if (items.Length < 2)
            {
                return items;
            }

            int middle = items.Length / 2;

            T[] left = new T[items.Length - middle];
            T[] right = new T[middle];

            for (int i = 0; i < items.Length; i++)
            {
                if (i < left.Length)
                {
                    left[i] = items[i];
                }
                else
                {
                    right[i] = items[i];
                }
            }
            return Merge(MergeSort(left), MergeSort(right));
        }
        private T[] Merge(T[] left, T[] right)
        {
            T[] merged = new T[left.Length + right.Length];
            //idk how to merge and sort

            return merged;
        }

        static void Main(string[] args)
        {
           
        }
    }
}
