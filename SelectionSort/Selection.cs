using System;
using System.Collections.Generic;

namespace SelectionSort
{
    public static class Selection<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            for (var i = 0; i < arr.Count - 1; i++)
            {
                var min = i;

                for (var j = i + 1; j < arr.Count; j++)
                    if (arr[j].CompareTo(arr[min]) <= -1)
                        min = j;
                var temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
    }
}