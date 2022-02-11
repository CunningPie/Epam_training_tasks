using NUnit.Framework;
using ReversePolishNotation;
using System;

namespace ReversePolishNotation.Tests
{
    public class ReversePolishNotationParserTests
    {
        [TestCase(1, "1")]
        [TestCase(2, "1 1 +")]
        [TestCase(0, "1 1 -")]
        [TestCase(6, "2 3 *")]
        [TestCase(1.5, "3 2 /")]
        public void Calculate_TestOp_ShouldReturn(double expected, string expression)
        {
            double result = ReversePolishNotationParser.Calculate(expression);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1 1 %")]
        [TestCase("1 , 1 -")]
        [TestCase("a 2 + 4 *")]
        public void Calculate_InvalidSymbols_ShouldThrowFormatException(string expression)
        {
            Assert.Throws<FormatException>(() => { ReversePolishNotationParser.Calculate(expression); });
        }

        [TestCase("5 1*")]
        [TestCase("1 1-")]
        public void Calculate_InvalidSpaces_ShouldThrowFormatException(string expression)
        {
            Assert.Throws<FormatException>(() => { ReversePolishNotationParser.Calculate(expression); });
        }

        [TestCase("1 *")]
        [TestCase("1 2 1 -")]
        [TestCase("1 2 - + 2 4")]
        public void Calculate_InvalidOperandsAmount_ShouldThrowArgumentException(string expression)
        {
            Assert.Throws<ArgumentException>(() => { ReversePolishNotationParser.Calculate(expression); });
        }

        public void Calculate_NullExpression_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { ReversePolishNotationParser.Calculate(null); });
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("       ")]
        public void Calculate_EmptyExpression_ShouldReturn0(string expression)
        {
            Assert.Zero(ReversePolishNotationParser.Calculate(expression));
        }
    }
}