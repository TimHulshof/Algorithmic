using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal class LomutoQuickSort : Sorter
    {
        public override string Name => "Quick Sort - Lomuto Partition Scheme";
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
            return
                "Quicksort scheme developed by Nico Lomuto. Chose the last element as a pivot value to partition the array arount this value. " +
                "Recursevly partition these sub-arrays until the whole array is sorted.";
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

                RecursiveSort(collection, lowIndex, pivot - 1, comparison);
                RecursiveSort(collection, pivot + 1, highIndex, comparison);
            }
        }

        private int Partition<T>(IList<T> collection, int lowIndex, int highIndex, Comparison<T> comparison)
        {
            var comparableElement = collection[highIndex];
            var pivotIndex = lowIndex - 1;

            for (int i = lowIndex; i <= highIndex; i++)
            {
                if (comparison.Invoke(collection[i], comparableElement) <= 0)
                {
                    // Move pivotIndex++ and swap elements at pivotIndex and i.
                    pivotIndex++;
                    var temp = collection[pivotIndex];
                    collection[pivotIndex] = collection[i];
                    collection[i] = temp;
                }
            }

            return pivotIndex;
        }
    }
}
