using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    [TestClass]
    public class SorterTest
    {
        // Concrete Sorters to be tested.
        public static IEnumerable<object[]> Sorters
        {
            get
            {
                yield return new object[] { new BubbleSort() };
                yield return new object[] { new SelectionSort() };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldThowArgumentNullExceptionIfArrayIsNull(ISorter sorter)
        {
            object[] mockArray = null;

            Assert.ThrowsException<ArgumentNullException>(
                () => sorter.Sort(mockArray, (i, j) => 0),
                "",
                "collection");
        }

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldReturnUnchangedArrayIfCountLessThanTwo(ISorter sorter)
        {
            var mockArray = new Mock<IList<It.IsAnyType>>();
            mockArray.Setup(m => m.Add(It.IsAny<It.IsAnyType>()));

            var mockClone = new Mock<IList<It.IsAnyType>>();
            mockArray.Object.CopyTo(mockClone.Object as It.IsAnyType[], 0);

            sorter.Sort(mockArray.Object, (i, j) => 0);

            Assert.IsFalse(ReferenceEquals(mockArray.Object, mockClone.Object));

            for (int i = 0; i < mockArray.Object.Count; i++)
            {
                Assert.AreEqual(mockArray.Object[i], mockClone.Object[i]);
            }
        }

        #region General sorting algorithm tests.

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldSortValuesWhenTImplimentsIComparable(ISorter sorter)
        {
            foreach (var testArray in GetTestArrays())
            {
                var foo = sorter.Sort(testArray);
                for (int i = 1; i < foo.Count; i++)
                {
                    Assert.IsTrue(foo[i] >= (foo[i - 1]));
                }
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldSortValuesWhenIComparerTPassedAsArgument(ISorter sorter)
        {
            foreach (var testArray in GetTestArrays())
            {
                sorter.Sort(testArray, new ReverseIntComparer());
                for (int i = 1; i < testArray.Length; i++)
                {
                    Assert.IsTrue(testArray[i] <= (testArray[i - 1]));
                }
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldSortValuesWhenComparisonTPassedAsArgument(ISorter sorter)
        {
            foreach (var testArray in GetTestArrays())
            {
                sorter.Sort(testArray, (p, c) => c - p);
                for (int i = 1; i < testArray.Length; i++)
                {
                    Assert.IsTrue(testArray[i] <= (testArray[i - 1]));
                }
            }
        }

        #endregion

        private IEnumerable<int[]> GetTestArrays()
        {
            yield return new int[] { 0, 0 };
            yield return new int[] { 0, 0, 0 };
            yield return new int[] { 0, 1 };
            yield return new int[] { 1, 0 };
            yield return new int[] { 0, 1, 2 };
            yield return new int[] { 0, 2, 1 };
            yield return new int[] { 1, 0, 2 };
            yield return new int[] { 1, 2, 0 };
            yield return new int[] { 2, 1, 0 };
            yield return new int[] { 2, 0, 1 };
            yield return new int[] { 0, 1, 1 };
            yield return new int[] { 1, 0, 1 };
            yield return new int[] { 1, 1, 0 };
            yield return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            yield return new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            yield return new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            yield return new int[] { 12, 6, 3, 13, 65, 1, 78, 1, 31, 21, -1, -5, 213, -7134, 134 };
        }
    }
}
