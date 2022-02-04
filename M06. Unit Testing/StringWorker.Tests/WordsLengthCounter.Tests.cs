using NUnit.Framework;
using System;

namespace StringWorker.Tests
{
    public class WordsLengthCounterTests
    {
        [TestCase(5, "The greatest victory is that which requires no battle")]
        [TestCase(1, "a! a@ a# a$ a% a^")]
        [TestCase(2, "bb ac ae fh aw ay")]
        [TestCase(3.5, "bb a ccc dddd eeeee ffffff")]
        public void AverageWordLength_CorrectStrings_ShouldReturnExpectedValue(double expected, string str)
        {
            Assert.AreEqual(expected, WordLengthCounter.AverageWordLength(str));
        }

        [TestCase("$ % @ ! * (")]
        public void AverageWordLength_WordsWithoutLetters_ShouldReturn0(string str)
        {
            Assert.AreEqual(0, WordLengthCounter.AverageWordLength(str));
        }

        [Test]
        public void AverageWordLength_EmptyString_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => WordLengthCounter.AverageWordLength(""));
        }

        [Test]
        public void AverageWordLength_NullString_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WordLengthCounter.AverageWordLength(null));
        }
    }
}