using M07_Delegates_Lambdas_and_Events;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsSorter.Tests
{
    public class TwoDimIntArrayRowsSorterTests
    {
        private int[,] _twoDimIntArray;

        [SetUp]
        public void SetUp()
        {
            _twoDimIntArray = new int[,] { {1, 2, 3, 4 },
                                           {2, 3, 4, 5 },
                                           {3, 4, 5, 6 },
                                           {-1, 4, 0, 5 } };
        }

        [TestCase(new int[] { 4, 5, 6, 5 })]
        public void GetRowsElementsMax_CorrectInput_ShouldReturnExpectedValue(int[] expected)
        {
            Assert.AreEqual(expected, TwoDimIntArrayRowsSorter.GetRowsElementsMax(_twoDimIntArray));
        }

        [TestCase(null)]
        public void GetRowsElementsMax_NullArray_ShouldThrowArgumentNullException(int[,] array)
        {
            Assert.Throws<ArgumentNullException>(() => { TwoDimIntArrayRowsSorter.GetRowsElementsMax(array); });
        }

        [TestCase(new int[] { 1, 2, 3, -1 })]
        public void GetRowsElementsMin_CorrectInput_ShouldReturnExpectedValue(int[] expected)
        {
            Assert.AreEqual(expected, TwoDimIntArrayRowsSorter.GetRowsElementsMin(_twoDimIntArray));
        }

        [TestCase(null)]
        public void GetRowsElementsMin_NullArray_ShouldThrowArgumentNullException(int[,] array)
        {
            Assert.Throws<ArgumentNullException>(() => { TwoDimIntArrayRowsSorter.GetRowsElementsMin(array); });
        }

        [TestCase(new int[] { 10, 14, 18, 8 })]
        public void GetRowsElementsSum_CorrectInput_ShouldReturnExpectedValue(int[] expected)
        {
            Assert.AreEqual(expected, TwoDimIntArrayRowsSorter.GetRowsElementsSum(_twoDimIntArray));
        }

        [TestCase(null)]
        public void GetRowsElementsSum_NullArray_ShouldThrowArgumentNullException(int[,] array)
        {
            Assert.Throws<ArgumentNullException>(() => { TwoDimIntArrayRowsSorter.GetRowsElementsSum(array); });
        }

        [Test]
        public void Sort_SortedBySumAscending_ShouldReturnExpectedValue()
        {
            var sortedArray = new int[,] { {-1, 4, 0, 5 },
                                           {1, 2, 3, 4 },
                                           {2, 3, 4, 5 },
                                           {3, 4, 5, 6 } };

            TwoDimIntArrayRowsSorter.Sort(_twoDimIntArray, TwoDimIntArrayRowsSorter.GetRowsElementsSum);

            Assert.AreEqual(sortedArray, _twoDimIntArray);
        }
        [Test]
        public void Sort_SortedBySumDescending_ShouldReturnExpectedValue()
        {
            var sortedArray = new int[,] { {3, 4, 5, 6 },
                                           {2, 3, 4, 5 },
                                           {1, 2, 3, 4 },
                                           {-1, 4, 0, 5 } };

            TwoDimIntArrayRowsSorter.Sort(_twoDimIntArray, TwoDimIntArrayRowsSorter.GetRowsElementsSum, false);

            Assert.AreEqual(sortedArray, _twoDimIntArray);
        }


        [Test]
        public void Sort_SortedByMaxAscending_ShouldReturnExpectedValue()
        {
            var sortedArray = new int[,] { {1, 2, 3, 4 },
                                           {-1, 4, 0, 5 },
                                           {2, 3, 4, 5 },
                                           {3, 4, 5, 6 } };

            TwoDimIntArrayRowsSorter.Sort(_twoDimIntArray, TwoDimIntArrayRowsSorter.GetRowsElementsMax);

            Assert.AreEqual(sortedArray, _twoDimIntArray);
        }

        [Test]
        public void Sort_SortedByMaxDescending_ShouldReturnExpectedValue()
        {
            var sortedArray = new int[,] { {3, 4, 5, 6 },
                                           {2, 3, 4, 5 },
                                           {-1, 4, 0, 5 },
                                           {1, 2, 3, 4 } };

            TwoDimIntArrayRowsSorter.Sort(_twoDimIntArray, TwoDimIntArrayRowsSorter.GetRowsElementsMax, false);

            Assert.AreEqual(sortedArray, _twoDimIntArray);
        }

        [Test]
        public void Sort_SortedByMinAscending_ShouldReturnExpectedValue()
        {
            var sortedArray = new int[,] { {-1, 4, 0, 5 },
                                           {1, 2, 3, 4 },
                                           {2, 3, 4, 5 },
                                           {3, 4, 5, 6 } };

            TwoDimIntArrayRowsSorter.Sort(_twoDimIntArray, TwoDimIntArrayRowsSorter.GetRowsElementsMin);

            Assert.AreEqual(sortedArray, _twoDimIntArray);
        }

        [Test]
        public void Sort_SortedByMinDescending_ShouldReturnExpectedValue()
        {
            var sortedArray = new int[,] { {3, 4, 5, 6 },
                                           {2, 3, 4, 5 },
                                           {1, 2, 3, 4 },
                                           {-1, 4, 0, 5 } };

            TwoDimIntArrayRowsSorter.Sort(_twoDimIntArray, TwoDimIntArrayRowsSorter.GetRowsElementsMin, false);

            Assert.AreEqual(sortedArray, _twoDimIntArray);
        }

        [Test]
        public void Sort_NullArray_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { TwoDimIntArrayRowsSorter.Sort(null, TwoDimIntArrayRowsSorter.GetRowsElementsMin, false); });
        }
    }
}
