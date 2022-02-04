using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace StringConverter.Tests
{
    public class IntegerParserTests
    {
        IntegerParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new IntegerParser(Mock.Of<ILogger<IntegerParser>>());
        }

        [TestCase("1", 1)]
        [TestCase("0", 0)]
        [TestCase("-12", -12)]
        public void ParseInteger_CorrectInput_ShouldReturnExpectedValue(string num, int expected)
        {
            Assert.AreEqual(expected, _parser.ParseInteger(num));
        }

        [Test]
        public void ParseInteger_MinValueInput_ShouldReturnIntMinValue()
        {
            Assert.AreEqual(int.MinValue, _parser.ParseInteger(int.MinValue.ToString()));
        }

        [Test]
        public void ParseInteger_MaxValueInput_ShouldReturnIntMaxValue()
        {
            Assert.AreEqual(int.MaxValue, _parser.ParseInteger(int.MaxValue.ToString()));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ParseInteger_NullEmptyOrWhiteSpaceString_ShouldThrowArgumentException(string num)
        {
            Assert.Throws<ArgumentException>(() => { _parser.ParseInteger(num); });
        }

        [TestCase("a")]
        [TestCase("%")]
        [TestCase(" 123")]
        [TestCase("12 3 4")]
        [TestCase("12%3")]
        [TestCase("123av")]
        [TestCase("--123")]
        [TestCase("-123-")]
        [TestCase("123.3")]
        public void ParseInteger_IncorrectSymbolsInput_ShouldThrowArgumentOutOfRangeException(string num)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { _parser.ParseInteger(num); });
        }

        [TestCase("1234567891011121314151617")]
        [TestCase("-9999999999999999999")]
        public void ParseInteger_OverflowInput_ShouldThrowOverflowException(string num)
        {
            Assert.Throws<OverflowException>(() => { _parser.ParseInteger(num); });
        }
    }
}