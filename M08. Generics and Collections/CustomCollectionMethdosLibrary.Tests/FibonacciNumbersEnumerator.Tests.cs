using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionMethdosLibrary.Tests
{
    [TestFixture]
    public class FibonacciNumbersEnumeratorTests
    {
        [TestCase(new ulong[] {0,1,1,2,3})]
        public void GetFibonacci_Get5Numbers_ShouldReturn0_1_1_2_3(ulong[] expected)
        {
            var result = FibonacciNumbersEnumerator.GetFibonacci(5);

            Assert.AreEqual(expected, result);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void GetFibonacci_InvalidAmount_ShouldThrowArgumentException(int invalidAmount)
        {
            Assert.Throws<ArgumentException>(() => { FibonacciNumbersEnumerator.GetFibonacci(invalidAmount); });
        }
    }
}
