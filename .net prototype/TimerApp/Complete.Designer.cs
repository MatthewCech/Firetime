namespace TimerApp
{
    partial class Complete
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
      this.components = new System.ComponentModel.Container();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.label3 = new System.Windows.Forms.Label();
      this.DoneButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.CustomTimeInput = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.CustomTimeInput)).BeginInit();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(134, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Estimated Completion Time";
      // 
      // DoneButton
      // 
      this.DoneButton.Location = new System.Drawing.Point(12, 46);
      this.DoneButton.Name = "DoneButton";
      this.DoneButton.Size = new System.Drawing.Size(75, 23);
      this.DoneButton.TabIndex = 2;
      this.DoneButton.Text = "Done";
      this.DoneButton.UseVisualStyleBackColor = true;
      this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(173, 46);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 3;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
      // 
      // CustomTimeInput
      // 
      this.CustomTimeInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.CustomTimeInput.Location = new System.Drawing.Point(149, 7);
      this.CustomTimeInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.CustomTimeInput.Name = "CustomTimeInput";
      this.CustomTimeInput.Size = new System.Drawing.Size(99, 20);
      this.CustomTimeInput.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(47, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "(minutes)";
      // 
      // Complete
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(260, 81);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CustomTimeInput);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DoneButton);
      this.Controls.Add(this.FormCancelButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "Complete";
      this.Text = "Complete";
      this.Load += new System.EventHandler(this.Complete_Load);
      ((System.ComponentModel.ISupportInitialize)(this.CustomTimeInput)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button DoneButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.NumericUpDown CustomTimeInput;
    private System.Windows.Forms.Label label1;
  }
}