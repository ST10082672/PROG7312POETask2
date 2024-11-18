using PROG7312POETask2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PROG7312POETask2
{
    public partial class frmLocalEventsandAnnouncements : Form
    {
        public SortedDictionary<string, Queue<Event>> eventsDictionary;
        public Queue<Event> upcomingEventsQueue;
        private Stack<Announcement> announcementsStack;
        private Dictionary<string, int> searchHistory = new Dictionary<string, int>();
        
        public frmLocalEventsandAnnouncements()
        {
            InitializeComponent();
            Initialize();
            DisplayUpcomingEvents();
     
        }
     

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            try
            {
                int eventIndex = lvEvents.Items.Count;
                if (eventIndex < 1)
                {
                    MessageBox.Show("Please add event item first before removing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                upcomingEventsQueue.Dequeue();
                DisplayUpcomingEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            frmAddEvent frmEvent = new frmAddEvent();

            if (frmEvent.ShowDialog() == DialogResult.OK)
            {
                // Access the returned data from the subform
                var newEvent = frmEvent.eventList;

                foreach (var itemEvent in newEvent)
                {
                    upcomingEventsQueue.Enqueue(itemEvent);
                }


                DisplayUpcomingEvents();
            }

        }

        private void btnAddAnnouncements_Click(object sender, EventArgs e)
        {
            try
            {
                string value = "";

                if (InputBox("Dialog Box", "Add Announcement", ref value) == DialogResult.OK)
                {
                    var newAnnouncement = new Announcement
                    {
                        AnnouncementText = value
                    };
                    announcementsStack.Push(newAnnouncement);
                }
                MessageBox.Show("Announcement saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DisplayAnnouncements();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveAnnouncements_Click(object sender, EventArgs e)
        {
            try
            {
                int eventIndex = lbAnnouncements.Items.Count;
                if (eventIndex < 1)
                {
                    MessageBox.Show("Please add announcement item first before removing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                announcementsStack.Pop();
                DisplayAnnouncements();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Initialize()
        {
            eventsDictionary = new SortedDictionary<string, Queue<Event>>();
            upcomingEventsQueue = new Queue<Event>();
            announcementsStack = new Stack<Announcement>();
        }
        public void DisplayUpcomingEvents()
        {
            int count = 1;
            lvEvents.Items.Clear();
            foreach (var eventItem in upcomingEventsQueue)
            {
                // Display event details in the ListView
                lvEvents.Items.Add($"{count}.{eventItem.Name} - {eventItem.Category} - {eventItem.Date}");

                // Wrap the event item in a new queue and add it to the dictionary
                Queue<Event> eventQueue = new Queue<Event>();
                eventQueue.Enqueue(eventItem);
                eventsDictionary.Add(eventItem.Name, eventQueue);

                count++;
            }
        }

        public void DisplayAnnouncements()
        {
            int count = 1;
            lbAnnouncements.Items.Clear();
            foreach (var e in announcementsStack)
            {
                lbAnnouncements.Items.Add($"{count}.{e.AnnouncementText}");
                count++;
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);

            label.AutoSize = true;
            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.TopMost = true;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearchEvent.Text.ToLower(); // Get search input
            lvEvents.Items.Clear(); // Clear previous search results
            bool resultsFound = false;

            // To loop through the eventsDictionary to find matching events
            foreach (var eventList in eventsDictionary)
            {
                foreach (var ev in eventList.Value)
                {
                    if (ev.Category.ToLower().Contains(searchTerm) || ev.Name.ToLower().Contains(searchTerm))
                    {
                        // Add matching event to the ListView
                        lvEvents.Items.Add(new ListViewItem(new[]
                        {
                        ev.Name, ev.Category, ev.Date.ToShortDateString()
                    }));
                        resultsFound = true;
                    }
                }
            }

            // to provide feedback if no matching events are found
            if (!resultsFound)
            {
                MessageBox.Show("No events found matching your search term.",
                                "Search Results",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

            // to log the search term for future recommendations
            LogSearch(searchTerm);

            // Update the recommendation label based on search history
            RecommendEvent();
        }

        private void LogSearch(string searchTerm)
        {
            if (searchHistory.ContainsKey(searchTerm))
                searchHistory[searchTerm]++;
            else
                searchHistory[searchTerm] = 1;
        }

        private void RecommendEvent()
        {
            if (searchHistory.Count > 0)
            {
                // to get the most searched term from the search history
                var mostSearched = searchHistory.OrderByDescending(x => x.Value).FirstOrDefault();

                // to check if there are events related to the most searched term
                bool eventExists = eventsDictionary.Any(eventList =>
                    eventList.Key.ToLower().Contains(mostSearched.Key.ToLower()) ||
                    eventList.Value.Any(ev => ev.Category.ToLower().Contains(mostSearched.Key.ToLower()))
                );

                if (eventExists)
                {
                    // Update the recommendation label with the suggestion
                    lblRecommendation.Text = $"Recommended: Events related to '{mostSearched.Key}'";
                }
                else
                {
                    // No relevant events found for the most searched term
                    lblRecommendation.Text = "No relevant events found for your search history.";
                }
            }
            else
            {
                // No search history available
                lblRecommendation.Text = "No recommendations available yet.";
            }
        }

        private void lblRecommendation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recommendation label clicked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}