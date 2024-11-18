using PROG7312POETask2.Models; // Importing Models namespace for data models
using System; // Importing the System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and IEnumerable

namespace PROG7312POETask2.DataStructures
{
    // MinHeap class implements IDataStructure with a generic type T where T must be comparable
    public class MinHeap<T> : IDataStructure<T> where T : IComparable<T>
    {
        private List<T> heap; // List to hold the elements of the heap
        private readonly Comparison<T> comparison; // Custom comparison function for prioritization

        // Constructor to accept a custom comparison function for prioritization
        // If no comparison function is provided, the default comparison is used
        public MinHeap(Comparison<T> comparison = null)
        {
            heap = new List<T>(); // Initialize the heap list
            this.comparison = comparison ?? Comparer<T>.Default.Compare; // Use provided comparison or default
        }

        // Insert method for IDataStructure interface
        public void Insert(T item)
        {
            heap.Add(item); // Add the item to the heap
            HeapifyUp(heap.Count - 1); // Restore the heap property by moving the item up
        }

        // Search method for IDataStructure interface
        public T Search(T item)
        {
            // Perform a linear search, as heaps are not sorted in a predictable order
            foreach (var element in heap)
            {
                if (element.CompareTo(item) == 0) // Check if the element matches the search item
                    return element; // Return the found element
            }
            return default(T); // Return the default value if the item is not found
        }

        // GetAll method for IDataStructure interface
        public IEnumerable<T> GetAll()
        {
            return new List<T>(heap); // Return a new list with all elements of the heap
        }

        // Clear method for IDataStructure interface
        public void Clear()
        {
            heap.Clear(); // Clear the heap list
        }

        // ExtractMin method to remove and return the minimum element in the heap
        public T ExtractMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty"); // Throw an exception if the heap is empty

            T min = heap[0]; // The minimum element is always at the root of the heap
            heap[0] = heap[heap.Count - 1]; // To Replace the root with the last element
            heap.RemoveAt(heap.Count - 1); // to Remove the last element
            HeapifyDown(0); // to Restore the heap property by moving the new root down
            return min; // to Return the minimum element
        }

        // HeapifyUp method to restore the heap property after inserting an element
        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2; // Calculate the parent index of the current index

            if (index > 0 && comparison(heap[index], heap[parentIndex]) < 0)
            {
                Swap(index, parentIndex); // Swap the current element with its parent if the current element is smaller
                HeapifyUp(parentIndex); // Recursively move the element up the heap
            }
        }

        // HeapifyDown method to restore the heap property after extracting the minimum element
        private void HeapifyDown(int index)
        {
            int smallest = index; // Start with the current element as the smallest
            int left = 2 * index + 1; // Left child index
            int right = 2 * index + 2; // Right child index

            // Check if the left child exists and is smaller than the current smallest
            if (left < heap.Count && comparison(heap[left], heap[smallest]) < 0)
                smallest = left;

            // Check if the right child exists and is smaller than the current smallest
            if (right < heap.Count && comparison(heap[right], heap[smallest]) < 0)
                smallest = right;

            // If the smallest is not the current index, swap and continue heapifying down
            if (smallest != index)
            {
                Swap(index, smallest); // Swap the current element with the smallest child
                HeapifyDown(smallest); // Recursively move the element down the heap
            }
        }

        // Swap method to exchange two elements in the heap
        private void Swap(int i, int j)
        {
            T temp = heap[i]; // Store the element at index i
            heap[i] = heap[j]; // Swap the elements at index i and j
            heap[j] = temp; // Assign the stored element to index j
        }

        // IsEmpty method to check if the heap is empty
        public bool IsEmpty()
        {
            return heap.Count == 0; // Return true if the heap is empty
        }
    }
}
