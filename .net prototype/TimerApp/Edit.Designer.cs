namespace TimerApp
{
  partial class Edit
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
      this.CustomTimeInput = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.DoneButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.TaskDescription = new System.Windows.Forms.RichTextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.TaskNameText = new System.Windows.Forms.TextBox();
      this.FormDeleteButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.CustomTimeInput)).BeginInit();
      this.SuspendLayout();
      // 
      // CustomTimeInput
      // 
      this.CustomTimeInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.CustomTimeInput.Location = new System.Drawing.Point(83, 109);
      this.CustomTimeInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.CustomTimeInput.Name = "CustomTimeInput";
      this.CustomTimeInput.Size = new System.Drawing.Size(105, 20);
      this.CustomTimeInput.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 122);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 13);
      this.label4.TabIndex = 18;
      this.label4.Text = "(minutes)";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 109);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 17;
      this.label3.Text = "Time Est:";
      // 
      // DoneButton
      // 
      this.DoneButton.Location = new System.Drawing.Point(12, 159);
      this.DoneButton.Name = "DoneButton";
      this.DoneButton.Size = new System.Drawing.Size(75, 23);
      this.DoneButton.TabIndex = 4;
      this.DoneButton.Text = "Done";
      this.DoneButton.UseVisualStyleBackColor = true;
      this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(297, 159);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 6;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
      // 
      // TaskDescription
      // 
      this.TaskDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TaskDescription.Location = new System.Drawing.Point(83, 33);
      this.TaskDescription.Name = "TaskDescription";
      this.TaskDescription.Size = new System.Drawing.Size(289, 70);
      this.TaskDescription.TabIndex = 2;
      this.TaskDescription.Text = "";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 33);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 13;
      this.label2.Text = "Description:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Task Name:";
      // 
      // TaskNameText
      // 
      this.TaskNameText.Location = new System.Drawing.Point(83, 6);
      this.TaskNameText.Name = "TaskNameText";
      this.TaskNameText.Size = new System.Drawing.Size(289, 20);
      this.TaskNameText.TabIndex = 1;
      // 
      // FormDeleteButton
      // 
      this.FormDeleteButton.Location = new System.Drawing.Point(93, 159);
      this.FormDeleteButton.Name = "FormDeleteButton";
      this.FormDeleteButton.Size = new System.Drawing.Size(75, 23);
      this.FormDeleteButton.TabIndex = 5;
      this.FormDeleteButton.Text = "Delete";
      this.FormDeleteButton.UseVisualStyleBackColor = true;
      this.FormDeleteButton.Click += new System.EventHandler(this.FormDeleteButton_Click);
      // 
      // Edit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(384, 191);
      this.Controls.Add(this.FormDeleteButton);
      this.Controls.Add(this.CustomTimeInput);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DoneButton);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.TaskDescription);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TaskNameText);
      this.Name = "Edit";
      this.Text = "Edit";
      this.Load += new System.EventHandler(this.Edit_Load);
      ((System.ComponentModel.ISupportInitialize)(this.CustomTimeInput)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown CustomTimeInput;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button DoneButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.RichTextBox TaskDescription;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox TaskNameText;
    private System.Windows.Forms.Button FormDeleteButton;
  }
}