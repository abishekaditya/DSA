using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Utilities
    {
        public static void Swap<T>(T[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}