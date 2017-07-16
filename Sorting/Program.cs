using System;
using System.Collections.Generic;
using HeapSort;
using QuickSort;
using RadixSort;
using BubbleSort;
using InsertionSort;
using MergeSort;
using SelectionSort;
using ShellSort;
using TimSort;
using CocktailSort;

namespace Sorting
{
    internal static class Program
    {
        private static void Main()
        {
            var selection = 0;

            while (selection != -1)
            {
                var arr = new List<int>(new[]
                {
                    4, 5, 2, 1, 3, 7, 6, 22, 23, 25, 27, 29, 8, 9, 10, 32, 31, 43, 54, 43, 42, 12, 34, 38, 37, 36, 19,
                    18, 11, 55, 57, 56, 59, 13
                });
                Console.Clear();
                Console.WriteLine("0. Unsorted\n1. Bubble\n2. Insertion\n3. Selection\n4. Heap\n5. Radix\n6. Quick\n7. Shell\n8. Merge\n9. Tim\n10. Cocktail");
                Console.Write("Your Choice : ");
                selection = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                var s = "";
                switch (selection)
                {
                    case 0:
                        s = "Unsorted";
                        break;
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
                    case 7:
                        arr = Shell<int>.Sort(arr);
                        s = "Shell";
                        break;
                    case 8:
                        arr = Merge<int>.Sort(arr);
                        s = "Merge";
                        break;
                    case 9:
                        arr = Tim<int>.Sort(arr);
                        s = "Tim";
                        break;
                    case 10:
                        arr = Cocktail<int>.Sort(arr);
                        s = "Cocktail";
                        break;
                    default:
                        Console.WriteLine("Choice Wrong");
                        break;
                }

                Console.Clear();
                Console.WriteLine(s + " Sort");
                foreach (var i in arr)
                    Console.Write(i + " ");
                Console.ReadKey();
            }
        }
    }
}