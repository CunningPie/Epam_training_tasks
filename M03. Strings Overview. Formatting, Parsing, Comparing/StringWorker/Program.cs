using System;
using System.Collections.Generic;
using System.IO;

namespace StringWorker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testString1 = "The greatest victory is that which requires no battle";
            string testString2 = "a*** a;; a. a! a, a,";
            string testString3 = "bb;:; a$$ ccc$$ dddd@@@ eeeee%% ffffff&&&";
            string testString4 = "! @ # $ % ^ & * ( ) - = ";
            string testString5 = "omg i love shrek";
            string testString6 = "The greatest victory is that which requires no battle";

            Console.WriteLine("Average word counter: ");
            Console.WriteLine(testString1 + " : " + WordLengthCounter.AverageWordLength(testString1));
            Console.WriteLine(testString2 + " : " + WordLengthCounter.AverageWordLength(testString2));
            Console.WriteLine(testString3 + " : " + WordLengthCounter.AverageWordLength(testString3));
            Console.WriteLine(testString4 + " : " + WordLengthCounter.AverageWordLength(testString4));

            Console.WriteLine("Double symbols worker: ");
            Console.WriteLine(testString2 + ", a : " + DoubleSymbolsWorker.DoubleSymbols(testString2, "a"));
            Console.WriteLine(testString3 + ", abc : " + DoubleSymbolsWorker.DoubleSymbols(testString3, "abc"));
            Console.WriteLine(testString5 + ", o kek : " + DoubleSymbolsWorker.DoubleSymbols(testString5, "o kek"));

            Console.WriteLine("Words order reverser: ");
            Console.WriteLine(testString6 + ": " + WordsOrderReverser.ReverseOrder(testString6));

            Console.WriteLine("Big numbers summator: ");
            var a = "11111111111911191111119111111";
            var b = "22222222222222222222222222222222222";
            Console.WriteLine("Sum of " + a + " and " + b + ":");
            Console.WriteLine(BigNumbersCalculator.Sum(a, b));

            List<string> result;

            result = PhoneNumbersFinder.FindNumbers("Text.txt", "Numbers.txt");

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
