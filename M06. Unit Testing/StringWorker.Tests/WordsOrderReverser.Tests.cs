using NUnit.Framework;
using System;

namespace StringWorker.Tests
{
    [TestFixture]
    public class WordsOrderReverserTests
    {
        [TestCase("a", "a")]
        [TestCase("a b c", "c b a")]
        [TestCase("a b cd 12", "12 cd b a")]
        public void ReverseOrder_CorrectInput_ShouldReturnExpectedValue(string expected, string str)
        {
            Assert.AreEqual(expected, WordsOrderReverser.ReverseOrder(str));
        }

        [Test]
        public void ReverseOrder_NullInput_ShouldThrowArgumentNullEcxeption()
        {
            Assert.Throws<ArgumentNullException>(() => WordsOrderReverser.ReverseOrder(null));
        }

        [Test]
        public void ReverseOrder_EmptyInput_ShouldThrowArgumentEcxeption()
        {
            Assert.Throws<ArgumentException>(() => WordsOrderReverser.ReverseOrder(""));
        }
    }
}
