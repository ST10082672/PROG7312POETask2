using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312POETask2.DataStructures
{
    public class Graph
    {
        // Dictionary to store the adjacency list (graph structure)
        private Dictionary<int, List<Edge>> adjacencyList;

        // Constructor to initialize the adjacency list
        public Graph()
        {
            adjacencyList = new Dictionary<int, List<Edge>>();
        }

        // Method to add a vertex to the graph
        public void AddVertex(int id)
        {
            // Check if the vertex already exists in the adjacency list
            if (!adjacencyList.ContainsKey(id))
                adjacencyList[id] = new List<Edge>();
        }

        // Method to add an edge between two vertices
        public void AddEdge(int from, int to, int weight = 1)
        {
            // Check if both vertices exist in the graph
            if (adjacencyList.ContainsKey(from) && adjacencyList.ContainsKey(to))
                adjacencyList[from].Add(new Edge(to, weight)); // Add edge with weight to the adjacency list
        }

        // Method to get neighbors of a specific vertex
        public List<Edge> GetNeighbors(int id)
        {
            // Return the neighbors of the vertex if it exists, otherwise an empty list
            return adjacencyList.ContainsKey(id) ? adjacencyList[id] : new List<Edge>();
        }

        // BFS Traversal: Breadth-first search algorithm
        public void BFS(int start)
        {
            Queue<int> queue = new Queue<int>(); // Queue to manage the BFS traversal
            HashSet<int> visited = new HashSet<int>(); // Set to track visited vertices

            queue.Enqueue(start); // Enqueue the starting vertex
            visited.Add(start); // Mark the starting vertex as visited

            // Traverse while the queue is not empty
            while (queue.Count > 0)
            {
                int current = queue.Dequeue(); // Dequeue the current vertex
                Console.WriteLine("Processing Service Request: " + current); // Process the vertex

                // Loop through all neighbors of the current vertex
                foreach (var neighbor in GetNeighbors(current))
                {
                    // If the neighbor is not visited, enqueue it and mark it as visited
                    if (!visited.Contains(neighbor.To))
                    {
                        queue.Enqueue(neighbor.To);
                        visited.Add(neighbor.To);
                    }
                }
            }
        }

        // DFS Traversal: Depth-first search algorithm
        public void DFS(int start)
        {
            Stack<int> stack = new Stack<int>(); // Stack to manage the DFS traversal
            HashSet<int> visited = new HashSet<int>(); // Set to track visited vertices

            stack.Push(start); // Push the starting vertex onto the stack

            // Traverse while the stack is not empty
            while (stack.Count > 0)
            {
                int current = stack.Pop(); // Pop the current vertex from the stack

                // If the current vertex hasn't been visited, process it
                if (!visited.Contains(current))
                {
                    visited.Add(current); // Mark the vertex as visited
                    Console.WriteLine("Processing Service Request: " + current); // Process the vertex

                    // Loop through all neighbors of the current vertex
                    foreach (var neighbor in GetNeighbors(current))
                    {
                        // If the neighbor is not visited, push it onto the stack
                        if (!visited.Contains(neighbor.To))
                        {
                            stack.Push(neighbor.To);
                        }
                    }
                }
            }
        }

        // Prim's MST Algorithm: Finds the Minimum Spanning Tree (MST)
        public void PrimMST(int start)
        {
            var mstSet = new HashSet<int>(); // Set to track vertices in the MST
            var priorityQueue = new SortedSet<Edge>(); // Priority queue to select the minimum weight edge

            mstSet.Add(start); // Add the starting vertex to the MST

            // Add all neighbors of the starting vertex to the priority queue
            foreach (var neighbor in GetNeighbors(start))
            {
                priorityQueue.Add(neighbor);
            }

            // Loop until the MST includes all vertices in the graph
            while (mstSet.Count < adjacencyList.Keys.Count)
            {
                if (priorityQueue.Count == 0)
                    throw new InvalidOperationException("Graph is not fully connected.");

                Edge minEdge = priorityQueue.First(); // Get the minimum weight edge
                priorityQueue.Remove(minEdge); // Remove the edge from the priority queue

                // If the destination vertex of the edge is not in the MST, add it
                if (!mstSet.Contains(minEdge.To))
                {
                    Console.WriteLine($"Connecting Service Request {minEdge.From} to {minEdge.To} with weight {minEdge.Weight}"); // Process the edge
                    mstSet.Add(minEdge.To); // Add the destination vertex to the MST

                    // Add all neighbors of the new vertex to the priority queue
                    foreach (var neighbor in GetNeighbors(minEdge.To))
                    {
                        if (!mstSet.Contains(neighbor.To))
                            priorityQueue.Add(neighbor);
                    }
                }
            }
        }

        // Nested class to represent edges in the graph
        public class Edge : IComparable<Edge>
        {
            public int From { get; set; } // Starting vertex of the edge
            public int To { get; set; } // Ending vertex of the edge
            public int Weight { get; set; } // Weight of the edge

            // Constructor to create an edge with a destination and weight
            public Edge(int to, int weight)
            {
                To = to;
                Weight = weight;
            }

            // Constructor to create an edge with a source, destination, and weight
            public Edge(int from, int to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }

            // Compare two edges by their weight
            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }
    }
}
