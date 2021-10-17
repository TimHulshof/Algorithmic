using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    class BubbleSort : SorterBase
    {
        private protected override IList<T> SortAlgorithm<T>(IList<T> collection, ISorter.ElementComparer<T> comparer)
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
                    if (comparer(collection[right], collection[left]))
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
