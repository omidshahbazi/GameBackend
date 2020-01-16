namespace Backend.Admin
{
	partial class AdminForm
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
			this.mainTab = new System.Windows.Forms.TabControl();
			this.dashboardTab = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.updateIntervalBox = new System.Windows.Forms.ComboBox();
			this.fileManagerTab = new System.Windows.Forms.TabPage();
			this.totalMetricCharts1 = new Backend.Admin.TotalMetricCharts();
			this.messagesStasButton = new System.Windows.Forms.Button();
			this.socketsStatsButton = new System.Windows.Forms.Button();
			this.mainTab.SuspendLayout();
			this.dashboardTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTab
			// 
			this.mainTab.Controls.Add(this.dashboardTab);
			this.mainTab.Controls.Add(this.fileManagerTab);
			this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTab.Location = new System.Drawing.Point(0, 0);
			this.mainTab.Name = "mainTab";
			this.mainTab.SelectedIndex = 0;
			this.mainTab.Size = new System.Drawing.Size(1008, 729);
			this.mainTab.TabIndex = 0;
			// 
			// dashboardTab
			// 
			this.dashboardTab.BackColor = System.Drawing.SystemColors.Control;
			this.dashboardTab.Controls.Add(this.socketsStatsButton);
			this.dashboardTab.Controls.Add(this.messagesStasButton);
			this.dashboardTab.Controls.Add(this.label1);
			this.dashboardTab.Controls.Add(this.updateIntervalBox);
			this.dashboardTab.Controls.Add(this.totalMetricCharts1);
			this.dashboardTab.Location = new System.Drawing.Point(4, 22);
			this.dashboardTab.Name = "dashboardTab";
			this.dashboardTab.Size = new System.Drawing.Size(1000, 703);
			this.dashboardTab.TabIndex = 0;
			this.dashboardTab.Text = "Dashboard";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Update Interval:";
			// 
			// updateIntervalBox
			// 
			this.updateIntervalBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.updateIntervalBox.FormattingEnabled = true;
			this.updateIntervalBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "10",
            "20",
            "30",
            "60"});
			this.updateIntervalBox.Location = new System.Drawing.Point(95, 0);
			this.updateIntervalBox.Name = "updateIntervalBox";
			this.updateIntervalBox.Size = new System.Drawing.Size(50, 21);
			this.updateIntervalBox.TabIndex = 1;
			this.updateIntervalBox.SelectedIndexChanged += new System.EventHandler(this.UpdateInterval_SelectedIndexChanged);
			// 
			// fileManagerTab
			// 
			this.fileManagerTab.BackColor = System.Drawing.SystemColors.Control;
			this.fileManagerTab.Location = new System.Drawing.Point(4, 22);
			this.fileManagerTab.Name = "fileManagerTab";
			this.fileManagerTab.Size = new System.Drawing.Size(1000, 703);
			this.fileManagerTab.TabIndex = 1;
			this.fileManagerTab.Text = "File Manager";
			// 
			// totalMetricCharts1
			// 
			this.totalMetricCharts1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.totalMetricCharts1.Location = new System.Drawing.Point(0, 23);
			this.totalMetricCharts1.Name = "totalMetricCharts1";
			this.totalMetricCharts1.Size = new System.Drawing.Size(1000, 680);
			this.totalMetricCharts1.TabIndex = 0;
			// 
			// messagesStasButton
			// 
			this.messagesStasButton.Location = new System.Drawing.Point(844, 0);
			this.messagesStasButton.Name = "messagesStasButton";
			this.messagesStasButton.Size = new System.Drawing.Size(75, 21);
			this.messagesStasButton.TabIndex = 3;
			this.messagesStasButton.Text = "Messages";
			this.messagesStasButton.UseVisualStyleBackColor = true;
			this.messagesStasButton.Click += new System.EventHandler(this.MessagesStasButton_Click);
			// 
			// socketsStatsButton
			// 
			this.socketsStatsButton.Location = new System.Drawing.Point(925, 0);
			this.socketsStatsButton.Name = "socketsStatsButton";
			this.socketsStatsButton.Size = new System.Drawing.Size(75, 21);
			this.socketsStatsButton.TabIndex = 4;
			this.socketsStatsButton.Text = "Sockets";
			this.socketsStatsButton.UseVisualStyleBackColor = true;
			this.socketsStatsButton.Click += new System.EventHandler(this.SocketsStatsButton_Click);
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.mainTab);
			this.MinimumSize = new System.Drawing.Size(1024, 768);
			this.Name = "AdminForm";
			this.ShowIcon = false;
			this.Text = "Backend Admin";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.mainTab.ResumeLayout(false);
			this.dashboardTab.ResumeLayout(false);
			this.dashboardTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl mainTab;
		private System.Windows.Forms.TabPage dashboardTab;
		private System.Windows.Forms.TabPage fileManagerTab;
		private TotalMetricCharts totalMetricCharts1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox updateIntervalBox;
		private System.Windows.Forms.Button socketsStatsButton;
		private System.Windows.Forms.Button messagesStasButton;
	}
}