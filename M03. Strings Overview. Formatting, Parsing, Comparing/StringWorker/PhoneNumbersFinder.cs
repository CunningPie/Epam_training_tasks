using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace StringWorker
{
    internal class PhoneNumbersFinder
    {
        /// <summary>
        /// Ищет номера телефонов в текстовом файле по формату +X (XXX) XXX-XX-XX, X XXX XXX-XX-XX или +XXX (XX) XXX-XXXX
        /// и записывает их в файл dstFile. Возвращает список найденных номеров.
        /// </summary>
        static public List<string> FindNumbers(string srcFile, string dstFile)
        {
            Guard.Against.NullOrEmpty(srcFile, nameof(srcFile));
            Guard.Against.NullOrEmpty(dstFile, nameof(srcFile));

            var result = new List<string>();
            var numberFormat1 = new Regex(@"\+?\d? ?\(?\d{3}\)?-? *\d{3}-?-\d{2}-?\d{2}"); // +X (XXX) XXX-XX-XX или  X XXX XXX-XX-XX
            var numberFormat2 = new Regex(@"\+?\d{3}? ?\({1}\d{2}\){1}-? *\d{3}-?\d{4}"); // +XXX (XX) XXX-XXXX 

            using (var reader = new StreamReader(srcFile))
            {
                string text = reader.ReadToEnd();
                result.AddRange(numberFormat1.Matches(text).Select(x => x.Value).ToList());
                result.AddRange(numberFormat2.Matches(text).Select(x => x.Value).ToList());
            }

            using (var writer = new StreamWriter(dstFile))
            {
                foreach (string number in result)
                {
                    writer.WriteLine(number);
                }
            }

            return result;
        }
    }
}
