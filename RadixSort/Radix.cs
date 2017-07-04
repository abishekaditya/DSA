using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RadixSort
{
    public static class Radix
     {
        public static List<int> Sort(List<int> arr)
        {
            var m = Maximum(arr);
            for (var exp = 1; m / exp > 0; exp *= 10)
                CountSort(arr, arr.Count, exp);
            return arr;
        }

         private static void CountSort(List<int> arr, int arrCount, int exp)
         {
             var output = new int[arrCount];
             int i;
             var count = new int[10];

             for (i = 0; i < arrCount; i++)
                 count[(arr[i] / exp) % 10]++;

             for (i = 1; i < 10; i++)
                 count[i] += count[i - 1];

             for (i = arrCount - 1; i >= 0; i--)
             {
                 output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                 count[(arr[i] / exp) % 10]--;
             }

             for (i = 0; i < arrCount; i++)
                 arr[i] = output[i];
         }

         private static int Maximum(List<int> arr)
         {
             var max = arr[0];
             for (var i = 1; i < arr.Count; i++)
                 if (arr[i].CompareTo(max) == 1)
                     max = arr[i];

             return max;
         }
     }
}