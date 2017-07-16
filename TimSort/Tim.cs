using System;
using System.Collections.Generic;
using InsertionSort;
using Utils;

namespace TimSort
{
    public static class Tim<T> where T : IComparable
    {
        private const int Run = 32;

       /* private static void InsertionSort(IList<T> arr)
        {
            for (var i = 1; i < arr.Count; i++)
            {
                var key = arr[i];
                var j = i - 1;

                while (j >= 0 && arr[j].CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }*/

        private static void Merge(IList<T> arr, int l, int m, int r)
        {
            var l1 = m - l + 1;
            var l2 = r - m;
            var left = new T[l1];
            var right = new T[l2];
            int i;
            var j = 0;
            var k = l;
            
            for (i = 0; i < l1; i++)
                left[i] = arr[l + i];
            
            for (i = 0; i < l2; i++)
                right[i] = arr[m + 1 + i];

            i = 0;
            while (i < l1 && j < l2)
            {
                if (left[i].CompareTo(right[j]) < 1)
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < l1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            while (j < l2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        public static List<T> Sort(List<T> arr)
        {
            var n = arr.Count;
            for (var i = 0; i < n; i += Run)
                Insertion<T>.Sort(arr);

            for (var size = Run; size < n; size = 2 * size)
            {
                for (var left = 0; left < n; left += 2 * size)
                {
                    var mid = left + size - 1;
                    var right = Utilities.Min((left + 2 * size - 1), (n - 1));

                    Merge(arr, left, mid, right);
                }
            }
            return arr;
        }


    }
}