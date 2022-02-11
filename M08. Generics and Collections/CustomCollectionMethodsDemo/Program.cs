using System;
using System.Collections.Generic;
using CustomCollectionMethdosLibrary;

namespace CustomCollectionMethodsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersInt = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            List<double> numbersDouble = new List<double> { 0.3, 1.5, 2.6, 7.5, 9.3 };
            List<char> chars = new List<char> { 'a', 'd', 'f', 'g', 'x', 'z' };

            Console.WriteLine("Collection: 0, 1, 2, 3, 4, 5, 6, 7, 8. Searching for '12':");
            Console.WriteLine(numbersInt.CustomBinarySearch(12));
            Console.WriteLine("Collection: 0.3, 1.5, 2.6, 7.5, 9.3. Searching for '12.2':");
            Console.WriteLine(numbersDouble.CustomBinarySearch(12.2));
            Console.WriteLine("Collection: 0.3, 1.5, 2.6, 7.5, 9.3. Searching for '7.5':");
            Console.WriteLine(numbersDouble.CustomBinarySearch(7.5));
            Console.WriteLine("Collection: a b f g x z. Searching for 'f':");
            Console.WriteLine(chars.CustomBinarySearch('a'));

            Console.WriteLine("First 20 Fibonacci numbers: ");
            try
            {
                foreach (var fib in FibonacciNumbersEnumerator.GetFibonacci(20))
                {
                    Console.WriteLine(fib);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Create stack with some elements: ");
            CustomStack<int> stack = new CustomStack<int>(new int[] {1, 2, 3, 4, 5, 6, 7});

            foreach (var num in stack)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(@"Pop element: {0}", stack.Pop());
            Console.WriteLine("Push \"12\".");
            stack.Push(12);
            Console.WriteLine("Push \"2\".");
            stack.Push(2);
            Console.WriteLine("Push \"-1\".");
            stack.Push(-1);

            Console.WriteLine("Peek element.");
            Console.WriteLine(stack.Peek());

            Console.WriteLine("Resulting stack:");
            foreach (var num in stack)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();
        }
    }
}
