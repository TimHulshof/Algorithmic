using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal class SelectionSort : Sorter
    {
        private protected override IList<T> SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
        {
            var collectionCount = collection.Count;

            for (int i = 0; i < collectionCount - 1; i++)
            {
                var minIndex = i; // Index of minimum element.
                for (int j = i + 1; j < collectionCount; j++)
                {
                    // Compare elements, update index of minimum comparison.
                    if (comparison.Invoke(collection[minIndex], collection[j]) > 0)
                    {
                        minIndex = j;
                    }
                }
                // Swap minimum element to collection[i] if not already there.
                if (minIndex != i)
                {
                    var temp = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = temp;
                }
            }

            return collection;
        }
    }
}
