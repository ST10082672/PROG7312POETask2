using PROG7312POETask2.Models; // Importing Models namespace for data models
using PROG7312POETask2.DataStructures; // Importing DataStructures namespace for interface IDataStructure
using System; // Importing System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and IEnumerable

namespace PROG7312POETask2.DataStructures
{
    // RedBlackTree class implements IDataStructure interface for a simplified version of a red-black tree
    public class RedBlackTree<T> : IDataStructure<T> where T : IComparable<T>
    {

        // RBNode class represents a node in the red-black tree
        private class RBNode
        {
            public T Data; // The data stored in the node
            public RBNode Left; // Left child node
            public RBNode Right; // Right child node

            // Constructor to initialize the node with a data value
            public RBNode(T data)
            {
                Data = data;
            }
        }

        private RBNode root; // Root node of the red-black tree

        // Insert method for IDataStructure interface to insert an item into the tree
        public void Insert(T item)
        {
            root = InsertRec(root, item); // Start the recursive insertion process
        }

        // Recursive helper method for insertion
        private RBNode InsertRec(RBNode root, T item)
        {
            if (root == null)
            {
                return new RBNode(item); // Insert a new node if current root is null
            }

            // Compare the item with the current node's data and insert it in the left or right subtree
            if (item.CompareTo(root.Data) < 0)
                root.Left = InsertRec(root.Left, item); // Insert into left subtree if the item is smaller
            else if (item.CompareTo(root.Data) > 0)
                root.Right = InsertRec(root.Right, item); // Insert into right subtree if the item is larger

            return root; // Return the root node after insertion
        }

        // Search method for IDataStructure interface to search for an item in the tree
        public T Search(T item)
        {
            return SearchRec(root, item); // Start the recursive search process
        }

        // Recursive helper method for searching
        private T SearchRec(RBNode root, T item)
        {
            if (root == null || root.Data.CompareTo(item) == 0)
                return root != null ? root.Data : default; // Return the data if the item is found or return default

            // Compare the item with the current node's data and search in the left or right subtree
            if (item.CompareTo(root.Data) < 0)
                return SearchRec(root.Left, item); // Search in the left subtree if the item is smaller

            return SearchRec(root.Right, item); // Search in the right subtree if the item is larger
        }

        // GetAll method for IDataStructure interface to retrieve all values in the tree
        public IEnumerable<T> GetAll()
        {
            var items = new List<T>(); // List to hold all items
            InOrderTraversal(root, items); // Perform an in-order traversal to get the items
            return items; // Return the list of items
        }

        // Helper method to perform in-order traversal (left, root, right) and collect the values
        private void InOrderTraversal(RBNode node, List<T> items)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, items); // Traverse left subtree
                items.Add(node.Data); // Add the current node's data to the list
                InOrderTraversal(node.Right, items); // Traverse right subtree
            }
        }

        // Clear method for IDataStructure interface to reset the tree
        public void Clear()
        {
            root = null; // Set the root to null to clear the tree
        }
    }
}
