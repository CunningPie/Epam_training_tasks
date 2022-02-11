using System;

namespace M07_Delegates_Lambdas_and_Events
{
    internal class Program
    {
        private static void InvokeSortDelegate(TwoDimIntArrayRowsSorter.GetRowsElements getRowsElementsBasis, int[,] array, bool asc = true)
        {
            try
            {
                TwoDimIntArrayRowsSorter.Sort(array, getRowsElementsBasis, asc);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            int[,] array = { {1, 2, 3, 4, 5 },
                             {2, 3, 4, 5, 6},
                             {-1, 7, 4, 9, 6},
                             {1, 0, 3, 2, 0}};

            TwoDimIntArrayRowsSorter.GetRowsElements sortBySums = TwoDimIntArrayRowsSorter.GetRowsElementsSum;
            TwoDimIntArrayRowsSorter.GetRowsElements sortByMax = TwoDimIntArrayRowsSorter.GetRowsElementsMax;
            TwoDimIntArrayRowsSorter.GetRowsElements sortByMin = TwoDimIntArrayRowsSorter.GetRowsElementsMin;

            Console.WriteLine(array.ElementsToString());

            InvokeSortDelegate(sortBySums, array);
            Console.WriteLine("Сортировка строк по сумме элементов по возрастанию");
            Console.WriteLine(array.ElementsToString());

            InvokeSortDelegate(sortByMax, array, false);
            Console.WriteLine("Сортировка строк по максимальному элементу по убыванию");
            Console.WriteLine(array.ElementsToString());

            InvokeSortDelegate(sortByMin, array);
            Console.WriteLine("Сортировка строк по минимальному элементу по возрастанию");
            Console.WriteLine(array.ElementsToString());

            InvokeSortDelegate(sortBySums, array, false);
            Console.WriteLine("Сортировка строк по сумме элементов по убыванию");
            Console.WriteLine(array.ElementsToString());

            InvokeSortDelegate(sortByMax, array);
            Console.WriteLine("Сортировка строк по максимальному элементу по возрастанию");
            Console.WriteLine(array.ElementsToString());

            InvokeSortDelegate(sortByMin, array, false);
            Console.WriteLine("Сортировка строк по минимальному элементу по убыванию");
            Console.WriteLine(array.ElementsToString());

            Console.ReadKey();
        }
    }
}
