using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    public interface ISorter
    {
        internal void Sort<T>(IList<T> collection) where T : IComparable<T>;
        internal void Sort<T>(IList<T> collection, IComparer<T>? comparer);
        internal void Sort<T>(IList<T> collection, Comparison<T> comparison);
    }
}
