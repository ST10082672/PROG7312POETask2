using PROG7312POETask2; // Importing the main project namespace
using System; // Importing System namespace for common .NET functionality
using System.Collections.Generic; // Importing for collections like List
using System.ComponentModel; // Importing for Windows Forms components
using System.Data; // Importing for working with data
using System.Drawing; // Importing for working with graphics
using System.Linq; // Importing for LINQ functionality
using System.Text; // Importing for text encoding utilities
using System.Threading.Tasks; // Importing for task-based asynchronous programming
using System.Windows.Forms; // Importing for Windows Forms UI controls

namespace PROG7312POETask2
{
    // frmReportIssues class is the form where users can report issues, including description, location, category, and attachment
    public partial class frmReportIssues : Form
    {
        // List to store attached files for the issue report
        private List<string> attachedFiles = new List<string>();

        // Public properties to capture user inputs and make them accessible to other forms
        public int IssueId { get; private set; } // Unique identifier for the issue
        public string IssueLocation { get; private set; } // Location of the issue
        public string Description { get; private set; } // Description of the issue
        public string Status { get; private set; } // Status of the issue (e.g., "Pending")
        public string Category { get; private set; } // Category of the issue (e.g., "Electrical Issue")
        public List<string> AttachedFiles => attachedFiles; // Read-only list of attached files

        // Constructor to initialize the form and populate the category combo box
        public frmReportIssues()
        {
            InitializeComponent(); // Initialize form components (buttons, labels, etc.)
            cmbCategory.DataSource = PopulateComboBoxItems(); // Populate category dropdown with predefined items
        }

        // Event handler for submitting the issue report when the submit button is clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate the inputs before proceeding
                if (Validation()) { return; }

                // Set properties based on user inputs
                if (string.IsNullOrWhiteSpace(txtIssueId.Text))
                {
                    // Generate a unique ID if the user doesn't provide one
                    IssueId = GenerateUniqueIssueId();
                }
                else
                {
                    IssueId = int.Parse(txtIssueId.Text); // Use the user-entered Issue ID
                }

                // Set other properties based on form inputs
                IssueLocation = txtLocation.Text;
                Category = cmbCategory.SelectedItem.ToString();
                Description = rtbDescription.Text;
                Status = "Pending"; // Default status for newly reported issues

                // Display progress report to the user during submission
                ProgrssReport();

                // Show success message after successful issue reporting
                MessageBox.Show("Thank you! Your issue has been reported successfully.", "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form and return DialogResult as OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any errors and show error message
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to generate a unique issue ID (for simplicity, using the current millisecond value)
        private int GenerateUniqueIssueId()
        {
            return DateTime.Now.Millisecond; // Return millisecond value as a unique ID (replace with a more robust method if needed)
        }

        // Event handler for attaching media files to the report when the attach button is clicked
        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            try
            {
                // Open file dialog to allow user to select one or more files for attachment
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true; // Allow multiple file selection
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|Document Files|*.pdf;*.docx|All Files|*.*"; // Set file filter types

                    // If the user selects files, add them to the attached files list and display them
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string[] selectedFiles = openFileDialog.FileNames;
                        lblfileName.Text = "Attached Files: " + string.Join(", ", selectedFiles); // Display attached file names
                        foreach (string file in selectedFiles)
                        {
                            attachedFiles.Add(file); // Add each selected file to the attached files list
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during file attachment
                MessageBox.Show($"Error attaching media: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to populate the category combo box with predefined categories
        public List<string> PopulateComboBoxItems()
        {
            return new List<string>
            {
                "Sewage", // Category 1
                "Electrical Issue", // Category 2
                "Faulty Street lights", // Category 3
                "Illegal dumping sites" // Category 4
            };
        }

        // Asynchronous method to display a progress bar while submitting the issue
        private async void ProgrssReport()
        {
            progressBarEngagement.Visible = true; // Show the progress bar
            progressBarEngagement.Value = 0; // Reset progress bar value

            // Simulate progress in steps of 20% for user feedback
            for (int i = 0; i <= 100; i += 20)
            {
                progressBarEngagement.Value = i; // Update progress bar value
                await Task.Delay(100); // Wait asynchronously to keep the UI responsive
            }

            progressBarEngagement.Value = 100; // Set progress bar to 100% when done
        }

        // Method to clear all form fields
        private void ClearForm()
        {
            txtIssueId.Clear(); // Clear Issue ID field
            txtLocation.Clear(); // Clear Location field
            cmbCategory.SelectedIndex = -1; // Reset category dropdown
            rtbDescription.Clear(); // Clear description text box
            attachedFiles.Clear(); // Clear attached files list
            lblfileName.Text = string.Empty; // Clear attached files label
            progressBarEngagement.Value = 0; // Reset progress bar
            progressBarEngagement.Visible = false; // Hide progress bar
        }

        // Validation method to ensure the user has entered valid data
        public bool Validation()
        {
            // Validate Issue ID (must be numeric if provided)
            if (!string.IsNullOrWhiteSpace(txtIssueId.Text))
            {
                if (!int.TryParse(txtIssueId.Text, out int result))
                {
                    MessageBox.Show("Please enter a valid numeric value for the Issue ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            // Validate Location (must not be empty)
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            // Validate Category (must be selected)
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            // Validate Description (must not be empty)
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false; // Return false if all validations pass
        }

        // Event handler for the "Back" button to close the form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        // Event handler for clicking on label3 (if any logic needs to be added later)
        private void label3_Click(object sender, EventArgs e)
        {
            // Any necessary logic for clicking on label3
        }
    }
}
