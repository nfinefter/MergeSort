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
            while (rightCount < right.Length && leftCount < left.Length)
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

        static void MergeSortInPlace<T>(T[] items, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return;
            }

            int middle = (start+end) / 2; //find the mid point based on start and end


            MergeSortInPlace(items, start, middle);
            MergeSortInPlace(items, middle + 1, end);

            MergeInPlace(items, start, middle);
        }
        
        static void MergeInPlace<T>(T[] items, int start, int middle) where T : IComparable<T> //TODO: come back and fix me at some point
        {
            while (start < items.Length)
            {
                if (start <= middle)
                {
                    if (items[start].CompareTo(items[middle]) >= 0)
                    {
                        items[start] = items[middle];

                    }
                }
                else
                {
                    if (items[start].CompareTo(items[items.Length]) >= 0)
                    {
                        items[start] = items[items.Length];

                    }
                }
                start++;
            }
        }


        public static void Main(string[] args)
        {
            int[] items = new int[] { 1, 3, 2, 4, 18, 12, 213,5 , 4536,4, 23,4, 1,2 ,312, 3,12, 3 };

            items = MergeSort(items);
            MergeSortInPlace(items, 0, items.Length);
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
