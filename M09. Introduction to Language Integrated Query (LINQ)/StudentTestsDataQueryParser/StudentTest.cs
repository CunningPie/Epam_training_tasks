using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestsDataQueryParser
{
    /// <summary>
    /// Отображает данные теста студента.
    /// </summary>
    public class StudentTest
    {
        /// <summary>
        /// Имя и фамилия студента.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Название теста.
        /// </summary>
        public string Test { get; init; }

        /// <summary>
        /// Дата проведения теста.
        /// </summary>
        public DateTime Date { get; init; }

        /// <summary>
        /// Оценка за тест.
        /// </summary>
        public uint Mark { get; init; }

        /// <summary>
        /// Базовый конструктор.
        /// </summary>
        public StudentTest(string name, string test, DateTime date, uint mark)
        {
            Name = name;
            Test = test;
            Date = date;
            Mark = mark;
        }

        public override bool Equals(object obj)
        {
            return Name == (obj as StudentTest).Name
                   && Test == (obj as StudentTest).Test
                   && Date == (obj as StudentTest).Date
                   && Mark == (obj as StudentTest).Mark;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Test, Date, Mark);
        }
    }
}
