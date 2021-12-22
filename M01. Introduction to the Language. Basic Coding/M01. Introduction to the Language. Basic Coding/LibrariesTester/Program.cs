using System;
using System.Collections.Generic;
using ArrayHelper;
using RectangleHelper;

namespace LibrariesTester
{
    /// <summary>
    /// Класс расширения generic массивов методом перевода элементом в одну строку.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Метод, приводящий все элементы массива в одну строку через пробел.
        /// </summary>
        public static string ArrayToString<T>(this T[] array)
        {
            if (array == null)
                throw new NullReferenceException();
            string str = "";

            for (int i = 0; i < array.Length; i++)
                str += " " + array[i].ToString();

            return str;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int [] intArray = { 1, 2, 7, 4, 12, 9 };
            string[] stringArray = { "1", "22", "333", "1", "4444", "22", "1", "55555" };
            int[] nullArray = { 1 };
            int[,] intTwoDimArray = {{ 1, 2, 3 },
                                     { 0 ,-2, 4 },
                                     {-4, 6, 0 }};
            double[,] dblTwoDimArray = {{ 1, 2.5, 0 },
                                     { 0 ,-2.7, 4.3 },
                                     {-0.17, 6.1, 0 }};
            float[,] floatTwoDimArray = {{ 1, 2, 3.7f },
                                         { 0.13f ,-2.3f, 4.12f },
                                         {-4, 6.123f, 0 }};

            double width = 12.0;
            double height = 5;
            double negativeWidth = -3;
            double negativeHeight = -14;

            Console.WriteLine("---ArrayHelper test module---\n");
            Console.WriteLine("---Array bubble sort---");
            Console.WriteLine("Unsorted integer array :" + intArray.ArrayToString());
            intArray.BubbleSort(Comparer<int>.Default, true);
            Console.WriteLine("Sorted ascending integer array :" + intArray.ArrayToString());

            Console.WriteLine("Unsorted string array :" + stringArray.ArrayToString());
            stringArray.BubbleSort(Comparer<string>.Create((x, y) => x.Length - y.Length), false);
            Console.WriteLine("Sorted descending by length string array :" + stringArray.ArrayToString());

            try
            {
                Console.WriteLine("Unsorted int array with null comparer:" + nullArray.ArrayToString());
                nullArray.BubbleSort(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n---Array elements sum---");

            Console.WriteLine("Integer 2-dim array positive elements sum: " + intTwoDimArray.SumPositiveElements());
            Console.WriteLine("Double 2-dim array positive elements sum: " + dblTwoDimArray.SumPositiveElements());
            Console.WriteLine("Float 2-dim array positive elements sum: " + floatTwoDimArray.SumPositiveElements());

            Console.WriteLine("\n---RectangleHelper test module---");

            Console.WriteLine("Perimeter of rectangle with width = " + width + " ; height = " + height + " is: " + RectangleMath.RectanglePerimeter(width, height));
            Console.WriteLine("Perimeter of rectangle with width = " + width + " ; height = " + height + " is: " + RectangleMath.RectangleSquare(width, height));

            Console.WriteLine("Trying to calculate perimeter and square with nonpositive values");
            try
            {
                Console.WriteLine("Perimeter of rectangle with width = " + width + " ; height = " + negativeHeight + " is: " + RectangleMath.RectanglePerimeter(width, negativeHeight));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                Console.WriteLine("Perimeter of rectangle with width = " + negativeWidth + " ; height = " + height + " is: " + RectangleMath.RectangleSquare(negativeWidth, height));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.ReadLine();
        }
    }
}
