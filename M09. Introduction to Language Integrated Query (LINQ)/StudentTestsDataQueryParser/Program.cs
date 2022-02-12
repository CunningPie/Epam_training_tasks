using System;
using System.Collections.Generic;

namespace StudentTestsDataQueryParser
{
    internal class Program
    {
        private static void DisplayData(IList<StudentTest> data)
        {
            var i = 1;

            Console.WriteLine("№   Name   Test   Date   Mark");

            foreach (var test in data)
            {
                Console.WriteLine(@"{0}. {1} {2} {3} {4}",i++, test.Name, test.Test, test.Date.ToShortDateString(), test.Mark);
            }
        }

        static void Main(string[] args)
        {
            var parser = new QueryParser("../../../StudentsData.json");

            while (true)
            {
                try
                {
                    Console.WriteLine("Input query:");
                    DisplayData(parser.ParseQuery(Console.ReadLine()));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
