using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace ArrayHelper
{
    /// <summary>
    /// Класс сортировщик массивов.
    /// </summary>
    public static class ArraySorter 
    {
        private static void Swap<T>(this T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /// <summary>
        /// Сортировка пузырьком.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"> Сортируемый массив </param>
        /// <param name="comp"> Компаратор сравнения для типа T </param>
        /// <param name="asc"> Флаг сортировки по возрастанию/убыванию </param>
        public static void BubbleSort<T>(this T[] array, IComparer<T> comp, bool asc = true)
        {
            Guard.Against.Null(array, "");
            Guard.Against.Null(comp, "");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (comp.Compare(array[i], array[j]) < 0 ? asc : !asc)
                    {
                        array.Swap(i, j);
                    }
                }
            }
        }
    }
}
