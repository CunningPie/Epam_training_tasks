using System;
using Ardalis.GuardClauses;

namespace ArrayHelper
{
    /// <summary>
    /// Класс сумматор положительных элементов массива.
    /// </summary>
    public static class ArrayElementsSummator 
    {
        /// <summary>
        /// Метод, суммирующий положительные элементы массива.
        /// </summary>
        public static int SumPositiveElements(this int[,] array)
        {
            Guard.Against.Null<int[,]>(array, "");

            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Метод, суммирующий положительные элементы массива.
        /// </summary>
        public static double SumPositiveElements(this double[,] array)
        {
            Guard.Against.Null<double[,]>(array, "");

            double sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 0)
                    {
                        sum += array[i, j];
                    }
                }
            }


            return sum;
        }

        /// <summary>
        /// Метод, суммирующий положительные элементы массива.
        /// </summary>
        public static float SumPositiveElements(this float[,] array)
        {
            Guard.Against.Null(array, "");

            float sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }
    }
}
