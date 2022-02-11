using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_Delegates_Lambdas_and_Events
{
    /// <summary>
    /// Расширение функционала одномерного массива int.
    /// </summary>
    public static class IntArrayExtensionMethods
    {
        /// <summary>
        /// Меняет местами i-й и j-й элементы массива.
        /// </summary>
        public static void Swap(this int[] array, int i, int j)
        {
            Guard.Against.Null(array, nameof(array));
            Guard.Against.InvalidInput(i, nameof(i), (x) => { return x < array.Length && x >= 0; });
            Guard.Against.InvalidInput(j, nameof(j), (x) => { return x < array.Length && x >= 0; });

            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
