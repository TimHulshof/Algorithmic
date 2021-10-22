using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Sorting
{
    internal class InsertionSort : Sorter
    {
        public override string Name => "Insertion Sort.";
        public override Complexity MemoryUsage => throw new NotImplementedException();
        public override Complexity BestComplexity => throw new NotImplementedException();
        public override Complexity AverageComplexity => throw new NotImplementedException();
        public override Complexity WorstComplexity => throw new NotImplementedException();
        public override bool isRecursive => false;
        public override bool isStable => true;
        public override bool isSerial => true;
        public override bool isAdaptive => true;

        private protected override string GetDescription()
        {
            return
                "Sort array by iterating though the array, and at each iteration, sorting back the new element into it's correct order.";
        }

        private protected override void SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
        {
            var sortedIndex = 1;

            while (sortedIndex <= collection.Count - 1)
            {
                var insertValue = collection[sortedIndex];
                var insertIndex = sortedIndex;

                while (insertIndex > 0 && comparison.Invoke(collection[insertIndex - 1], insertValue) > 0)
                {
                    // Swap.
                    collection[insertIndex] = collection[insertIndex - 1];

                    insertIndex--;
                }
                collection[insertIndex] = insertValue;

                sortedIndex++;
            }
        }
    }
}
