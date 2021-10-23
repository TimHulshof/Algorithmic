using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithmic.Sorting
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
                yield return new object[] { new BinaryHeapSort() };
                yield return new object[] { new HoareQuickSort() };
                yield return new object[] { new InsertionSort() };
                yield return new object[] { new LomutoQuickSort() };
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
            var testArrays = GetTestArrays();
            for (int i = 0; i < testArrays.Count; i++)
            {
                sorter.Sort(testArrays[i]);
                for (int j = 1; j < testArrays[i].Length; j++)
                {
                    Assert.IsTrue(testArrays[i][j] >= (testArrays[i][j - 1]), $"Failed on testArray[{i}]\nSorted output: {GetIntArrayAsString(testArrays[i])}");
                }
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldSortValuesWhenIComparerTPassedAsArgument(ISorter sorter)
        {
            var testArrays = GetTestArrays();
            for (int i = 0; i < testArrays.Count; i++)
            {
                sorter.Sort(testArrays[i], new ReverseIntComparer());
                for (int j = 1; j < testArrays[i].Length; j++)
                {
                    Assert.IsTrue(testArrays[i][j] <= (testArrays[i][j - 1]), $"Failed on testArray[{i}]\nSorted output: {GetIntArrayAsString(testArrays[i])}");
                }
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(Sorters), DynamicDataSourceType.Property)]
        public void ShouldSortValuesWhenComparisonTPassedAsArgument(ISorter sorter)
        {
            Comparison<int> comparison = (p, c) =>
            {
                if (p > c)
                {
                    return -1;
                }
                if (p < c)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            };

            var testArrays = GetTestArrays();
            for (int i = 0; i < testArrays.Count; i++)
            {
                sorter.Sort(testArrays[i], comparison);
                for (int j = 1; j < testArrays[i].Length; j++)
                {
                    Assert.IsTrue(testArrays[i][j] <= (testArrays[i][j - 1]), $"Failed on testArray[{i}]\nSorted output: {GetIntArrayAsString(testArrays[i])}");
                }
            }
        }

        #endregion

        private List<int[]> GetTestArrays()
        {
            return new List<int[]>()                                                        // Array index.
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },                                // 0
                new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },                                // 1
                new int[] { 0, 0 },                                                         // 2
                new int[] { 0, 0, 0 },                                                      // 3
                new int[] { 0, 1 },                                                         // 4
                new int[] { 1, 0 },                                                         // 5
                new int[] { 0, 1, 2 },                                                      // 6
                new int[] { 0, 2, 1 },                                                      // 7
                new int[] { 1, 0, 2 },                                                      // 8
                new int[] { 1, 2, 0 },                                                      // 9
                new int[] { 2, 1, 0 },                                                      // 10
                new int[] { 2, 0, 1 },                                                      // 11
                new int[] { 0, 1, 1 },                                                      // 12
                new int[] { 1, 0, 1 },                                                      // 13
                new int[] { 1, 1, 0 },                                                      // 14
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },                                // 15
                new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },                                // 16
                new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 },                      // 17
                new int[] { 12, 6, 3, 13, 65, 1, 78, 1, 31, 21, -1, -5, 213, -7134, 134 },  // 18
                GetRandomIntArray(100, int.MaxValue),                                       // 19
                GetRandomIntArray(100, int.MaxValue - 1),                                   // 20
                GetRandomIntArray(100, int.MinValue),                                       // 21
                GetRandomIntArray(100, int.MinValue + 1),                                   // 22
                GetRandomIntArray(100),                                                     // 23
                GetRandomIntArray(100),                                                     // 24
                GetRandomIntArray(100),                                                     // 25
                GetRandomIntArray(100),                                                     // 26
                GetRandomIntArray(100),
                GetRandomIntArray(100),
            };
        }

        private int[] GetRandomIntArray(int size, int? injectedValue = null)
        {
            var array = new int[size];
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }

            if (injectedValue is not null)
            {
                var index = random.Next(0, size);
                array[index] = (int)injectedValue;
            }
            return array;
        }

        private string GetIntArrayAsString(int[] array)
        {
            var stringBuilder = new StringBuilder();
            foreach (var element in array)
            {
                stringBuilder.Append(element.ToString() + " ");
            }
            return stringBuilder.ToString();
        }
    }
}
