using PROG7312POETask2.DataStructures; // Importing the DataStructures namespace for custom data structures
using System; // Importing System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and Dictionary
using System.Windows.Forms; // Importing for Windows Forms UI controls
using System.Linq; // Importing for LINQ functionality
using PROG7312POETask2.Models;

namespace PROG7312POETask2
{
    // frmServiceRequestStatus class handles the display and management of service request statuses
    public partial class frmServiceRequestStatus : Form
    {
        private IDataStructure<ServiceRequest> serviceRequests; // The data structure holding service requests

        // Constructor for initializing the form, setting up the service requests data structure, and populating the UI components
        public frmServiceRequestStatus(IDataStructure<ServiceRequest> existingServiceRequests)
        {
            InitializeComponent(); // Initialize form components (buttons, labels, etc.)
            serviceRequests = new BinarySearchTree<ServiceRequest>(); // Initialize service requests using Binary Search Tree
            PopulateComboBox(); // Populate the data structure selection combo box
            InitializeSampleData(); // Load sample service request data
            UpdateRequestList(); // Update the service request list view
            UpdateChart("Status"); // Update the chart based on "Status" category
        }

        // Updates the service request list view in the DataGridView
        private void UpdateRequestList()
        {
            try
            {
                dgvServiceRequests.Rows.Clear(); // Clear the existing rows in the DataGridView
                foreach (var request in serviceRequests.GetAll()) // Loop through all service requests
                {
                    // Add each service request to the DataGridView
                    dgvServiceRequests.Rows.Add(request.Id, request.Status, request.Description, request.Priority, request.RequestType);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if there is an issue updating the list
                MessageBox.Show("Error updating request list: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Populates the chart category dropdown (Status and Priority)
        private void PopulateChartCategoryDropdown()
        {
            cbFilterBox.Items.Add("Status"); // Add "Status" to the dropdown
            cbFilterBox.Items.Add("Priority"); // Add "Priority" to the dropdown
            cbFilterBox.SelectedIndex = 0; // Set the default selection to "Status"
            cbFilterBox.SelectedIndexChanged += cbFilterBox_SelectedIndexChanged; // Event handler for dropdown selection change
        }

        // Populates the data structure selection combo box (Binary Search Tree, AVL Tree, MinHeap)
        private void PopulateComboBox()
        {
            cmbDataStructure.Items.Add("Binary Search Tree (BST)"); // Add BST option
            cmbDataStructure.Items.Add("AVL Tree"); // Add AVL Tree option
            cmbDataStructure.Items.Add("MinHeap"); // Add MinHeap option
            cmbDataStructure.SelectedIndex = 0; // Set the default selection to Binary Search Tree
        }

        // Handles the event when the data structure selection changes in the combo box
        private void cmbDataStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serviceRequests == null)
            {
                // Display error message if service requests data structure is not initialized
                MessageBox.Show("Service requests data structure is not initialized.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save current data before changing the data structure
            var currentData = serviceRequests.GetAll();
            switch (cmbDataStructure.SelectedItem.ToString()) // Check the selected data structure
            {
                case "Binary Search Tree (BST)":
                    serviceRequests = new BinarySearchTree<ServiceRequest>(); // Initialize BST
                    break;
                case "AVL Tree":
                    serviceRequests = new AVLTree<ServiceRequest>(); // Initialize AVL Tree
                    break;
                case "MinHeap":
                    serviceRequests = new MinHeap<ServiceRequest>((x, y) => x.Priority.CompareTo(y.Priority)); // Initialize MinHeap with custom comparison based on priority
                    break;
                default:
                    serviceRequests = new BinarySearchTree<ServiceRequest>(); // Default to BST
                    break;
            }

            // Reinsert all previously added service requests into the new data structure
            foreach (var request in currentData)
            {
                serviceRequests.Insert(request); // Insert the existing request into the new data structure
            }

            UpdateRequestList(); // Update the request list view after the data structure change
        }

        // Event handler for the "Search" button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate if the entered Service Request ID is a valid numeric value
                if (!int.TryParse(txtSearchId.Text, out int requestId))
                {
                    MessageBox.Show("Please enter a valid numeric value for the Service Request ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Search for the service request with the given ID
                var request = serviceRequests.Search(new ServiceRequest(Guid.Empty, string.Empty, string.Empty, string.Empty, requestId));

                if (request != null)
                {
                    // Display the details of the found service request
                    MessageBox.Show($"Request ID: {request.Id}, Status: {request.Status}, Request Type: {request.RequestType}, Description: {request.Description}, Priority: {request.Priority}", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Display error if the service request ID is not found
                    MessageBox.Show("Service Request ID not found. Please enter a valid ID from the list.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Display error message if an unexpected error occurs
                MessageBox.Show("Error searching for request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for text changes in the search input field
        private void txtSearchId_TextChanged(object sender, EventArgs e)
        {
            // Handle the text changed event logic here (e.g., enable the Search button or provide live feedback)
        }

        // Event handler for DataGridView cell clicks (could be used for viewing detailed request info)
        private void dgvServiceRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event (e.g., show detailed view of the selected request)
            MessageBox.Show("Cell clicked!");
        }

        // Method to initialize sample data for service requests (for demonstration purposes)
        private void InitializeSampleData()
        {
            var sampleRequests = new List<ServiceRequest>
                {
                    new ServiceRequest(Guid.NewGuid(), "Open", "Issue", "Internet connection issue.", 3),
                    new ServiceRequest(Guid.NewGuid(), "In Progress", "Maintenance", "Scheduled maintenance for server.", 2),
                    new ServiceRequest(Guid.NewGuid(), "Closed", "Event", "Annual company meeting.", 1),
                    new ServiceRequest(Guid.NewGuid(), "Open", "Issue", "Printer not working.", 5),
                    new ServiceRequest(Guid.NewGuid(), "Resolved", "Support", "Software installation completed.", 4),
                    new ServiceRequest(Guid.NewGuid(), "Pending", "Update", "Pending approval for project proposal.", 6)
                };

            // Add sample requests to the data structure
            foreach (var request in sampleRequests)
            {
                AddServiceRequest(request);
            }
        }

        // Method to add a service request to the data structure
        public void AddServiceRequest(ServiceRequest newRequest)
        {
            // Check if the service request already exists, and generate a new ID if necessary
            var existingRequest = serviceRequests.Search(new ServiceRequest(newRequest.Id, string.Empty, string.Empty, string.Empty, 0));
            if (existingRequest != null)
            {
                newRequest.Id = Guid.NewGuid(); // Generate a new ID if the request already exists
            }

            // Insert the service request into the data structure
            serviceRequests.Insert(newRequest);
        }

        /// <summary>
        /// Method that updates the chart based on the selected category (Status or Priority)
        /// </summary>
        /// <param name="category">The category (Status or Priority) for chart display</param>
        private void UpdateChart(string category)
        {
            // Clear existing points on the chart
            ServiceRequestChart.Series[0].Points.Clear();

            // Update chart based on selected category
            if (category == "Status")
            {
                // Group by request status and count occurrences
                var statusCounts = serviceRequests.GetAll()
                    .GroupBy(req => req.Status)
                    .Select(group => new { Status = group.Key, Count = group.Count() });

                // Add data to the chart for "Status"
                foreach (var status in statusCounts)
                {
                    ServiceRequestChart.Series[0].Points.AddXY(status.Status, status.Count);
                }
            }
            else if (category == "Priority")
            {
                // Group by priority and count occurrences
                var priorityCounts = serviceRequests.GetAll()
                    .GroupBy(req => req.Priority)
                    .Select(group => new { Priority = group.Key, Count = group.Count() });

                // Add data to the chart for "Priority"
                foreach (var priority in priorityCounts)
                {
                    ServiceRequestChart.Series[0].Points.AddXY($"Priority {priority.Priority}", priority.Count);
                }
            }
        }

        /// <summary>
        /// Sorts the chart by the selected category (Status or Priority)
        /// </summary>
        private void cbFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbFilterBox.SelectedItem.ToString(); // Get the selected category
            UpdateChart(selectedCategory); // Update the chart with the selected category
        }

        /// <summary>
        /// Changes the chart type to a line graph when the corresponding button is checked
        /// </summary>
        private void btnLineGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (btnLineGraph.Checked)
            {
                // Change chart type to Line
                ServiceRequestChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
        }

        /// <summary>
        /// Changes the chart type to a bar graph when the corresponding button is checked
        /// </summary>
        private void btnBarGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (btnBarGraph.Checked)
            {
                // Change chart type to Column (Bar)
                ServiceRequestChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        /// <summary>
        /// Changes the chart type to a point chart when the corresponding button is checked
        /// </summary>
        private void btnPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (btnPoint.Checked)
            {
                // Change chart type to Point
                ServiceRequestChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
        }
    }
}
