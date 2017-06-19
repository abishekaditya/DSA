using System;
using System.Linq;
using Heap;

namespace Heap_Operations
{
    internal static class Program
    {
        private static void Main()
        {
            var array = Enumerable.Range(1, 12).ToArray();
            var maxHeap = new MaxHeap<int>(array, 20);
            maxHeap.BuildHeap();
            maxHeap.Print();
            Console.ReadLine();
            Console.Clear();
            maxHeap.RemoveMax();
            maxHeap.Print();
            Console.ReadLine();
            Console.Clear();
            maxHeap.Remove(3);
            maxHeap.Insert(6);
            Console.WriteLine("Size : " + maxHeap.Size);
            maxHeap.Print();
            Console.ReadLine();

            array = Enumerable.Range(1, 5).ToArray();
            var minHeap = new MinHeap<int>(array, 20);
            minHeap.BuildHeap();
            minHeap.Print();
            Console.ReadLine();
            Console.Clear();
            minHeap.RemoveMin();
            minHeap.Print();
            Console.ReadLine();
            Console.Clear();
            minHeap.Remove(3);
            minHeap.Insert(6);
            Console.WriteLine("Size : " + minHeap.Size);
            minHeap.Print();
            Console.ReadLine();
        }
    }
}