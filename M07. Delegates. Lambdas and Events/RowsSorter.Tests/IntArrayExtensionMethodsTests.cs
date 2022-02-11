using M07_Delegates_Lambdas_and_Events;
using NUnit.Framework;
using System;

namespace RowsSorter.Tests
{
    public class IntArrayExtensionMethodsTests
    {
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, 0, 0)]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 }, 0, 1)]
        [TestCase(new int[] { 5, 2, 3, 4, 1 }, new int[] { 1, 2, 3, 4, 5 }, 0, 4)]
        public void Swap_TwoElements_ShouldReturnExpectedValue(int[] expected, int[] array, int i, int j)
        {
            array.Swap(i, j);

            Assert.AreEqual(expected, array);
        }

        [TestCase(null)]
        public void Swap_NullArray_ShouldThrowArgumentNullException(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => { array.Swap(0, 1); });
        }

        [TestCase(new int[] { 1, 2 }, 0, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 5)]
        public void Swap_InvalidInput_ShouldThrowArgumentException(int[] array, int i, int j)
        {
            Assert.Throws<ArgumentException>(() => { array.Swap(i, j); });
        }
    }
}