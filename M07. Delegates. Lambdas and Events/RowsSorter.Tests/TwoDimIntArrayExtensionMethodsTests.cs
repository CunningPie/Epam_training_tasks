using M07_Delegates_Lambdas_and_Events;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsSorter.Tests
{
    public class TwoDimIntArrayExtensionMethodsTests
    {
        int[,] _twoDimIntArray;

        [SetUp]
        public void SetUp()
        {
            _twoDimIntArray = new int[,] { {1, 2, 3, 4 },
                                           {2, 3, 4, 5 },
                                           {3, 4, 5, 6 },
                                           {-1, 4, 0, 5 } };
        }

        [TestCase(new int[] { 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { -1, 4, 0, 5 }, 3)]
        public void GetRow_CorrectInput_ShouldReturnExpectedValue(int[] expected, int i)
        {
            Assert.AreEqual(expected, _twoDimIntArray.GetRow(i));
        }

        [TestCase(null, 1)]
        public void GetRow_NullInput_ShouldThrowArgumentNullException(int[,] array, int i)
        {
            Assert.Throws<ArgumentNullException>(() => { array.GetRow(i); });
        }

        [TestCase(-1)]
        [TestCase(5)]
        public void GetRow_InvalidInput_ShouldThrowArgumentException(int i)
        {
            Assert.Throws<ArgumentException>(() => { _twoDimIntArray.GetRow(i); });
        }

        [TestCase(0, 3)]
        public void SwapRow_CorrectInput_ShouldReturnExpectedValue(int i, int j)
        {
            var swappedArray = new int[,] { {-1, 4, 0, 5 },
                                            {2, 3, 4, 5 },
                                            {3, 4, 5, 6 },
                                            {1, 2, 3, 4 } };

            _twoDimIntArray.SwapRow(i, j);

            Assert.AreEqual(swappedArray, _twoDimIntArray);
        }

        [TestCase(null, 0, 1)]
        public void SwapRow_NullInput_ShouldThrowArgumentNullException(int[,] array, int i, int j)
        {
            Assert.Throws<ArgumentNullException>(() => { array.SwapRow(i, j); });
        }

        [TestCase(-1, 3)]
        [TestCase(5, 2)]
        [TestCase(-5, 2)]
        public void SwapRow_InvalidInput_ShouldThrowArgumentException(int i, int j)
        {
            Assert.Throws<ArgumentException>(() => { _twoDimIntArray.SwapRow(i, j); });
        }

        [Test]
        public void ElementsToString_CorrectInput_ShouldReturnExpectedValue()
        {
            var arrayString = "1 2 3 4 \n2 3 4 5 \n3 4 5 6 \n-1 4 0 5 \n";

            Assert.AreEqual(arrayString, _twoDimIntArray.ElementsToString());
        }

        [TestCase(null)]
        public void ElementsToString_NullInput_ShouldThrowArgumentNullException(int[,] array)
        {
            Assert.Throws<ArgumentNullException>(() => { array.ElementsToString(); });
        }
    }
}
