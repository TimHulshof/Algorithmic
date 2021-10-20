using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Array.Sort
{
    public interface ISorter : IAlgorithm, ITimeComplexity, IMemoryComplexity
    {
        public bool isRecursive { get; }
        public bool isStable { get; }
        public bool isSerial { get; }
        public bool isAdaptive { get; }

        public void Sort<T>(IList<T> collection) where T : IComparable<T>;
        public void Sort<T>(IList<T> collection, IComparer<T>? comparer);
        public void Sort<T>(IList<T> collection, Comparison<T> comparison);
    }
}
