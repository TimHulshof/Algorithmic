using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal interface ISorter
    {
        internal IList<T> Sort<T>(IList<T> collection) where T : IComparable<T>;
        internal IList<T> Sort<T>(IList<T> collection, IComparer<T>? comparer);
        internal IList<T> Sort<T>(IList<T> collection, Comparison<T> comparison);
    }
}
