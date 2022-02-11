using System;

namespace ReversePolishNotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReversePolishNotationParser.Calculate("5 1 2 + 4 * + 3 -"));
            Console.WriteLine(ReversePolishNotationParser.Calculate("    "));

            try
            {
                Console.WriteLine("Throwing exception due to invalid expression example: \"5 - 1 2 + 4 * +3 - \"");
                Console.WriteLine(ReversePolishNotationParser.Calculate("5 - 1 2 + 4 * + 3 -"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
