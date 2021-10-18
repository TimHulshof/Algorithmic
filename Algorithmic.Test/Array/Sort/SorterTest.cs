using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    [TestClass]
    public class SorterTest
    {
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
    }
}
