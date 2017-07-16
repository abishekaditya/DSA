using System;

namespace Utils
{
    public static class Utilities
    {
        public static void Swap<T>(T[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public static T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
        
        public static T Min<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? b : a;
        }
    }
}