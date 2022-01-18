using System;
using System.Text;
using Ardalis.GuardClauses;

namespace StringWorker
{
    internal static class BigNumbersCalculator
    {
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Суммирует неотрицательные целые числа, записанные в строках strA и strB.
        /// </summary>
        public static string Sum(string strA, string strB)
        {
            Guard.Against.InvalidInput(strA, nameof(strA), x => IsDigitsOnly(x));
            Guard.Against.InvalidInput(strB, nameof(strB), x => IsDigitsOnly(x));

            var result = new StringBuilder();
            string biggerTerm = strA.Length > strB.Length ? strA : strB;
            string smallerTerm = strA.Length <= strB.Length ? strA : strB;
            int digitNum;
            int extraAdd = 0;

            for (int i = 0; i < biggerTerm.Length; i++)
            {
                int digitBigger = int.Parse(biggerTerm[biggerTerm.Length - 1 - i].ToString());

                if (i < smallerTerm.Length)
                {
                    int digitSmaller = int.Parse(smallerTerm[smallerTerm.Length - 1 - i].ToString());

                    digitNum = digitSmaller + digitBigger + extraAdd;
                    extraAdd = digitNum / 10;
                    result.Insert(0, digitNum % 10);
                }
                else
                {
                    result.Insert(0, digitBigger + extraAdd);
                    extraAdd = 0;
                }
            }

            if (extraAdd > 0)
            {
                result.Insert(0, extraAdd);
            }

            return result.ToString();
        }
    }
}
