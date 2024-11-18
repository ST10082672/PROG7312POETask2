using PROG7312POETask2; // Importing the namespace for the project
using System; // Importing System namespace for common .NET functionality
using System.Collections.Generic; // Importing for using collections like List and HashSet
using System.ComponentModel; // Importing for using Windows Forms components
using System.Data; // Importing for working with data
using System.Drawing; // Importing for drawing and working with graphics
using System.Linq; // Importing for LINQ functionality
using System.Text; // Importing for text encoding utilities
using System.Threading.Tasks; // Importing for task-based asynchronous programming
using System.Windows.Forms; // Importing for Windows Forms UI controls

namespace PROG7312POETask2
{
    // frmAddEvent is a form for adding new events to the event list
    public partial class frmAddEvent : Form
    {
        public List<Event> eventList { get; set; } // List to hold events
        private HashSet<string> eventCategories; // HashSet to hold event categories
        private frmLocalEventsandAnnouncements frmLocalEventsandAnnouncements = new frmLocalEventsandAnnouncements(); // Reference to another form for local events and announcements

        // Constructor that initializes the form and sets up the event categories
        public frmAddEvent()
        {
            InitializeComponent(); // Initialize the components of the form
            Initialize(); // Initialize additional data and settings
        }

        // Event handler for the Save button click event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // If form validation fails, return
                if (FormValidations()) { return; }

                // Create a new Event object from the form's input
                var newEvent = new Event
                {
                    Name = txtEventName.Text, // Get event name from textbox
                    Category = cmbCategory.SelectedItem.ToString(), // Get selected category from dropdown
                    Date = dtpEventDateTime.Value // Get event date from datetime picker
                };

                eventList.Add(newEvent); // Add the new event to the event list

                // Show success message
                MessageBox.Show("Event saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and show error message
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Set dialog result to OK
            this.Close(); // Close the form
        }

        // Event handler for the form's load event
        private void frmAddEvent_Load(object sender, EventArgs e)
        {
            
        }

        // Event handler for the Clear Form button click event
        private void btnClearform_Click(object sender, EventArgs e)
        {
            
        }

        // Initialize method to set up initial data and settings for the form
        public void Initialize()
        {
            eventCategories = new HashSet<string>(); // Initialize event categories collection
            eventList = new List<Event>();  // Initialize event list

            // Set up the categories dropdown with available categories
            cmbCategory.DataSource = PopulateCategories().ToList();
        }

        // PopulateCategories method to define available event categories
        public HashSet<string> PopulateCategories()
        {
            eventCategories.Add("Communicity Service");
            eventCategories.Add("Youth outreach");
            eventCategories.Add("Mandela day");
            eventCategories.Add("Talent Show");

            return eventCategories; // Return the list of categories
        }

        // FormValidations method to validate form inputs before saving
        public bool FormValidations()
        {
            // Validate the event name input
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                // Show warning message if the event name is empty or whitespace
                MessageBox.Show("Please enter the event name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true; // Return true to indicate validation failed
            }

            return false; // Return false if all validations pass
        }
    }
}
