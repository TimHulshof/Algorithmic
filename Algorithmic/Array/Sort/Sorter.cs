using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal abstract class Sorter : ISorter
    {
        IList<T> ISorter.Sort<T>(IList<T> collection)
        {
            return CheckCollection(collection, (p, c) => p.CompareTo(c));
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, IComparer<T> comparer)
        {
            return CheckCollection(collection, (p, c) => comparer.Compare(p, c));
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, Comparison<T> comparison)
        {
            return CheckCollection(collection, comparison);
        }

        private IList<T> CheckCollection<T>(IList<T> collection, Comparison<T> comparison)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            // Collection is already sorted (less then two elements).
            if (collection.Count <= 1)
            {
                return collection;
            }

            return SortAlgorithm(collection, comparison);
        }

        private protected abstract IList<T> SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison);
    }
}
