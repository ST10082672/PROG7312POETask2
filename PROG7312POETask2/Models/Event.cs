using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Event
{
    /// <summary>
    /// Gets or sets the name of the event.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the category of the event.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the date of the event.
    /// </summary>
    public DateTime Date { get; set; }
    private void frmAddEvent_Load(object sender, EventArgs e)
    {
        
    }

}
