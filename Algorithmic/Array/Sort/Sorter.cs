using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal abstract class Sorter : ISorter
    {
        IList<T> ISorter.Sort<T>(IList<T> collection)
        {
            return SortAlgorithm(collection, (p, c) => p.CompareTo(c));
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, IComparer<T> comparer)
        {
            return SortAlgorithm(collection, (p, c) => comparer.Compare(p, c));
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, Comparison<T> comparison)
        {
            return SortAlgorithm(collection, (p, c) => comparison.Invoke(p, c));
        }

        private protected abstract IList<T> SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison);
    }
}
