using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal class HoareQuickSort : Sorter
    {
        public override string Name => "Quick Sort - Hoare Partition Scheme";
        public override Complexity MemoryUsage => throw new NotImplementedException();
        public override Complexity BestComplexity => throw new NotImplementedException();
        public override Complexity AverageComplexity => throw new NotImplementedException();
        public override Complexity WorstComplexity => throw new NotImplementedException();
        public override bool isRecursive => true;
        public override bool isStable => false;
        public override bool isSerial => true;
        public override bool isAdaptive => false;

        private protected override string GetDescription()
        {
            throw new NotImplementedException();
        }

        private protected override void SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
        {
            RecursiveSort(collection, 0, collection.Count - 1, comparison);
        }

        private void RecursiveSort<T>(IList<T> collection, int lowIndex, int highIndex, Comparison<T> comparison)
        {
            if (lowIndex >= 0 && highIndex >= 0 && lowIndex < highIndex)
            {
                var pivot = Partition(collection, lowIndex, highIndex, comparison);

                RecursiveSort(collection, lowIndex, pivot, comparison);
                RecursiveSort(collection, pivot + 1, highIndex, comparison);
            }
        }

        private int Partition<T>(IList<T> collection, int lowIndex, int highIndex, Comparison<T> comparison)
        {
            var comparableElement = collection[(lowIndex + highIndex) / 2];
            
            lowIndex--;
            highIndex++;

            while (true)
            {
                // Shift swapping indicies to first values needing to be swapped.
                do
                {
                    lowIndex++;
                } while (comparison.Invoke(collection[lowIndex], comparableElement) < 0);

                do
                {
                    highIndex--;
                } while (comparison.Invoke(collection[highIndex], comparableElement) > 0);

                // Condition determining sub-array is fully partitioned.
                if (lowIndex >= highIndex)
                {
                    return highIndex;
                }

                // Swap elements every loop.
                var temp = collection[lowIndex];
                collection[lowIndex] = collection[highIndex];
                collection[highIndex] = temp;
            }
        }
    }
}
