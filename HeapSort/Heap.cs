using System;
using System.Collections.Generic;

namespace HeapSort
{
    public static class Heap<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            for (var i = arr.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, arr.Count, i);
            }

            for (var i = arr.Count - 1; i >= 0; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr,i,0);
            }
            return arr;
        }

        private static void Heapify(IList<T> arr, int n, int i)
        {
            var largest = i;
            var l = 2 * i + 1;
            var r = 2 * i + 2;

            if (l < n && arr[l].CompareTo(arr[largest]) >= 1)
                largest = l;
            
            if (r < n && arr[r].CompareTo(arr[largest]) >= 1)
                largest = r;

            if (largest == i) return;
            
            var swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, n, largest);
        }
    }
}
