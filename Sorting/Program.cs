using System;
using System.Collections.Generic;
using InsertionSort;
using BubbleSort;
using SelectionSort;
using HeapSort;
using QuickSort;
using RadixSort;

namespace Sorting
{
    internal static class Program
    {
        private static void Main()
        {

            var selection = 0;
            
            while (selection != -1)
            {

               // var arr = new List<char>(new[] { 'a', 'd', 'c', 'b' });
                var arr = new List<int>(new[] {4, 5, 2, 1, 3, 7, 6, 8, 9, 10});
                Console.WriteLine("1. Bubble\n2. Insertion\n3. Selection\n4. Heap\n5. Radix\n6. Quick");
                Console.Write("Your Choice : ");
                selection = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                var s = "";
                switch (selection)
                {
                    case 1:
                        arr = Bubble<int>.Sort(arr);
                        s = "Bubble";
                        break;
                    case 2:
                        arr = Insertion<int>.Sort(arr);
                        s = "Insertion";
                        break;
                    case 3:
                        arr = Selection<int>.Sort(arr);
                        s = "Selection";
                        break;
                    case 4:
                        arr = Heap<int>.Sort(arr);
                        s = "Heap";
                        break;
                    case 5:
                        arr = Radix.Sort(arr);
                        s = "Radix";
                        break;
                    case 6:
                        arr = Quick<int>.Sort(arr);
                        s = "Quick";
                        break;
                    default:
                        Console.WriteLine("Choice Wrong");
                        break;
                }

                Console.Clear();
                Console.WriteLine(s);
                foreach (var i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.ReadKey();
            }
        }
    }
}
