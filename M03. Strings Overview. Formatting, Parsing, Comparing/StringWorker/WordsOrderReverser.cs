using System.Text;
using Ardalis.GuardClauses;

namespace StringWorker
{
    internal static class WordsOrderReverser
    {
        /// <summary>
        /// Возвращает строку с обратным порядком слов из строки str.
        /// </summary>
        public static string ReverseOrder(string str)
        {
            Guard.Against.NullOrEmpty(str, "");

            var res = new StringBuilder();
            var words = str.Split(' ');

            for (int i = words.Length - 1; i >= 0; i--)
            {
                res.Append(words[i]).Append(i > 0 ? " " : "");
            }

            return res.ToString();
        }
    }
}
