using System;
using List;

namespace ListProgram
{
    internal static class Program
    {
        private static void Main()
        {
            var myArrayList = new ArrayList<int>(30);
            myArrayList.Append(30);
            myArrayList.Append(20);
            myArrayList.MoveToEnd();
            myArrayList.Insert(34);
            myArrayList.MoveToStart();
            myArrayList.Insert(22);
            myArrayList.Next();
            myArrayList.Insert(33);
            for (myArrayList.MoveToStart(); myArrayList.Position < myArrayList.Length; myArrayList.Next())
            {
                Console.Write(myArrayList.Value + " ");
            }
            Console.WriteLine("\nLength : " + myArrayList.Length);

            myArrayList.Position = 3;
            Console.WriteLine("Removed Element : " + myArrayList.Remove());

            Console.WriteLine("New Length : " + myArrayList.Length);
            for (myArrayList.MoveToStart(); myArrayList.Position < myArrayList.Length; myArrayList.Next())
            {
                Console.Write(myArrayList.Value + " ");
            }
            Console.ReadLine();
            var myLinkedList = new LinkedList<int>();
            myLinkedList.Append(30);
            myLinkedList.Append(20);
            myLinkedList.MoveToEnd();
            myLinkedList.Insert(34);
            myLinkedList.MoveToStart();
            myLinkedList.Insert(22);
            myLinkedList.Next();
            myLinkedList.Insert(33);
            for (myLinkedList.MoveToStart(); myLinkedList.Position < myLinkedList.Length; myLinkedList.Next())
            {
                Console.Write(myLinkedList.Value + " ");
            }
            Console.WriteLine("\nLength : " + myLinkedList.Length);

            myLinkedList.Position = 3;
            Console.WriteLine("Removed Element : " + myLinkedList.Remove());

            Console.WriteLine("New Length : " + myLinkedList.Length);
            for (myLinkedList.MoveToStart(); myLinkedList.Position < myLinkedList.Length; myLinkedList.Next())
            {
                Console.Write(myLinkedList.Value + " ");
            }
            Console.ReadKey();

        }
    }
}