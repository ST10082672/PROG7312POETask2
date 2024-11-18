using System; // Importing the System namespace for common .NET functionality

namespace PROG7312POETask2.Models
{
    // ServiceRequest class implements IComparable interface for comparing ServiceRequest objects
    public class ServiceRequest : IComparable<ServiceRequest>
    {
        // Using Guid to generate unique identifiers for each service request
        public Guid Id { get; set; } // Unique identifier for the service request
        public string RequestType { get; set; } // Type of service request (e.g., "Technical", "Billing")
        public string Status { get; set; } // Status of the service request (e.g., "Open", "Closed")
        public string Category { get; set; } // Category of the request (e.g., "Hardware", "Software")
        public string Description { get; set; } // Detailed description of the service request
        public int Priority { get; set; } // Priority of the service request (e.g., 1 for high priority)

        // Constructor to initialize a service request with all its properties
        public ServiceRequest(Guid id, string status, string requestType, string description, int priority)
        {
            Id = id; // Initialize the unique identifier
            Status = status; // Initialize the status of the request
            RequestType = requestType; // Initialize the request type
            Description = description; // Initialize the description of the request
            Priority = priority; // Initialize the priority level of the request
        }

        // Method to compare two ServiceRequest objects by their Ids
        public int CompareTo(ServiceRequest other)
        {
            if (other == null) return 1; // If the other object is null, consider this object greater
            return this.Id.CompareTo(other.Id); // Compare by Id, which is a unique identifier
        }
    }
}

