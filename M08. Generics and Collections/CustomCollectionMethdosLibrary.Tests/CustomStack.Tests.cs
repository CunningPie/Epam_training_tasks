using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionMethdosLibrary.Tests
{
    public class CustomStackTests
    {
        [TestCase(1)]
        [TestCase(1.2)]
        [TestCase("df")]
        public void Push_AddElements_ShouldBeEqualToExpected<T>(T value)
        {
            var stack = new CustomStack<T>();

            stack.Push(value);

            Assert.AreEqual(value, stack.Peek());
        }

        [TestCase(7, new int[] { 1, 2, 3, 6, 4, 5, 6, 7 })]
        [TestCase("gh", new string[] { "abc", "def", "gh" })]
        [TestCase(4, new double[] { 1.2, 4.7, 3, 6, 4 })]
        public void Pop_PopUpperElement_ShouldReturnElementEqualToExpected<T>(T expected, T[] values)
        {
            var stack = new CustomStack<T>(values);

            Assert.AreEqual(expected, stack.Pop());
        }

        [TestCase(7, new int[] { 1, 2, 3, 6, 4, 5, 6, 7 })]
        [TestCase(2, new string[] { "abc", "def", "gh" })]
        [TestCase(4, new double[] { 1.2, 4.7, 3, 6, 4 })]
        public void Pop_PopUpperElement_ShouldCountBeEqualToExpected<T>(int expectedCount, T[] values)
        {
            var stack = new CustomStack<T>(values);

            var popped = stack.Pop();

            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestCase(7, new int[] { 1, 2, 3, 6, 4, 5, 6, 7 })]
        [TestCase("gh", new string[] { "abc", "def", "gh" })]
        [TestCase(4, new double[] { 1.2, 4.7, 3, 6, 4 })]
        public void Peek_TakeUpperElement_ShouldReturnItemEqualToExpected<T>(T expected, T[] values)
        {
            var stack = new CustomStack<T>(values);

            var peek = stack.Peek();

            Assert.AreEqual(expected, peek);
        }

        [Test]
        public void IsEmpty_CheckEmptyStack_ShouldReturnTrue()
        {
            var stack = new CustomStack<int>();

            Assert.IsTrue(stack.IsEmpty());
        }

        [TestCase(new int[] { 1, 2, 3, 6, 4, 5, 6, 7 })]
        [TestCase(new double[] { 1.2, 4.7, 3, 6, 4 })]
        public void IsEmpty_CheckNotEmptyStack_ShouldReturnFalse<T>(T[] values)
        {
            var stack = new CustomStack<T>(values);

            Assert.False(stack.IsEmpty());
        }
    }
}
