namespace TimerApp
{
    partial class AddItem
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
      this.TaskName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.TaskDescription = new System.Windows.Forms.RichTextBox();
      this.TaskTime = new System.Windows.Forms.ListBox();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.DoneButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.CustomtimeCheckbox = new System.Windows.Forms.CheckBox();
      this.CustomTimeInput = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.CustomTimeInput)).BeginInit();
      this.SuspendLayout();
      // 
      // TaskName
      // 
      this.TaskName.Location = new System.Drawing.Point(83, 10);
      this.TaskName.Name = "TaskName";
      this.TaskName.Size = new System.Drawing.Size(289, 20);
      this.TaskName.TabIndex = 1;
      this.TaskName.Text = "Task Name";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Task Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Description:";
      // 
      // TaskDescription
      // 
      this.TaskDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TaskDescription.Location = new System.Drawing.Point(83, 37);
      this.TaskDescription.Name = "TaskDescription";
      this.TaskDescription.Size = new System.Drawing.Size(289, 70);
      this.TaskDescription.TabIndex = 2;
      this.TaskDescription.Text = "";
      // 
      // TaskTime
      // 
      this.TaskTime.FormattingEnabled = true;
      this.TaskTime.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "30",
            "60",
            "90",
            "120",
            "180",
            "240"});
      this.TaskTime.Location = new System.Drawing.Point(83, 113);
      this.TaskTime.Name = "TaskTime";
      this.TaskTime.Size = new System.Drawing.Size(127, 82);
      this.TaskTime.TabIndex = 3;
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(297, 176);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 7;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
      // 
      // DoneButton
      // 
      this.DoneButton.Location = new System.Drawing.Point(216, 176);
      this.DoneButton.Name = "DoneButton";
      this.DoneButton.Size = new System.Drawing.Size(75, 23);
      this.DoneButton.TabIndex = 6;
      this.DoneButton.Text = "Done";
      this.DoneButton.UseVisualStyleBackColor = true;
      this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 113);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Time Est:";
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(14, 126);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "(minutes)";
      // 
      // CustomtimeCheckbox
      // 
      this.CustomtimeCheckbox.AutoSize = true;
      this.CustomtimeCheckbox.Location = new System.Drawing.Point(216, 113);
      this.CustomtimeCheckbox.Name = "CustomtimeCheckbox";
      this.CustomtimeCheckbox.Size = new System.Drawing.Size(112, 17);
      this.CustomtimeCheckbox.TabIndex = 4;
      this.CustomtimeCheckbox.Text = "Use Custom Time:";
      this.CustomtimeCheckbox.UseVisualStyleBackColor = true;
      this.CustomtimeCheckbox.CheckedChanged += new System.EventHandler(this.CustomtimeCheckbox_CheckedChanged);
      // 
      // CustomTimeInput
      // 
      this.CustomTimeInput.Enabled = false;
      this.CustomTimeInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.CustomTimeInput.Location = new System.Drawing.Point(216, 136);
      this.CustomTimeInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.CustomTimeInput.Name = "CustomTimeInput";
      this.CustomTimeInput.Size = new System.Drawing.Size(105, 20);
      this.CustomTimeInput.TabIndex = 5;
      // 
      // AddItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(384, 211);
      this.Controls.Add(this.CustomTimeInput);
      this.Controls.Add(this.CustomtimeCheckbox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DoneButton);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.TaskTime);
      this.Controls.Add(this.TaskDescription);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TaskName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "AddItem";
      this.Text = "Add Item";
      this.Load += new System.EventHandler(this.AddItem_Load);
      ((System.ComponentModel.ISupportInitialize)(this.CustomTimeInput)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TaskDescription;
        private System.Windows.Forms.ListBox TaskTime;
        private System.Windows.Forms.Button FormCancelButton;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox CustomtimeCheckbox;
    private System.Windows.Forms.NumericUpDown CustomTimeInput;
  }
}