using System.Linq;
using System.Text;
using Ardalis.GuardClauses;

namespace StringWorker
{
    internal static class DoubleSymbolsWorker
    {
        /// <summary>
        /// Дублирует все символы в строке srcStr, которые были найдены в строке symStr.
        /// Например, если srcStr = "omg i love shrek", а symStr = "o kek", то результат будет "oomg i loovee shreekk".
        /// </summary>
        /// <param name="srcStr"> Cтрока, в которой происходит дублирование. </param>
        /// <param name="symStr"> Cтрока, по символам которой ищутся совпадения. </param>
        public static string DoubleSymbols(string srcStr, string symStr)
        {
            Guard.Against.NullOrEmpty(srcStr, "");
            Guard.Against.NullOrEmpty(symStr, "");

            var result = new StringBuilder(srcStr);
            int offset = 0;
            var doubleSyms = symStr.Replace(" ", "").Distinct();

            foreach (char c in doubleSyms)
            {
                for (int i = 0; i < srcStr.Length; i++)
                {
                    if (srcStr[i] == c)
                    {
                        result.Insert(i + offset++, c);
                    }
                }
            }

            return result.ToString();
        }
    }
}
