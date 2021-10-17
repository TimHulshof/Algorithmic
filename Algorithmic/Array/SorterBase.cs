using System;
using System.Collections.Generic;

namespace Algorithmic.Array
{
    internal abstract class SorterBase : ISorter
    {
        IList<T> ISorter.Sort<T>(IList<T> collection)
        {
            return SortAlgorithm(collection, (p, c) => p.CompareTo(c) > 0) ;
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, Comparison<T> comparison)
        {
            return SortAlgorithm(collection, (p, c) => comparison.Invoke(p, c) > 0);
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, IComparer<T> comparer)
        {
            return SortAlgorithm(collection, (p, c) => comparer.Compare(p, c) > 0);
        }

        IList<T> ISorter.Sort<T>(IList<T> collection, ISorter.LambdaComparer<T> comparer)
        {
            return SortAlgorithm(collection, comparer);
        }

        private protected abstract IList<T> SortAlgorithm<T>(IList<T> collection, ISorter.LambdaComparer<T> comparer);
    }
}
