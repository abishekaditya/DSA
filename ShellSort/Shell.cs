using System;
using System.Collections.Generic;

namespace ShellSort
{
    public static class Shell<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            var n = arr.Count;

            for (var gap = n / 2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < n; i += 1)
                {
                    var temp = arr[i];

                    int j;
                    for (j = i; j >= gap && arr[j - gap].CompareTo(temp) >= 1; j -= gap)
                        arr[j] = arr[j - gap];

                    arr[j] = temp;
                }
            }
            return arr;
        }
    }
}