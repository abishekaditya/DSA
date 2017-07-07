using System;
using System.Collections.Generic;

namespace ShellSort
{
    public static class Shell<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            var n = arr.Count;
            
            for (var i = n/2; i > 0; i /= 2)
            {
                for (var j = i; j < n; j++)
                {
                    var temp = arr[j];

                    int k;
                    for (k = j; k >= i && arr[k -i].CompareTo(temp) > 0; j -= i)
                        arr[k] = arr[k - i];

                    arr[k] = temp;
                }

            }
            return arr;
        }
    }
}