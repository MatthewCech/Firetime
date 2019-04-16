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
  public partial class Confirmation : Form
  {
    // Delegate for a void function.
    public delegate void ToCall();

    // Private vars
    private ToCall funcToCall_;
    private string message_ = "";
    private Point  location_;


    // Constructor
    public Confirmation(Point location, string message, ToCall funcToCall, bool yesFirst = false)
    {
      // Set private variables
      location_ = location;
      funcToCall_ = funcToCall;
      message_ = message;


      // Initialize component
      InitializeComponent();

      if (yesFirst)
      {
        YesButton.TabIndex = 1;
        NoButton.TabIndex = 2;
        //YesButton.Select
      }
      ConfirmText.Text = message;
    }


    // Cancel the operation.
    private void NoButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    // Call our delegate and close.
    private void YesButton_Click(object sender, EventArgs e)
    {
      funcToCall_();
      this.Close();
    }


    // Set up stuff during loading.
    private void Confirmation_Load(object sender, EventArgs e)
    {
      DesktopLocation = new Point(location_.X + 20, location_.Y + 20);
    }
  }
}
