using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    internal interface ISorter
    {
        /// <summary>
        /// Predicate to compare two elements on an array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lower">Element on "lower" end of array.</param>
        /// <param name="higher">Element on "higher" end of array.</param>
        /// <returns>True if elements are ordered lower to higher.</returns>
        internal delegate bool ElementComparer<T>(T lower, T higher);

        internal IList<T> Sort<T>(IList<T> collection) where T : IComparable<T>;
        internal IList<T> Sort<T>(IList<T> collection, Comparison<T> comparison);
        internal IList<T> Sort<T>(IList<T> collection, IComparer<T>? comparer);
        internal IList<T> Sort<T>(IList<T> collection, ElementComparer<T> comparer);

    }
}
