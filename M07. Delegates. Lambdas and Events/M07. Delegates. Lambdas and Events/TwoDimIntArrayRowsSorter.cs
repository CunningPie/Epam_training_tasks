using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_Delegates_Lambdas_and_Events
{
    /// <summary>
    /// Класс сортировки строк двумерного массива int.
    /// </summary>
    public static class TwoDimIntArrayRowsSorter
    {
        /// <summary>
        /// Делегат способа сравнения строк массива, возвращающий базис значений по которым происходит сравнение строк.
        /// </summary>
        public delegate int[] GetRowsElements(int[,] array);

        private static int GetRowMaxElement(int[] row)
        {
            Guard.Against.Null(row, nameof(row));

            return row.Max();
        }

        /// <summary>
        /// Возвращает базис значений максимальных элементов строк двумерного массива.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] GetRowsElementsMax(int[,] arr)
        {
            Guard.Against.Null(arr, nameof(arr));

            var maxElements = new int[arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                maxElements[i] = GetRowMaxElement(arr.GetRow(i));
            }

            return maxElements;
        }

        private static int RowElementsSum(int[] row)
        {
            Guard.Against.Null(row, nameof(row));

            return row.Sum();
        }

        /// <summary>
        /// Возвращает базис значений сумм элементов строк двумерного массива.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] GetRowsElementsSum(int[,] arr)
        {
            Guard.Against.Null(arr, nameof(arr));

            var rowSums = new int[arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                rowSums[i] = RowElementsSum(arr.GetRow(i));
            }

            return rowSums;
        }

        private static int GetRowMinElement(int[] row)
        {
            Guard.Against.Null(row, nameof(row));

            return row.Min();
        }

        /// <summary>
        /// Возвращает базис значений минимальных элементов строк двумерного массива.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] GetRowsElementsMin(int[,] arr)
        {
            Guard.Against.Null(arr, nameof(arr));

            var maxElements = new int[arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                maxElements[i] = GetRowMinElement(arr.GetRow(i));
            }

            return maxElements;
        }

        /// <summary>
        /// Сортирует двумерный массив типа int с помощью базиса сравнения basisComparer.
        /// </summary>
        /// <param name="array">Двумерный массив типа int.</param>
        /// <param name="basisComparer">Базис значений строк, по которым происходит сортировка.</param>
        /// <param name="asc">Флаг сортировки по возрастанию/убыванию.</param>
        public static void Sort(int[,] array, GetRowsElements basisComparer, bool asc = true)
        {
            Guard.Against.Null(array, nameof(array));

            var basis = basisComparer(array);

            for (int i = 0; i < basis.Length; i++)
            {
                for (int j = 0; j < basis.Length; j++)
                {
                    if (basis[i] > basis[j] ? !asc : asc)
                    {
                        array.SwapRow(i, j);
                        basis.Swap(i, j);
                    }
                }
            }
        }
    }
}
