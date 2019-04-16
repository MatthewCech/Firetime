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
  public partial class Complete : Form
  {
    // starting location var
    private Point startingLocation_;
    private int mainformLine_;

    public Complete(int mainformLine, Point p)
    {
      startingLocation_ = p;
      mainformLine_ = mainformLine;
      InitializeComponent();
      CustomTimeInput.KeyDown += TabProcessGeneric;
    }


    // Sets the starting location of the window via loading
    private void Complete_Load(object sender, EventArgs e)
    {
      SetDesktopLocation(startingLocation_.X + 20, startingLocation_.Y + 20);
    }


    // We good here fam, we good. Tab on to the next part.
    private void TabProcessGeneric(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        this.ProcessTabKey(true);
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
      // Attempt to parse the text field. Anticipate failure of user to
      // perform even basic tasks.
      Program.mainForm.MarkAsComplete(mainformLine_, (int)CustomTimeInput.Value);
      this.Close();
    }

    private void FormCancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
