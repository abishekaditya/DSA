using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public static class Bubble<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            for (var i = 0; i < arr.Count - 1; i++)
            {
                for (var j = 0; j < arr.Count - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) < 1) continue;
                    var temp = arr[j+1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                }
            }
            return arr;
        }
    }
}