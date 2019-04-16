namespace TimerApp
{
  partial class Confirmation
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.ConfirmText = new System.Windows.Forms.Label();
      this.NoButton = new System.Windows.Forms.Button();
      this.YesButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ConfirmText
      // 
      this.ConfirmText.AutoSize = true;
      this.ConfirmText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ConfirmText.Location = new System.Drawing.Point(12, 9);
      this.ConfirmText.Name = "ConfirmText";
      this.ConfirmText.Size = new System.Drawing.Size(28, 13);
      this.ConfirmText.TabIndex = 0;
      this.ConfirmText.Text = "Text";
      // 
      // NoButton
      // 
      this.NoButton.Location = new System.Drawing.Point(177, 61);
      this.NoButton.Name = "NoButton";
      this.NoButton.Size = new System.Drawing.Size(75, 23);
      this.NoButton.TabIndex = 1;
      this.NoButton.Text = "No";
      this.NoButton.UseVisualStyleBackColor = true;
      this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
      // 
      // YesButton
      // 
      this.YesButton.Location = new System.Drawing.Point(12, 61);
      this.YesButton.Name = "YesButton";
      this.YesButton.Size = new System.Drawing.Size(75, 23);
      this.YesButton.TabIndex = 2;
      this.YesButton.Text = "Yes";
      this.YesButton.UseVisualStyleBackColor = true;
      this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
      // 
      // Confirmation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(264, 96);
      this.Controls.Add(this.YesButton);
      this.Controls.Add(this.NoButton);
      this.Controls.Add(this.ConfirmText);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "Confirmation";
      this.Text = "Confirmation";
      this.Load += new System.EventHandler(this.Confirmation_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label ConfirmText;
    private System.Windows.Forms.Button NoButton;
    private System.Windows.Forms.Button YesButton;
  }
}