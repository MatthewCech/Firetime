namespace TimerApp
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.PrimaryTabControl = new System.Windows.Forms.TabControl();
      this.CurrentTasksTab = new System.Windows.Forms.TabPage();
      this.GenericLabel = new System.Windows.Forms.Label();
      this.timerHUD = new System.Windows.Forms.Label();
      this.AutoTimeButton = new System.Windows.Forms.Button();
      this.EditButton = new System.Windows.Forms.Button();
      this.CompleteButton = new System.Windows.Forms.Button();
      this.PrimaryList = new System.Windows.Forms.ListBox();
      this.AddButton = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.ClearAllButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.HistoryList = new System.Windows.Forms.ListBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.GraphBox = new System.Windows.Forms.PictureBox();
      this.OneSecTimer = new System.Windows.Forms.Timer(this.components);
      this.PrimaryTabControl.SuspendLayout();
      this.CurrentTasksTab.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GraphBox)).BeginInit();
      this.SuspendLayout();
      // 
      // PrimaryTabControl
      // 
      this.PrimaryTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PrimaryTabControl.Controls.Add(this.CurrentTasksTab);
      this.PrimaryTabControl.Controls.Add(this.tabPage2);
      this.PrimaryTabControl.Controls.Add(this.tabPage3);
      this.PrimaryTabControl.Location = new System.Drawing.Point(13, 13);
      this.PrimaryTabControl.Name = "PrimaryTabControl";
      this.PrimaryTabControl.SelectedIndex = 0;
      this.PrimaryTabControl.Size = new System.Drawing.Size(509, 286);
      this.PrimaryTabControl.TabIndex = 0;
      // 
      // CurrentTasksTab
      // 
      this.CurrentTasksTab.Controls.Add(this.GenericLabel);
      this.CurrentTasksTab.Controls.Add(this.timerHUD);
      this.CurrentTasksTab.Controls.Add(this.AutoTimeButton);
      this.CurrentTasksTab.Controls.Add(this.EditButton);
      this.CurrentTasksTab.Controls.Add(this.CompleteButton);
      this.CurrentTasksTab.Controls.Add(this.PrimaryList);
      this.CurrentTasksTab.Controls.Add(this.AddButton);
      this.CurrentTasksTab.Location = new System.Drawing.Point(4, 22);
      this.CurrentTasksTab.Name = "CurrentTasksTab";
      this.CurrentTasksTab.Padding = new System.Windows.Forms.Padding(3);
      this.CurrentTasksTab.Size = new System.Drawing.Size(501, 260);
      this.CurrentTasksTab.TabIndex = 0;
      this.CurrentTasksTab.Text = "Current Tasks";
      this.CurrentTasksTab.UseVisualStyleBackColor = true;
      // 
      // GenericLabel
      // 
      this.GenericLabel.AutoSize = true;
      this.GenericLabel.Location = new System.Drawing.Point(4, 4);
      this.GenericLabel.Name = "GenericLabel";
      this.GenericLabel.Size = new System.Drawing.Size(224, 13);
      this.GenericLabel.TabIndex = 7;
      this.GenericLabel.Text = "[Time Estimate] Task name : Task Description";
      // 
      // timerHUD
      // 
      this.timerHUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.timerHUD.AutoSize = true;
      this.timerHUD.Location = new System.Drawing.Point(326, 236);
      this.timerHUD.Name = "timerHUD";
      this.timerHUD.Size = new System.Drawing.Size(49, 13);
      this.timerHUD.TabIndex = 6;
      this.timerHUD.Text = "00:00:00";
      // 
      // AutoTimeButton
      // 
      this.AutoTimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.AutoTimeButton.Location = new System.Drawing.Point(206, 231);
      this.AutoTimeButton.Name = "AutoTimeButton";
      this.AutoTimeButton.Size = new System.Drawing.Size(114, 23);
      this.AutoTimeButton.TabIndex = 5;
      this.AutoTimeButton.Text = "AutoTime (start/stop)";
      this.AutoTimeButton.UseVisualStyleBackColor = true;
      this.AutoTimeButton.Click += new System.EventHandler(this.AutoTimeButton_Click);
      // 
      // EditButton
      // 
      this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.EditButton.Location = new System.Drawing.Point(87, 231);
      this.EditButton.Name = "EditButton";
      this.EditButton.Size = new System.Drawing.Size(75, 23);
      this.EditButton.TabIndex = 4;
      this.EditButton.Text = "Edit";
      this.EditButton.UseVisualStyleBackColor = true;
      this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
      // 
      // CompleteButton
      // 
      this.CompleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CompleteButton.Enabled = false;
      this.CompleteButton.ForeColor = System.Drawing.SystemColors.ControlText;
      this.CompleteButton.Location = new System.Drawing.Point(6, 231);
      this.CompleteButton.Name = "CompleteButton";
      this.CompleteButton.Size = new System.Drawing.Size(75, 23);
      this.CompleteButton.TabIndex = 2;
      this.CompleteButton.Text = "Complete";
      this.CompleteButton.UseVisualStyleBackColor = true;
      this.CompleteButton.Click += new System.EventHandler(this.CompleteButton_Click);
      // 
      // PrimaryList
      // 
      this.PrimaryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PrimaryList.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PrimaryList.FormattingEnabled = true;
      this.PrimaryList.ItemHeight = 15;
      this.PrimaryList.Location = new System.Drawing.Point(6, 19);
      this.PrimaryList.Name = "PrimaryList";
      this.PrimaryList.Size = new System.Drawing.Size(489, 199);
      this.PrimaryList.TabIndex = 1;
      this.PrimaryList.SelectedIndexChanged += new System.EventHandler(this.PrimaryList_SelectedIndexChanged);
      // 
      // AddButton
      // 
      this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.AddButton.Location = new System.Drawing.Point(420, 231);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(75, 23);
      this.AddButton.TabIndex = 3;
      this.AddButton.Text = "Add";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.ClearAllButton);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Controls.Add(this.HistoryList);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(501, 260);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "History";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // ClearAllButton
      // 
      this.ClearAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ClearAllButton.ForeColor = System.Drawing.SystemColors.ControlText;
      this.ClearAllButton.Location = new System.Drawing.Point(6, 231);
      this.ClearAllButton.Name = "ClearAllButton";
      this.ClearAllButton.Size = new System.Drawing.Size(75, 23);
      this.ClearAllButton.TabIndex = 2;
      this.ClearAllButton.Text = "Clear All";
      this.ClearAllButton.UseVisualStyleBackColor = true;
      this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(4, 4);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(293, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "*Time Estimate] Task name : Task Description > Actual Time";
      // 
      // HistoryList
      // 
      this.HistoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.HistoryList.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HistoryList.FormattingEnabled = true;
      this.HistoryList.ItemHeight = 15;
      this.HistoryList.Location = new System.Drawing.Point(6, 19);
      this.HistoryList.Name = "HistoryList";
      this.HistoryList.Size = new System.Drawing.Size(489, 199);
      this.HistoryList.TabIndex = 1;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.label8);
      this.tabPage3.Controls.Add(this.label7);
      this.tabPage3.Controls.Add(this.label6);
      this.tabPage3.Controls.Add(this.label5);
      this.tabPage3.Controls.Add(this.label3);
      this.tabPage3.Controls.Add(this.label2);
      this.tabPage3.Controls.Add(this.label1);
      this.tabPage3.Controls.Add(this.GraphBox);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(501, 260);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Accuracy";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(49, 4);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(188, 13);
      this.label8.TabIndex = 10;
      this.label8.Text = "Click on a point to view a specific task";
      // 
      // label7
      // 
      this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(7, 143);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(29, 13);
      this.label7.TabIndex = 9;
      this.label7.Text = "(min)";
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.AutoSize = true;
      this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.label6.Location = new System.Drawing.Point(412, 220);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(75, 13);
      this.label6.TabIndex = 8;
      this.label6.Text = "Overestimated";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.label5.Location = new System.Drawing.Point(54, 27);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(81, 13);
      this.label5.TabIndex = 7;
      this.label5.Text = "Underestimated";
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 130);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Time";
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(4, 117);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Actual";
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(217, 244);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(124, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Estimated Time (minutes)";
      // 
      // GraphBox
      // 
      this.GraphBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GraphBox.Location = new System.Drawing.Point(46, 19);
      this.GraphBox.Name = "GraphBox";
      this.GraphBox.Size = new System.Drawing.Size(449, 222);
      this.GraphBox.TabIndex = 3;
      this.GraphBox.TabStop = false;
      // 
      // OneSecTimer
      // 
      this.OneSecTimer.Enabled = true;
      this.OneSecTimer.Interval = 1000;
      this.OneSecTimer.Tick += new System.EventHandler(this.OneSecTimer_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(534, 311);
      this.Controls.Add(this.PrimaryTabControl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(500, 200);
      this.Name = "MainForm";
      this.Text = "Time Check";
      this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.PrimaryTabControl.ResumeLayout(false);
      this.CurrentTasksTab.ResumeLayout(false);
      this.CurrentTasksTab.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GraphBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl PrimaryTabControl;
    private System.Windows.Forms.TabPage CurrentTasksTab;
    private System.Windows.Forms.Button CompleteButton;
    private System.Windows.Forms.ListBox PrimaryList;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Timer OneSecTimer;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox GraphBox;
    private System.Windows.Forms.ListBox HistoryList;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label timerHUD;
    private System.Windows.Forms.Button AutoTimeButton;
    private System.Windows.Forms.Button EditButton;
    private System.Windows.Forms.Label GenericLabel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button ClearAllButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
  }
}

