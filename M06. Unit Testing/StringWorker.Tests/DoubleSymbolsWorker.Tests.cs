using NUnit.Framework;
using System;

namespace StringWorker.Tests
{
    [TestFixture]
    public class DoubleSymbolsWorkerTests
    {
        [TestCase("aa*** aa;; aa. aa! aa, aa", "a*** a;; a. a! a, a", "a")]
        [TestCase("a bb c", "a b c", "bb")]
        [TestCase("oomg i loovee shreekk", "omg i love shrek", "o kek")]
        public void DoubleSymbols_CorrectInput_ShouldReturnExpectedValue(string expected, string str, string template)
        {
            Assert.AreEqual(expected, DoubleSymbolsWorker.DoubleSymbols(str, template));
        }

        [TestCase(null, "abc d d")]
        [TestCase("abc d d", null)]
        public void DoubleSymbols_NullInput_ShouldThrowArgumentNullException(string str, string template)
        {
            Assert.Throws<ArgumentNullException>(() => DoubleSymbolsWorker.DoubleSymbols(str, template));
        }

        [TestCase("", "abc d d")]
        [TestCase("abc d d", "")]
        public void DoubleSymbols_EmptyInput_ShouldThrowArgumentException(string str, string template)
        {
            Assert.Throws<ArgumentException>(() => DoubleSymbolsWorker.DoubleSymbols(str, template));
        }

        [TestCase("a*** a;; a. a! a, a", "a*** a;; a. a! a, a", "b")]
        [TestCase("a b c", "a b c", "z")]
        public void DoubleSymbols_TemplateWithoutContainedSymbols_ShouldReturnExpectedValue(string expected, string str, string template)
        {
            Assert.AreEqual(expected, DoubleSymbolsWorker.DoubleSymbols(str, template));
        }
    }
}
