using PROG7312POETask2.DataStructures; // Importing the DataStructures namespace for using custom data structures
using PROG7312POETask2.Models; // Importing the Models namespace for ServiceRequest class
using System; // Importing System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and IDictionary
using System.ComponentModel; // Importing for Windows Forms components
using System.Data; // Importing for working with data
using System.Drawing; // Importing for drawing and working with graphics
using System.Linq; // Importing for LINQ functionality
using System.Text; // Importing for text encoding utilities
using System.Threading.Tasks; // Importing for task-based asynchronous programming
using System.Windows.Forms; // Importing for Windows Forms UI controls

namespace PROG7312POETask2
{
    // PROG7312POE form handles the main user interface for the service request and local events system
    public partial class PROG7312POE : Form
    {
        // Define the serviceRequests field to manage the service requests
        private IDataStructure<ServiceRequest> serviceRequests; // This will hold the service requests in a data structure

        // Constructor for initializing the form and the data structure for service requests
        public PROG7312POE()
        {
            InitializeComponent(); // Initialize the form components (buttons, labels, etc.)

            // Initialize the data structure (using a Binary Search Tree as the default implementation)
            serviceRequests = new BinarySearchTree<ServiceRequest>();

            // Enable buttons on the form to allow user interaction
            btnLocalEvents.Enabled = true;
            btnServiceRequestStatus.Enabled = true;
        }

        // Event handler for the "Report Issues" button click
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            frmReportIssues frmReportIssues = new frmReportIssues(); // Create an instance of the Report Issues form

            // Show the Report Issues form and check if the user clicked "OK"
            if (frmReportIssues.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the issue details entered in the frmReportIssues form
                int issueId = frmReportIssues.IssueId;
                string issueDescription = frmReportIssues.Description;
                string issueStatus = frmReportIssues.Status;
                string issueLocation = frmReportIssues.IssueLocation;
                string category = frmReportIssues.Category;

                // Create a new ServiceRequest object with the provided details
                ServiceRequest newIssueRequest = new ServiceRequest(Guid.NewGuid(), issueStatus, category, issueDescription, 0); // Set priority (0 for now)

                // Insert the new service request into the data structure
                serviceRequests.Insert(newIssueRequest);
            }
        }

        // Event handler for the "Local Events" button click
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            // Create and show the Local Events and Announcements form
            frmLocalEventsandAnnouncements frmLocalEventsAndAnnounce = new frmLocalEventsandAnnouncements();
            frmLocalEventsAndAnnounce.ShowDialog(); // Show the form as a modal dialog
        }

        // Event handler for the "Service Request Status" button click
        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            // Create and show the Service Request Status form, passing the service requests data structure to it
            frmServiceRequestStatus serviceRequestStatusForm = new frmServiceRequestStatus(serviceRequests);
            serviceRequestStatusForm.ShowDialog(); // Show the form as a modal dialog
        }
    }
}
