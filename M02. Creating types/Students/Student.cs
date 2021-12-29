using System;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace Students
{
    internal class Student
    {
        /// <summary>
        /// Имя Фамилия студента.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Email студента.
        /// </summary>
        public string Email { get; }

        private string GetFullNameFromEmail(string email)
        {
            return Email.Remove(Email.Length - 9).Replace('.', ' ');
        }

        /// <summary>
        /// Конструктор класса Student с аргументом email.
        /// </summary>
        public Student(string email)
        {
            Guard.Against.NullOrEmpty(email, nameof(email));
            Regex emailRegex = new Regex(@"^[A-Za-z]+\.[A-Za-z]+\@epam.com$");

            if (!emailRegex.IsMatch(email))
            {
                throw new ArgumentException("This is not a correct email!");
            }

            Email = email;
            FullName = GetFullNameFromEmail(Email);
        }

        /// <summary>
        /// Конструктор класса Student с аргументами name и surname.
        /// </summary>
        public Student(string name, string surname)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(surname, nameof(surname));

            Email = $"{name}.{surname}@epam.com";
            FullName = $"{name} {surname}";
        }

        /// <summary>
        /// Перегрузка метода Equals для класса Student.
        /// </summary>
        public override bool Equals(object student)
        {
            return
                FullName == (student as Student).FullName;
        }

        /// <summary>
        /// Перегрузка метода GetHashCode для класса Student.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, 25);
        }

    }
}
