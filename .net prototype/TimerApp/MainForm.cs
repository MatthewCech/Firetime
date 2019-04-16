using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace TimerApp
{ 
  public partial class MainForm : Form
  {
    // This feels dirty :V
    public const string PrimaryFile = "listData.cfg";
    private DateTime start_;
    private DateTime end_;
    private bool timerActive_;

    // Main form initialization.
    public MainForm()
    {
      InitializeComponent();
    }


    // Main form loading
    private void MainForm_Load(object sender, EventArgs e)
    {
      // Set color stuff. Note:
      //this.TransparencyKey = Color.LimeGreen;
      //this.BackColor = Color.LimeGreen;
      Color defaultColor = Color.FromArgb(255, 240, 240, 240);
      PrimaryList.BackColor = defaultColor;
      HistoryList.BackColor = defaultColor;
      PrimaryList.BorderStyle = BorderStyle.FixedSingle;
      HistoryList.BorderStyle = BorderStyle.FixedSingle;
      timerActive_ = false;

      // Bind events
      this.FormClosing += Primary_FormClosing;
      this.GraphBox.Paint += DrawGraph;
      this.PrimaryList.KeyUp += HandleMainformKeyUp;
      this.HistoryList.KeyUp += HandleHistoryformKeyUp;

      //Set default back colors
      GraphBox.BackColor = defaultColor;

      // Read from file and populate existing list
      // At the moment, hard coded.
      if (File.Exists(PrimaryFile))
      {
        StreamReader sr = new StreamReader(PrimaryFile);

        string buff;
        while ((buff = sr.ReadLine()) != null)
        {
          if (buff.Length > 0)
          {
            if (buff.Substring(0, Line.CompletedIndicator.Length) == Line.CompletedIndicator)
              HistoryList.Items.Add(new Line(buff));
            else
              PrimaryList.Items.Insert(PrimaryList.Items.Count, new Line(buff));
          }
        }

        sr.Close();
      }

      // Grey out buttons if necessary.
      ButtonStatusUpdate();
    }


    // Allows the user to add an item to the checklist.
    public void AddMenuItem(Line line)
    {
      this.AddMenuItem(line, 0);
    }

    // Add a menu item at an index
    public void AddMenuItem(Line line, int index)
    {
      PrimaryList.Items.Insert(index, line);
    }

    // Marks the specified index as a completed task.
    public void MarkAsComplete(int index, int actualTime)
    {
      PrimaryList.SetSelected(index, true);
      Line selected = PrimaryList.SelectedItem.ToString();
      PrimaryList.Items.RemoveAt(index);
      selected.CompleteTask(actualTime);
      HistoryList.Items.Add(selected);
    }

    // Delete selected item in main list.
    public void DeleteSelected()
    {
      PrimaryList.Items.RemoveAt(PrimaryList.SelectedIndex);
    }

    // Completes the active task using the current timer info.
    public void AutoTimeCompleteSelected()
    {
      MarkAsComplete(PrimaryList.SelectedIndex, (end_ - start_).Minutes);
    }

    // Gets specified item from history.
    public Line GetHistoryLine(int index)
    {
      return HistoryList.Items[index].ToString();
    }

    // Intercepts form closing request and dumps file contents to a .cfg file.
    private void Primary_FormClosing(object sender, FormClosingEventArgs e)
    {
      // dump settings to cfg file here
      StreamWriter sw = new StreamWriter(PrimaryFile);
      foreach (Line l in PrimaryList.Items)
        sw.WriteLine(l);
      foreach (Line l in HistoryList.Items)
        sw.WriteLine(l);
      sw.Close();
    }


    // Instanciated a secondary form that sets global information for a new task to add.
    private void AddButton_Click(object sender, EventArgs e)
    {
      // Create second form using location of this one as a base.
      AddItem f2 = new AddItem(MainForm.ActiveForm.DesktopLocation);
      f2.ShowDialog();
    }


    // The effective update loop for drawing the graph
    private void DrawGraph(object sender, PaintEventArgs e)
    {
      // Number of pixels per minute of time.
      int scalar = 5;

      // Draw horizontal lines and labels
      for (int i = 0; i < GraphBox.Height; i += 50)
      {
        e.Graphics.DrawLine(
          Pens.Gray, 0, GraphBox.Height - i - 1, GraphBox.Width, GraphBox.Height - i - 1);
        e.Graphics.DrawString(
          "" + i / scalar, DefaultFont, Brushes.Black, 0, GraphBox.Height - i);
      }


      // Draw vertical lines and labels
      for (int i = 0; i < GraphBox.Width; i += 50)
      {
        e.Graphics.DrawLine(Pens.Gray, i, 0, i, GraphBox.Height);
        e.Graphics.DrawString("" + i / scalar, DefaultFont, Brushes.Black, i, GraphBox.Height - 12);
      }

      // Draw "ideal" reference line
      e.Graphics.DrawLine(Pens.DarkGray, 0, GraphBox.Height - 1, GraphBox.Height - 1, 0);

      // Remove all controls.
      while(GraphBox.Controls.Count > 0)
        GraphBox.Controls.RemoveAt(0);

      // Draw all items
      for (int i = 0; i < HistoryList.Items.Count; ++i)
      {
        Line l = HistoryList.Items[i].ToString();

        // Make small button
        ButtonPoint bp = new ButtonPoint(i, new Point(l.TimeEst * scalar, GraphBox.Height - 1 - l.ActualTime * scalar));
        GraphBox.Controls.Add(bp);
      }
    }

    // Indicates a task was completed.
    private void CompleteButton_Click(object sender, EventArgs e)
    {
      if (PrimaryList.SelectedIndex == -1)
      {
        MessageBox.Show("No item selected.");
        return;
      }

      // Scream agressively and complete the task.
      string str = PrimaryList.SelectedItem.ToString();
      Complete completeForm = new Complete(PrimaryList.SelectedIndex, ActiveForm.DesktopLocation);
      completeForm.ShowDialog();
    }

    private void AutoTimeButton_Click(object sender, EventArgs e)
    {
      // End timer
      if(timerActive_)
      {
        // Account for user somehow breaking everything.
        if(PrimaryList.SelectedIndex == -1)
        {
          MessageBox.Show(
            "I'm super impressed, email me at reveriewisp@gmail.com if you can reproduce this.");
          return;
        }

        // End timer
        timerActive_ = false;

        // Mark time, and create string showing time recorded.
        end_ = DateTime.Now;
        string time = (end_ - start_).ToString();
        string toDisplay = time.Substring(0, time.IndexOf("."));
        toDisplay = 
          "Use this recorded time " + toDisplay + "?\n" 
          + "(" + PrimaryList.SelectedItem + ")";

        // Create confirmation window
        Confirmation con = new Confirmation(
          ActiveForm.DesktopLocation,
          toDisplay,
          AutoTimeCompleteSelected,
          true);
        con.ShowDialog();
      }
      // Start timer
      else
      {
        // If we have nothing selected,
        if(PrimaryList.SelectedIndex == -1)
        {
          //Alert a = new Alert(ActiveForm.Location, "DONT");
          //a.ShowDialog();
          MessageBox.Show("Nothing selected!");
          return;
        }
        start_ = DateTime.Now;
        timerActive_ = true;
      }
    }

    // When the timer ticks, per second,
    private void OneSecTimer_Tick(object sender, EventArgs e)
    {
      if (timerActive_)
      {
        string time = (DateTime.Now - start_).ToString();
        timerHUD.Text = time.Substring(0, time.IndexOf("."));
      }
      else
        timerHUD.Text = "00:00:00";
    }


    // Handle a change in selection, primarily for button enabling
    private void PrimaryList_SelectedIndexChanged(object sender, EventArgs e)
    {
      ButtonStatusUpdate();
    }


    private void ButtonStatusUpdate()
    {
      // If we don't have something selected, disable. 
      if (PrimaryList.SelectedIndex == -1)
      {
        EditButton.Enabled = false;
        CompleteButton.Enabled = false;
        AutoTimeButton.Enabled = false;
      }
      else
      {
        EditButton.Enabled = true;
        CompleteButton.Enabled = true;
        AutoTimeButton.Enabled = true;
      }
    }


    // Handle a key being pressed.
    private void HandleMainformKeyUp(object sender, KeyEventArgs e)
    {
      // If we have stuff selected...
      if (PrimaryList.SelectedIndex != -1)
      {
        if (e.KeyCode == Keys.Delete)
        {
          Confirmation con = new Confirmation(
            ActiveForm.DesktopLocation,
            "Are you sure you want to delete this task?",
            DeleteSelected);
          con.ShowDialog();
        }
      }
    }

    private void HandleHistoryformKeyUp(object sender, KeyEventArgs e)
    {
      // If we have stuff selected...
      if (HistoryList.SelectedIndex != -1)
      {
        if (e.KeyCode == Keys.Delete)
          HistoryList.Items.RemoveAt(HistoryList.SelectedIndex);
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      // Check to make sure primary list has item selected.
      if (PrimaryList.SelectedIndex != -1)
      {
        Edit edit = new Edit(ActiveForm.DesktopLocation, PrimaryList.SelectedItem.ToString());
        edit.ShowDialog();
      }
    }

    // Clears all of the items in the history list.
    private void ClearAllButton_Click(object sender, EventArgs e)
    {
      Confirmation con = new Confirmation(
        ActiveForm.DesktopLocation,
        "Are you sure you want to delete everything in your\n"+"history? This action can not be undone.",
        HistoryList.Items.Clear);
      con.ShowDialog();
    }
  }


  //////////////////////////////////////////////////////////////////////////////////////////
  public class ButtonPoint : Button
  {
    private int primaryIndex_;
    public ButtonPoint(int primaryIndex, Point position)
    {
      primaryIndex_ = primaryIndex;
      this.MouseDown += MouseClickOn;
      this.Size = new Size(7, 7);
      this.BackColor = Color.MediumPurple;
      this.FlatStyle = FlatStyle.Flat;
      this.FlatAppearance.BorderColor = Color.Black;
      this.FlatAppearance.MouseDownBackColor = Color.Black;
      this.FlatAppearance.MouseOverBackColor = Color.Purple;
      this.FlatAppearance.BorderSize = 1;
      this.TabStop = false;
      this.Location = new Point(position.X - 3, position.Y - 3 );
    }

    private void MouseClickOn(object sender, EventArgs e)
    {
      Line line = Program.mainForm.GetHistoryLine(primaryIndex_);
      string toShow = "";
      toShow += "Name: " + line.Name + "\n";
      toShow += "Description: " + line.Description + "\n\n";
      toShow += "Estimated time (min):" + line.TimeEst + "\n";
      toShow += "Actual time (min):" + line.ActualTime;
      MessageBox.Show(toShow);
    }
  }
}
