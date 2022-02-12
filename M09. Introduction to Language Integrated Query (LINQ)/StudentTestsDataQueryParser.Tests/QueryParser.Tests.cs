using StudentTestsDataQueryParser;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace TestsDataQueries.Tests
{
    public class Tests
    {
        List<StudentTest> _tests;
        QueryParser _querieParser;

        [SetUp]
        public void Setup()
        {
            _tests = new List<StudentTest>();
            _querieParser = new QueryParser("../../../StudentsData.json");
        }

        [Test]
        public void ParseQuery_Name_ShouldReturnExpectedValue()
        {
            var query = "-name Andrei";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Andrei Smirnov", "Maths", System.DateTime.Parse("12/01/2022"), 3));
            expected.Add(new StudentTest("Andrei Smirnov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Literature", System.DateTime.Parse("06/01/2022"), 4));
            expected.Add(new StudentTest("Andrei Smirnov", "Art", System.DateTime.Parse("12/01/2022"), 4));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_Test_ShouldReturnExpectedValue()
        {
            var query = "-test Maths";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Petr Ivanov", "Maths", System.DateTime.Parse("13/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Maths", System.DateTime.Parse("12/01/2022"), 3));
            expected.Add(new StudentTest("Nikolai Petrov", "Maths", System.DateTime.Parse("11/01/2022"), 4));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_Mark_ShouldReturnExpectedValue()
        {
            var query = "-mark 5";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Petr Ivanov", "Maths", System.DateTime.Parse("13/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Literature", System.DateTime.Parse("06/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Art", System.DateTime.Parse("06/01/2022"), 5));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_MinMark_ShouldReturnExpectedValue()
        {
            var query = "-minmark 4";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Petr Ivanov", "Maths", System.DateTime.Parse("13/01/2022"), 5));
            expected.Add(new StudentTest("Nikolai Petrov", "Maths", System.DateTime.Parse("11/01/2022"), 4));
            expected.Add(new StudentTest("Petr Ivanov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Literature", System.DateTime.Parse("06/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Literature", System.DateTime.Parse("06/01/2022"), 4));
            expected.Add(new StudentTest("Petr Ivanov", "Art", System.DateTime.Parse("06/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Art", System.DateTime.Parse("12/01/2022"), 4));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_MaxMark_ShouldReturnExpectedValue()
        {
            var query = "-maxmark 3";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Andrei Smirnov", "Maths", System.DateTime.Parse("12/01/2022"), 3));
            expected.Add(new StudentTest("Nikolai Petrov", "Biology", System.DateTime.Parse("05/01/2022"), 3));
            expected.Add(new StudentTest("Nikolai Petrov", "Literature", System.DateTime.Parse("06/01/2022"), 2));
            expected.Add(new StudentTest("Nikolai Petrov", "Art", System.DateTime.Parse("12/01/2022"), 2));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_Date_ShouldReturnExpectedValue()
        {
            var query = "-date 12/01/2022";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Andrei Smirnov", "Maths", System.DateTime.Parse("12/01/2022"), 3));
            expected.Add(new StudentTest("Andrei Smirnov", "Art", System.DateTime.Parse("12/01/2022"), 4));
            expected.Add(new StudentTest("Nikolai Petrov", "Art", System.DateTime.Parse("12/01/2022"), 2));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_DateFrom_ShouldReturnExpectedValue()
        {
            var query = "-datefrom 13/01/2022";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Petr Ivanov", "Maths", System.DateTime.Parse("13/01/2022"), 5));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_DateTo_ShouldReturnExpectedValue()
        {
            var query = "-dateto 06/01/2022";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Petr Ivanov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Nikolai Petrov", "Biology", System.DateTime.Parse("05/01/2022"), 3));
            expected.Add(new StudentTest("Petr Ivanov", "Literature", System.DateTime.Parse("06/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Literature", System.DateTime.Parse("06/01/2022"), 4));
            expected.Add(new StudentTest("Nikolai Petrov", "Literature", System.DateTime.Parse("06/01/2022"), 2));
            expected.Add(new StudentTest("Petr Ivanov", "Art", System.DateTime.Parse("06/01/2022"), 5));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseQuery_Sort_ShouldReturnExpectedValue()
        {
            var query = "-sort name asc";
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Andrei Smirnov", "Maths", System.DateTime.Parse("12/01/2022"), 3));
            expected.Add(new StudentTest("Andrei Smirnov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Andrei Smirnov", "Literature", System.DateTime.Parse("06/01/2022"), 4));
            expected.Add(new StudentTest("Andrei Smirnov", "Art", System.DateTime.Parse("12/01/2022"), 4));
            expected.Add(new StudentTest("Nikolai Petrov", "Maths", System.DateTime.Parse("11/01/2022"), 4));
            expected.Add(new StudentTest("Nikolai Petrov", "Biology", System.DateTime.Parse("05/01/2022"), 3));
            expected.Add(new StudentTest("Nikolai Petrov", "Literature", System.DateTime.Parse("06/01/2022"), 2));
            expected.Add(new StudentTest("Nikolai Petrov", "Art", System.DateTime.Parse("12/01/2022"), 2));
            expected.Add(new StudentTest("Petr Ivanov", "Maths", System.DateTime.Parse("13/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Biology", System.DateTime.Parse("05/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Literature", System.DateTime.Parse("06/01/2022"), 5));
            expected.Add(new StudentTest("Petr Ivanov", "Art", System.DateTime.Parse("06/01/2022"), 5));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [TestCase("-name Andrei -test Biology")]
        [TestCase("-name Andrei -test Biology -datefrom 03/01/2022 -dateto 20/01/2022 -minmark 5 -sort mark desc")]
        [TestCase("-name Smirnov -test Biology -date 05/01/2022 -mark 5 -sort date asc")]
        public void ParseQuery_SeveralParams_ShouldReturnExpectedValue(string query)
        {
            var expected = new List<StudentTest>();
            expected.Add(new StudentTest("Andrei Smirnov", "Biology", System.DateTime.Parse("05/01/2022"), 5));

            var result = _querieParser.ParseQuery(query);

            Assert.AreEqual(expected, result);
        }

        [TestCase("-nameasd Andrei -test Biology")]
        [TestCase("-name ")]
        [TestCase("mark")]
        [TestCase("")]
        [TestCase("-sort asc")]
        [TestCase("-sort name")]
        [TestCase("-date notdateinput")]
        [TestCase("-mark notnumber")]
        public void ParseQuery_WrongInput_ShouldThrowArgumentException(string query)
        {
            Assert.Throws<ArgumentException>(() => _querieParser.ParseQuery(query));
        }

        [TestCase(null)]
        public void ParseQuery_NullInput_ShouldThrowArgumentNullException(string query)
        {
            Assert.Throws<ArgumentNullException>(() => _querieParser.ParseQuery(query));
        }
    }
}