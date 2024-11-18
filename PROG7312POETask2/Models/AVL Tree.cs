using PROG7312POETask2.Models;
using PROG7312POETask2.DataStructures;
using System;
using System.Collections.Generic;

namespace PROG7312POETask2.DataStructures
{
    public class AVLTree<T> : IDataStructure<T> where T : IComparable<T>
    {
        // Define TreeNode class for AVL Tree logic
        private class TreeNode
        {
            public T Data;
            public TreeNode Left;
            public TreeNode Right;
            public int Height;

            public TreeNode(T data)
            {
                Data = data;
                Left = Right = null;
                Height = 1;  // Height starts at 1 because a new node is a leaf.
            }
        }

        private TreeNode root;

        // Public method to insert an item into the AVL Tree
        public void Insert(T item)
        {
            root = InsertRecursive(root, item);
        }

        // Private recursive method to insert an item and maintain AVL properties
        private TreeNode InsertRecursive(TreeNode node, T item)
        {
            if (node == null)
                return new TreeNode(item);

            // Insertion logic: compare item and move left or right
            if (item.CompareTo(node.Data) < 0)
                node.Left = InsertRecursive(node.Left, item);
            else if (item.CompareTo(node.Data) > 0)
                node.Right = InsertRecursive(node.Right, item);
            else
                return node;  // Duplicate values are not allowed in this AVL tree

            // Update height of the current node
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            // Balance the node
            return Balance(node);
        }

        // Public method to search for an item in the AVL Tree
        public T Search(T item)
        {
            return SearchRecursive(root, item);
        }

        // Private recursive method to search for an item
        private T SearchRecursive(TreeNode node, T item)
        {
            if (node == null || node.Data.CompareTo(item) == 0)
                return node != null ? node.Data : default;

            if (item.CompareTo(node.Data) < 0)
                return SearchRecursive(node.Left, item);
            else
                return SearchRecursive(node.Right, item);
        }

        // Public method to get all items in sorted order (in-order traversal)
        public IEnumerable<T> GetAll()
        {
            List<T> items = new List<T>();
            InOrderTraversal(root, items);
            return items;
        }

        // Private recursive method for in-order traversal of the AVL Tree
        private void InOrderTraversal(TreeNode node, List<T> items)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, items);
                items.Add(node.Data);
                InOrderTraversal(node.Right, items);
            }
        }

        // Public method to clear the AVL Tree
        public void Clear()
        {
            root = null;
        }

        // Helper methods for balancing the tree

        // Get the height of a given node
        private int Height(TreeNode node)
        {
            return node == null ? 0 : node.Height;
        }

        // Calculate balance factor of a given node
        private int BalanceFactor(TreeNode node)
        {
            return node == null ? 0 : Height(node.Left) - Height(node.Right);
        }

        // Balance the AVL Tree node if unbalanced
        private TreeNode Balance(TreeNode node)
        {
            int balanceFactor = BalanceFactor(node);

            // Left heavy case
            if (balanceFactor > 1)
            {
                // Left-Right case
                if (BalanceFactor(node.Left) < 0)
                    node.Left = RotateLeft(node.Left);

                return RotateRight(node);
            }

            // Right heavy case
            if (balanceFactor < -1)
            {
                // Right-Left case
                if (BalanceFactor(node.Right) > 0)
                    node.Right = RotateRight(node.Right);

                return RotateLeft(node);
            }

            return node; // Node is already balanced
        }

        // Right rotation to balance a left-heavy tree
        private TreeNode RotateRight(TreeNode y)
        {
            TreeNode x = y.Left;
            TreeNode T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            // Return new root
            return x;
        }

        // Left rotation to balance a right-heavy tree
        private TreeNode RotateLeft(TreeNode x)
        {
            TreeNode y = x.Right;
            TreeNode T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            // Update heights
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            // Return new root
            return y;
        }
    }
}
