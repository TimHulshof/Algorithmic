using System;
using System.Collections.Generic;

namespace Algorithmic.Array
{
    internal interface ISorter
    {
        internal delegate bool LambdaComparer<T>(T previous, T current);

        internal IList<T> Sort<T>(IList<T> collection) where T : IComparable<T>;
        internal IList<T> Sort<T>(IList<T> collection, Comparison<T> comparison);
        internal IList<T> Sort<T>(IList<T> collection, IComparer<T>? comparer);
        internal IList<T> Sort<T>(IList<T> collection, LambdaComparer<T> comparer);

    }
}
