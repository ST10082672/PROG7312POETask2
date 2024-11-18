using PROG7312POETask2.DataStructures; // Importing DataStructures namespace for interface IDataStructure
using System; // Importing System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and IEnumerable
using System.Linq; // Importing for LINQ functionality
using System.Text; // Importing for text encoding utilities
using System.Threading.Tasks; // Importing for task-based asynchronous programming

namespace PROG7312POETask2.Models
{
    // BinarySearchTreeNode class represents a node in the binary search tree
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public T Value; // Value stored in the node
        public BinarySearchTreeNode<T> Left; // Left child node
        public BinarySearchTreeNode<T> Right; // Right child node

        // Constructor to initialize the node with a given value
        public BinarySearchTreeNode(T value)
        {
            Value = value;
            Left = null; // Initially, no left child
            Right = null; // Initially, no right child
        }
    }

    // BinarySearchTree class implements IDataStructure interface for binary search tree operations
    public class BinarySearchTree<T> : IDataStructure<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> root; // Root node of the binary search tree

        // Insert method for IDataStructure interface
        public void Insert(T value)
        {
            root = InsertRec(root, value); // Start the recursive insertion
        }

        // Helper method for recursive insertion
        private BinarySearchTreeNode<T> InsertRec(BinarySearchTreeNode<T> node, T value)
        {
            if (node == null)
            {
                return new BinarySearchTreeNode<T>(value); // Insert new node if current node is null
            }

            // Compare the value to be inserted with the current node's value
            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = InsertRec(node.Left, value); // Insert in the left subtree if value is smaller
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = InsertRec(node.Right, value); // Insert in the right subtree if value is larger
            }

            return node; // Return the current node after insertion
        }

        // Search method for IDataStructure interface
        public T Search(T value)
        {
            var node = SearchRec(root, value); // Start recursive search
            return node != null ? node.Value : default(T); // Return the value if found, else return default
        }

        // Helper method for recursive search
        private BinarySearchTreeNode<T> SearchRec(BinarySearchTreeNode<T> node, T value)
        {
            if (node == null)
            {
                return null; // Return null if the value is not found
            }

            // Compare the value with the current node's value using CompareTo
            int comparison = value.CompareTo(node.Value);
            if (comparison == 0)
            {
                return node; // Return the node if the value matches
            }
            else if (comparison < 0)
            {
                return SearchRec(node.Left, value); // Search in the left subtree if value is smaller
            }
            else
            {
                return SearchRec(node.Right, value); // Search in the right subtree if value is larger
            }
        }

        // GetAll method for IDataStructure interface to retrieve all values in the tree
        public IEnumerable<T> GetAll()
        {
            var items = new List<T>(); // List to hold all items
            InOrderTraversal(root, items); // Perform an in-order traversal to get the items
            return items; // Return the list of items
        }

        // Helper method to perform in-order traversal (left, root, right)
        private void InOrderTraversal(BinarySearchTreeNode<T> node, List<T> items)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, items); // Traverse left subtree
                items.Add(node.Value); // Add the current node's value to the list
                InOrderTraversal(node.Right, items); // Traverse right subtree
            }
        }

        // Clear method for IDataStructure interface to reset the tree
        public void Clear()
        {
            root = null; // Set root to null to clear the tree
        }
    }
}

