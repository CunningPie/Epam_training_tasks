using Microsoft.Extensions.Logging;
using System;

namespace StringConverter
{
    /// <summary>
    /// Парсер целых чисел, представленных в виде строки.
    /// </summary>
    public class IntegerParser
    {
        private static ILogger<IntegerParser> _logger;

        /// <summary>
        /// Конструктор IntegerParser.
        /// </summary>
        public IntegerParser(ILogger<IntegerParser> log)
        {
            _logger = log;
        }

        /// <summary>
        /// Парсинг числа типа integer записанного в строке.
        /// </summary>
        public int ParseInteger(string num)
        {
            _logger.Log(LogLevel.Information, string.Format("Input: {0}", num));

            if (String.IsNullOrWhiteSpace(num))
            {
                _logger.Log(LogLevel.Error, string.Format("Null or empty string. \n {0}", Environment.StackTrace));
                throw new ArgumentException("Null or empty input!");
            }

            var result = 0;
            var sign = 1;
            var offset = 0;

            try
            {
                if (num.IndexOf("-") == 0)
                {
                    sign = -1;
                    offset = 1;
                    _logger.Log(LogLevel.Information, string.Format("Minus from string \"{0}\" parsed", num));
                }

                for (var i = offset; i < num.Length; i++)
                {
                    if (Char.IsDigit(num[i]))
                    {
                        result = checked(result * 10 + sign * (num[i] - '0'));
                        _logger.Log(LogLevel.Information, string.Format("Digit \"{0}\" from string \"{1}\" parsed", num[i], num));
                    }
                    else
                    {
                        _logger.Log(LogLevel.Error, string.Format("String \"{0}\" contains incorrect symbol \"{1}\"!\n {2}", num, num[i], Environment.StackTrace));
                        throw new ArgumentOutOfRangeException(num, num[i], "Invalid symbol in string!");
                    }
                }
            }
            catch (OverflowException ex)
            {
                _logger.Log(LogLevel.Error, $"{ex.Message} \n {ex.StackTrace}");
                throw;
            }

            return result;
        }
    }
}
