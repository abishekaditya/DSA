using System;
using System.Collections.Generic;
using Utils;
namespace CocktailSort
{
    public static class Cocktail<T> where T : IComparable
    {
        public static List<T> Sort(List<T> arr)
        {
            var swapped = true;
            var start = 0;
            var end = arr.Count - 1;

            while (swapped)
            {

                swapped = false;
                
                for (var i = start; i < end; ++i)
                {
                    if (arr[i].CompareTo(arr[i + 1]) <= 0) continue;
                    var temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    swapped = true;
                }
                
                if (!swapped)
                    break;

                swapped = false;

                --end;

                for (var i = end - 1; i >= start; --i)
                {
                    if (arr[i].CompareTo(arr[i + 1]) <= 0) continue;
                    var temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    swapped = true;
                }
                ++start;
            }

            return arr;
        }
    }
}
