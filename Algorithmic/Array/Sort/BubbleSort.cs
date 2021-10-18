using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    class BubbleSort : Sorter
    {
        private protected override IList<T> SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var maxIndex = collection.Count - 1;
            while (maxIndex != 1)
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

            return collection;
        }
    }
}
