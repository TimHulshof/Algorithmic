using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    public interface ISorter : IDescriptive, ITimeComplexity, IMemoryComplexity
    {
        public bool isRecursive { get; }
        public bool isStable { get; }
        public bool isSerial { get; }
        public bool isAdaptive { get; }

        internal void Sort<T>(IList<T> collection) where T : IComparable<T>;
        internal void Sort<T>(IList<T> collection, IComparer<T>? comparer);
        internal void Sort<T>(IList<T> collection, Comparison<T> comparison);
    }
}
