using System;
using System.Collections.Generic;

namespace InsertionSort
{
    public static class Insertion<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
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
            return arr;
        }
    }
}