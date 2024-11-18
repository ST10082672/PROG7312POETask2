using PROG7312POETask2;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

internal static class Program
{
    /// <summary>
    /// Main method to start the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PROG7312POE());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Application encountered an error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
