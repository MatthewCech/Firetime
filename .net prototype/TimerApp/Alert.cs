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
  public partial class Alert : Form
  {
    private string message_;
    private Point location_;

    public Alert(Point location, string message)
    {
      location_ = location;
      message_ = message;
      InitializeComponent();
    }

    private void Alert_Load(object sender, EventArgs e)
    {
      SetDesktopLocation(location_.X, location_.Y);
      message.Text = message_;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
