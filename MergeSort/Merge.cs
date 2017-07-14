using System;
using System.Collections.Generic;

namespace MergeSort
{
    public static class Merge<T> where T : IComparable
    {


        public static List<T> Sort(List<T> arr)
        {
           Sort(ref arr, 0, arr.Count - 1);
           return arr;
        }

        private static void Merger(IList<T> arr, int l, int m, int r)
        {
            var n1 = m - l + 1;
            var n2 = r - m;

            var left = new T[n1];
            var right = new T[n2];

            for (var x = 0; x < n1; ++x)
                left[x] = arr[l + x];
            for (var y = 0; y < n2; ++y)
                right[y] = arr[m + 1 + y];


            int i = 0, j = 0;

            var k = l;
            while (i < n1 && j < n2)
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

            while (i < n1)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }


        private static void Sort(ref List<T> arr, int l, int r)
        {
            if (l >= r) return;
            var m = (l + r) / 2;

            Sort(ref arr, l, m);
            Sort(ref arr, m + 1, r);

            Merger(arr, l, m, r);
        }
    }
}
