using Algorithmic.Analysis;
using System;
using System.Collections.Generic;

namespace Algorithmic.Sorting
{
    internal class BinaryHeapSort : Sorter
    {
        public override string Name => "Binary Heap Sort";
        public override Complexity MemoryUsage => throw new NotImplementedException();
        public override Complexity BestComplexity => throw new NotImplementedException();
        public override Complexity AverageComplexity => throw new NotImplementedException();
        public override Complexity WorstComplexity => throw new NotImplementedException();
        public override bool isRecursive => false;
        public override bool isStable => false;
        public override bool isSerial => true;
        public override bool isAdaptive => false;

        private protected override string GetDescription()
        {
            return
                "Sort an array in two steps. First building the array into a complete binary tree. " +
                "Then repatedly swap the root and highest unsorted index and update the array to maintain the heap";
        }

        private protected override void SortAlgorithm<T>(IList<T> collection, Comparison<T> comparison)
        {
            // Order the array into a complete binary tree.
            BuildHeap(collection, comparison);

            var SortedIndex = collection.Count - 1;
            while (SortedIndex > 0)
            {
                // Swap sorted index element with index 0.
                var temp = collection[SortedIndex];
                collection[SortedIndex] = collection[0];
                collection[0] = temp;

                SortedIndex--;

                // Maintain the heap.
                SiftDown(collection, 0, SortedIndex, comparison);
            }
        }

        /// <summary>
        /// Build an unordered array into a complete binary tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="comparison">Comparison delegate.</param>
        private void BuildHeap<T>(IList<T> collection, Comparison<T> comparison)
        {
            var maxIndex = collection.Count - 1;

            for (int i = maxIndex; i >= 0; i--)
            {
                SiftDown(collection, i, maxIndex, comparison);
            }
        }

        /// <summary>
        /// Maintain heap order from start to end index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="low">Low index to maintain.</param>
        /// <param name="high">High index to maintain.</param>
        /// <param name="comparison">Comparison delegate.</param>
        private void SiftDown<T>(IList<T> collection, int low, int high, Comparison<T> comparison)
        {
            var parent = low;

            while (GetLeftChild(parent) <= high)
            {
                var leftChild = GetLeftChild(parent);
                var rightChild = leftChild + 1;
                var swap = parent;

                // Compare left child against parent.
                if (comparison.Invoke(collection[swap], collection[leftChild]) < 0)
                {
                    swap = leftChild;
                }

                // Compare right child against parent || left child.
                if (rightChild <= high && comparison.Invoke(collection[swap], collection[rightChild]) < 0)
                {
                    swap = rightChild;
                }

                // If parent holds highest of family, heap is maintained.
                if (swap == parent)
                {
                    return;
                }

                // Swap elements.
                var temp = collection[parent];
                collection[parent] = collection[swap];
                collection[swap] = temp;

                parent = swap;
            }
        }

        /// <summary>
        /// Return the left child of a complete binary tree index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetLeftChild(int index)
        {
            return index * 2 + 1;
        }
    }
}
