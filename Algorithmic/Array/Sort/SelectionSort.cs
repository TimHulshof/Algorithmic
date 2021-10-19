using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal class SelectionSort : Sorter
    {
        public override string Name => "Selection Sort";
        public override string Description => GetDescription();
        public override Complexity MemoryUsage => throw new NotImplementedException();
        public override Complexity BestComplexity => throw new NotImplementedException();
        public override Complexity AverageComplexity => throw new NotImplementedException();
        public override Complexity WorstComplexity => throw new NotImplementedException();
        public override bool isRecursive => false;
        public override bool isStable => false;
        public override bool isSerial => true;
        public override bool isAdaptive => false;

        private string GetDescription()
        {
            return "Sort array by finding the minimal element in the unsorted part of the array and swapping with the minimal unsorted index." +
                "Complete this process until the entire array is sorted.";
        }

        private protected override void SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
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
        }
    }
}
