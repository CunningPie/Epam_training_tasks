using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace StringWorker
{
    /// <summary>
    /// Класс рассчета средней длины слова в строке.
    /// </summary>
    static public class WordLengthCounter
    {
        /// <summary>
        /// Считает среднюю длину слова во входящей строке, не учитываю знаки пунктуации.
        /// </summary>
        static public double AverageWordLength(string str)
        {
            Guard.Against.NullOrEmpty(str, "");

            var words = str.Split(' ');
            var avg = 0;

            foreach (var word in words)
            {
                foreach (var sym in word)
                {
                    if (!Char.IsPunctuation(sym))
                    {
                        avg++;
                    }
                }
            }

            return avg / words.Length;
        }
    }
}
