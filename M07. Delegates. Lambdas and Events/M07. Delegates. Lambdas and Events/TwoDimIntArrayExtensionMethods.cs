using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_Delegates_Lambdas_and_Events
{
    /// <summary>
    /// Расширение функционала двумерного массива int.
    /// </summary>
    public static class TwoDimIntArrayExtensionMethods
    {
        private static void Swap(this int[,] array, int i, int rowA, int rowB)
        {
            var temp = array[rowA, i];
            array[rowA, i] = array[rowB, i];
            array[rowB, i] = temp;
        }

        /// <summary>
        /// Получает строку двумерного массива arr с номером rowNum.
        /// </summary>
        /// <param name="array">Двумерный массив int.</param>
        /// <param name="rowNum">Номер строки.</param>
        public static int[] GetRow(this int[,] array, int rowNum)
        {
            Guard.Against.Null(array, nameof(array));
            Guard.Against.InvalidInput(rowNum, nameof(rowNum), (x) => { return x < array.GetLength(0) && x >= 0; });

            return Enumerable.Range(0, array.GetLength(1)).Select(x => array[rowNum, x]).ToArray();
        }

        /// <summary>
        /// Меняет местами строки с номерами rowA и rowB.
        /// </summary>
        public static void SwapRow(this int[,] array, int rowA, int rowB)
        {
            Guard.Against.Null(array, nameof(array));
            Guard.Against.InvalidInput(rowA, nameof(rowA), (x) => { return x < array.GetLength(0) && x >= 0; });
            Guard.Against.InvalidInput(rowB, nameof(rowB), (x) => { return x < array.GetLength(0) && x >= 0; });

            for (int i = 0; i < array.GetLength(1); i++)
            {
                Swap(array, i, rowA, rowB);
            }
        }

        /// <summary>
        /// Возвращает строку со всеми элементами массива в виде матрицы.
        /// </summary>
        public static string ElementsToString(this int[,] array)
        {
            Guard.Against.Null(array, nameof(array));

            var str = new StringBuilder();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    str.Append(array[i, j]).Append(' ');
                }

                str.Append('\n');
            }

            return str.ToString();
        }
    }
}
