using PROG7312POETask2.Models; // Importing Models namespace for data models
using PROG7312POETask2.DataStructures; // Importing DataStructures namespace for graph-related operations
using System; // Importing the System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and IEnumerable
using System.Linq; // Importing for LINQ functionality
using System.Text; // Importing for text encoding utilities
using System.Threading.Tasks; // Importing for task-based asynchronous programming

namespace PROG7312POETask2.DataStructures
{
    // Interface to define the structure of data storage operations
    public interface IDataStructure<T>
    {
        // Method to insert an item into the data structure
        void Insert(T item);

        // Method to retrieve all items from the data structure
        IEnumerable<T> GetAll();

        // Method to clear the data structure
        void Clear();

        // Method to search for a specific item in the data structure
        T Search(T item);
    }
}



