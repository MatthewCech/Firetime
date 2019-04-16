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
  public partial class AddItem : Form
  {
    // ((Why must it be this way...))
    private Point location_;

    public AddItem(Point p)
    {
      location_ = p;
      InitializeComponent();
    }

    // Load the active form.
    private void AddItem_Load(object sender, EventArgs e)
    {
      SetDesktopLocation(location_.X + 20, location_.Y + 20);
      this.TaskTime.SelectedIndex = 0;
      this.CustomTimeInput.KeyUp += TabProcessGeneric;
      this.TaskTime.KeyUp += TabProcessGeneric;
      this.TaskName.KeyDown += TabProcessGeneric;
      this.CustomtimeCheckbox.KeyUp += EnterAsCheck;
    }

    // We're done with setting up our item.
    private void DoneButton_Click(object sender, EventArgs e)
    {
      // Attempt to parse string.
      int parsed;

      if (CustomtimeCheckbox.Checked)
        parsed = (int)CustomTimeInput.Value;
      else
        if (!int.TryParse(TaskTime.Text, out parsed))
          parsed = 0;

      Line line = new Line(parsed, TaskName.Text, TaskDescription.Text);
      Program.mainForm.AddMenuItem(line);
      this.Close();
    }

    // Cancel the operation
    private void FormCancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    // Makes the control head to the next form.
    private void TabProcessGeneric(object sender, KeyEventArgs e)
    {
      if(e.KeyCode == Keys.Enter)
        this.ProcessTabKey(true);
    }

    private void EnterAsCheck(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        CustomtimeCheckbox.Checked = !CustomtimeCheckbox.Checked;
    }

    private void CustomtimeCheckbox_CheckedChanged(object sender, EventArgs e)
    {
      // Use a custom time if checked
      if(CustomtimeCheckbox.Checked)
      {
        TaskTime.ClearSelected();
        this.CustomTimeInput.Enabled = true;
        this.TaskTime.Enabled = false;
      }
      else
      {
        this.CustomTimeInput.Enabled = false;
        this.TaskTime.Enabled = true;
      }
    }
  }
}
