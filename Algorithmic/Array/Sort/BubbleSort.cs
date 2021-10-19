using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal class BubbleSort : Sorter
    {
        public override string Name => "Bubble Sort";
        public override string Description => GetDescription();
        public override Complexity MemoryUsage => throw new NotImplementedException();
        public override Complexity BestComplexity => throw new NotImplementedException();
        public override Complexity AverageComplexity => throw new NotImplementedException();
        public override Complexity WorstComplexity => throw new NotImplementedException();
        public override bool isRecursive => false;
        public override bool isStable => true;
        public override bool isSerial => true;
        public override bool isAdaptive => false;

        private string GetDescription()
        {
            return "Sort array by stepping through elements and swap when adjacent elements are in the wrong order. " +
                "Pass through the array multiple times until all of the elements are in the correct order.";
        }

        private protected override void SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
        {
            var maxIndex = collection.Count - 1;
            while (maxIndex != 0)
            {
                bool noSwap = true;
                for (int i = 0; i < maxIndex; i++)
                {
                    var left = i;
                    var right = i + 1;
                    if (comparison.Invoke(collection[left], collection[right]) > 0)
                    {
                        noSwap = false;
                        // Swap
                        var temp = collection[right];
                        collection[right] = collection[left];
                        collection[left] = temp;
                    }
                }

                if (noSwap)
                {
                    break;
                }

                maxIndex--;
            }
        }
    }
}
