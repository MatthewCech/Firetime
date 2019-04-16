using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TimerApp
{
  public partial class Edit : Form
  {
    // Varables
    private Point location_;
    private Line line_;

    // Constructor
    public Edit(Point location, Line line)
    {
      // Assign local vars
      location_ = location;
      line_ = line;

      // Init
      InitializeComponent();
    }


    // On form load, set some defaults that require init.
    private void Edit_Load(object sender, EventArgs e)
    {
      // Set locaton
      DesktopLocation = new Point(location_.X + 20, location_.Y + 20);

      // Populate line info
      TaskNameText.Text = line_.Name;
      TaskDescription.Text = line_.Description;
      CustomTimeInput.Value = line_.TimeEst;
    }

    /// <summary> When done button is clicked </summary> <param name="sender">Sending obj</param> <param name="e">generic Event args</param>
    private void DoneButton_Click(object sender, EventArgs e)
    {
      // Get the primary list using controls.
      TabControl tabs = ((TabControl)Program.mainForm.Controls["PrimaryTabControl"]);
      TabPage taskPage = tabs.TabPages[0]; // !Hard coded!
      ListBox primaryList = ((ListBox)taskPage.Controls["PrimaryList"]);
      
      // If we are out of range
      if (primaryList.SelectedIndex == -1)
      {
        this.Close();
        return;
      }

      // Construct new line.
      Line newLine = new Line(
        (int)CustomTimeInput.Value,
        TaskNameText.Text,
        TaskDescription.Text);

      // Remove old line and add a new one.
      Program.mainForm.DeleteSelected();
      Program.mainForm.AddMenuItem(newLine);

      // We're actually done here now.
      this.Close();
    }


    // Hit the cancel button, save nothing.
    private void FormCancelButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    // Closes both this and adjust stuff on the main form.
    public void DoubleClose()
    {
      Program.mainForm.DeleteSelected();
      this.Close();
    }

    //Delete selected line.
    private void FormDeleteButton_Click(object sender, EventArgs e)
    {
      Confirmation con = new Confirmation(
        ActiveForm.DesktopLocation,
        "Are you sure you want to delete this task?",
        DoubleClose);
      con.ShowDialog();
    }
  }
}
