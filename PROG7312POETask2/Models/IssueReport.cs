using PROG7312POETask2.Models;
using PROG7312POETask2.DataStructures;
using System.Collections.Generic;

/// <summary>
/// Represents an issue report in the municipal system.
/// </summary>
public class IssueReport
{
    /// <summary>
    /// Gets or sets the location of the issue.
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// Gets or sets the category of the issue.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the description of the issue.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the list of attached files related to the issue.
    /// </summary>
    public List<string> AttachedFiles { get; set; }
}
