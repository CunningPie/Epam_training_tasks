using System;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] subjects = { "Math", "PE", "Biology", "Geography", "Chemistry", "Art" };

            var student1c1 = new Student("Stepan.Petrov@epam.com");
            var student2c1 = new Student("Ivan.Ivanov@epam.com");
            var student3c1 = new Student("Sergei.Vasilyev@epam.com");
            var student1c2 = new Student("Stepan", "Petrov");
            var student2c2 = new Student("Ivan", "Ivanov");
            var student3c2 = new Student("Sergei", "Vasilyev");

            Dictionary<Student, HashSet<string>> studentSubjectDict = new Dictionary<Student, HashSet<string>>();

            studentSubjectDict[student1c1] = new HashSet<string>() { subjects[0], subjects[1], subjects[3] };
            studentSubjectDict[student2c1] = new HashSet<string>() { subjects[4], subjects[2], subjects[3] };
            studentSubjectDict[student3c1] = new HashSet<string>() { subjects[2], subjects[5], subjects[4] };
            studentSubjectDict[student1c2] = new HashSet<string>() { subjects[3], subjects[0], subjects[2] };
            studentSubjectDict[student2c2] = new HashSet<string>() { subjects[1], subjects[2], subjects[5] };
            studentSubjectDict[student3c2] = new HashSet<string>() { subjects[5], subjects[3], subjects[1] };

            Console.WriteLine("Students dictionary after adding students:");
            foreach (var element in studentSubjectDict)
            {
                Console.Write(element.Key.FullName + ": ");
                foreach (var setElement in element.Value)
                {
                    Console.Write(setElement + " ");
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }
    }
}
