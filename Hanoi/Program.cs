using System;
using Stack;

namespace Hanoi
{
    internal enum Operation
    {
        Move,
        Hanoi
    }

    internal enum Pole
    {
        A,
        B,
        C
    }

    internal class TohObject
    {
        public int Num;
        public Operation Operation;
        public Pole Start, Goal, Temp;

        public TohObject(Operation operation, int num, Pole start, Pole goal, Pole temp)
        {
            Operation = operation;
            Num = num;
            Start = start;
            Goal = goal;
            Temp = temp;
        }

        public TohObject(Operation operation, Pole start, Pole goal)
        {
            Operation = operation;
            Start = start;
            Goal = goal;
        }
    }

    internal class Program
    {
        public static void Toh(int n, Pole start, Pole goal, Pole temp)
        {
            IStack<TohObject> stack = new ArrayStack<TohObject>(2 * n + 1);
            stack.Push(new TohObject(Operation.Hanoi, n, start, goal, temp));

            while (stack.Length > 0)
            {
                var item = stack.Pop();
                if (item.Operation == Operation.Move)
                {
                    Console.WriteLine($"Moving from {item.Start} to {item.Goal}");
                }
                else if (item.Num > 0)
                {
                    stack.Push(new TohObject(Operation.Hanoi, item.Num - 1, item.Temp, item.Goal, item.Start));
                    stack.Push(new TohObject(Operation.Move, item.Start, item.Goal));
                    stack.Push(new TohObject(Operation.Hanoi, item.Num - 1, item.Start, item.Temp, item.Goal));
                }
            }
        }

        public static void Main(string[] args)
        {
            Toh(3, Pole.A, Pole.B, Pole.C);
            Console.ReadLine();
        }
    }
}