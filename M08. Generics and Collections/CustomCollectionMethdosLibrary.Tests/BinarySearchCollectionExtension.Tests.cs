using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CustomCollectionMethdosLibrary.Tests
{
    [TestFixture]
    public class BinarySearchCollectionExtensionTests
    {
        [TestCase(12, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(12.2, new double[] { 0.3, 1.5, 2.6, 7.5, 9.3 })]
        [TestCase('c', new char[] { 'a', 'd', 'f', 'g', 'x', 'z'})]
        public void CustomBinarySearch_NotContainedItem_ShouldReturnMinus1<T>(T notContainedValue, T[] values)
            where T : IComparable<T>, IEquatable<T>
        {
            int result = new List<T>(values).CustomBinarySearch(notContainedValue);

            Assert.AreEqual(-1, result);
        }

        [TestCase(9, 12, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 12 })]
        [TestCase(2, 2.6, new double[] { 0.3, 1.5, 2.6, 7.5, 9.3 })]
        [TestCase(0, 'a', new char[] { 'a', 'd', 'f', 'g', 'x', 'z' })]
        public void CustomBinarySearch_ContainedItem_ShouldReturnExpectedIndex<T>(int expected, T ContainedValue, T[] values)
            where T : IComparable<T>, IEquatable<T>
        {
            int result = new List<T>(values).CustomBinarySearch(ContainedValue);

            Assert.AreEqual(expected, result);
        }

        [TestCase(12, new int[] { 0, 1, 12, 3, 4, -5, 6, 7, 8, 12 })]
        [TestCase(2.6, new double[] { 0.3, 18, 2.6, 9.3, 7.5 })]
        [TestCase('a', new char[] { 'a', 'j', 'f', 'g', 'x', 'z' })]
        public void CustomBinarySearch_UnsortedCollection_ShouldThrowArgumentException<T>(T ContainedValue, T[] values)
            where T : IComparable<T>, IEquatable<T>
        {
            Assert.Throws<ArgumentException>(() => { new List<T>(values).CustomBinarySearch(ContainedValue); });
        }
    }
}