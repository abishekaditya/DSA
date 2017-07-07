using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSort
{
    public static class Quick<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            return Sort(arr, 0, arr.Count - 1);
        }
        
        private static List<T> Sort(List<T> arr, int low, int high)
        {
            var left = low;
            var right = high;
            var pivot = arr[left];

            while (low < high)
            {
                while (arr[high].CompareTo(pivot) != -1 && low < high)
                {
                    high--;
                }
                if (low != high)
                {
                    arr[low] = arr[high];
                    low++;
                }
                while ((arr[low].CompareTo(pivot) != 1) && (low < high))
                {
                    low++;
                }

                if (low == high) continue;
                arr[high] = arr[low];
                high--;
            }

            arr[low] = pivot;
            var p = low;

            if (left < p)
            {
                Sort(arr, left, p - 1);
            }

            if (right > p)
            {
                Sort(arr, p + 1, right);
            }

            return arr;
        }
      
    }
}
