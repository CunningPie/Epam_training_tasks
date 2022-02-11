using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionMethdosLibrary
{
    public static class FibonacciNumbersEnumerator
    {
        /// <summary>
        /// Возвращает коллекцию IEnumerable<ulong> чисел ряда Фибоначчи.
        /// </summary>
        /// <param name="amount">Количество чисел.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> GetFibonacci(int amount)
        {
            Guard.Against.NegativeOrZero(amount, nameof(amount));

            ulong fibonacciPrevPrev = 0;
            ulong fibonacciPrev = 1;
            ulong fibonacci = 1;

            yield return 0;

            for (var i = 1; i < amount; i++)
            {
                yield return fibonacci;

                try
                {
                    fibonacci = checked(fibonacciPrev + fibonacciPrevPrev);
                }
                catch (OverflowException ex)
                {
                    throw ex;
                }

                fibonacciPrevPrev = fibonacciPrev;
                fibonacciPrev = fibonacci;
            }
        }
    }
}
