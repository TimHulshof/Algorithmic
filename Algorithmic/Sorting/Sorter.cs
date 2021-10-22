using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Sorting
{
    public abstract class Sorter : ISorter
    {
        public AlgorithmType AlgorithmType => AlgorithmType.Sorting;
        public abstract string Name { get; }
        public string Description => GetDescription();
        public abstract Complexity MemoryUsage { get; }
        public abstract Complexity BestComplexity { get; }
        public abstract Complexity AverageComplexity { get; }
        public abstract Complexity WorstComplexity { get; }
        public abstract bool isRecursive { get; }
        public abstract bool isStable { get; }
        public abstract bool isSerial { get; }
        public abstract bool isAdaptive { get; }

        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            CheckCollection(collection, (p, c) => p.CompareTo(c));
        }

        public void Sort<T>(IList<T> collection, IComparer<T> comparer)
        {
            CheckCollection(collection, (p, c) => comparer.Compare(p, c));
        }

        public void Sort<T>(IList<T> collection, Comparison<T> comparison)
        {
            CheckCollection(collection, comparison);
        }

        private void CheckCollection<T>(IList<T> collection, Comparison<T> comparison)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            // Collection is already sorted (less then two elements).
            if (collection.Count <= 1)
            {
                return;
            }

            SortAlgorithm(collection, comparison);
        }

        private protected abstract string GetDescription();
        private protected abstract void SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison);
    }
}
