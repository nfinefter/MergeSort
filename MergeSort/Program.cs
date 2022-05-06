using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MergeSort
{
    class Program
    {
        static T[] MergeSort<T>(T[] items) where T : IComparable<T>
        {
            if (items.Length < 2)
            {
                return items;
            }

            int middle = items.Length / 2;

            T[] left = new T[items.Length - middle];
            T[] right = new T[middle];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = items[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = items[i + left.Length];
            }

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
        {
            T[] merged = new T[left.Length + right.Length];

            int rightCount = 0;
            int leftCount = 0;
            int mergeCount = 0;

            //while does not account for leftovers
            while (rightCount < right.Length && leftCount < right.Length)
            {
                if (left[leftCount].CompareTo(right[rightCount]) <= 0)
                {
                    merged[mergeCount] = left[leftCount];
                    leftCount++;
                }
                else
                {
                    merged[mergeCount] = right[rightCount];
                    rightCount++;
                }
                mergeCount++;
            }
            while (rightCount < right.Length)
            {
                merged[mergeCount] = right[rightCount];
                mergeCount++;
                rightCount++;
            }
            while (leftCount < left.Length)
            {
                merged[mergeCount] = left[leftCount];
                mergeCount++;
                leftCount++;
            }

            return merged;
        }

        public static void Main(string[] args)
        {
            int[] items = new int[4];

            items[0] = 1;
            items[1] = 1;
            items[2] = 1;

            MergeSort(items);
        }
    }
}
