using NUnit.Framework;
using System;

namespace StringWorker.Tests
{
    [TestFixture]
    public class BigNumbersCalculatorTests
    {
        [TestCase("22222222222222222222", "11111111111111111111", "11111111111111111111")]
        [TestCase("2", "1", "1")]
        [TestCase("55", "54", "1")]
        [TestCase("0", "0", "0")]
        public void Sum_TwoCorrect_ShouldReturnExpectedSum(string expected, string strA, string strB)
        {
            Assert.AreEqual(expected, BigNumbersCalculator.Sum(strA, strB));
        }

        [TestCase("1$", "1")]
        [TestCase("54", "1&!")]
        public void Sum_InvalidInput_ShouldThrowArgumentExpection(string strA, string strB)
        {
            Assert.Throws<ArgumentException>(() => BigNumbersCalculator.Sum(strA, strB));
        }

        [TestCase("111", "", "111")]
        [TestCase("123", "123", "")]
        [TestCase("0", "", "")]
        public void Sum_EmptyInput_ShouldReturnExpectedValue(string expected, string strA, string strB)
        {
            Assert.AreEqual(expected, BigNumbersCalculator.Sum(strA, strB));
        }
    }
}
