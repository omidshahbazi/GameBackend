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
			this.fileManagerTab = new System.Windows.Forms.TabPage();
			this.totalMetricCharts1 = new Backend.Admin.TotalMetricCharts();
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
			this.mainTab.Size = new System.Drawing.Size(912, 527);
			this.mainTab.TabIndex = 0;
			// 
			// dashboardTab
			// 
			this.dashboardTab.BackColor = System.Drawing.SystemColors.Control;
			this.dashboardTab.Controls.Add(this.totalMetricCharts1);
			this.dashboardTab.Location = new System.Drawing.Point(4, 22);
			this.dashboardTab.Name = "dashboardTab";
			this.dashboardTab.Size = new System.Drawing.Size(904, 501);
			this.dashboardTab.TabIndex = 0;
			this.dashboardTab.Text = "Dashboard";
			// 
			// fileManagerTab
			// 
			this.fileManagerTab.BackColor = System.Drawing.SystemColors.Control;
			this.fileManagerTab.Location = new System.Drawing.Point(4, 22);
			this.fileManagerTab.Name = "fileManagerTab";
			this.fileManagerTab.Size = new System.Drawing.Size(904, 501);
			this.fileManagerTab.TabIndex = 1;
			this.fileManagerTab.Text = "File Manager";
			// 
			// totalMetricCharts1
			// 
			this.totalMetricCharts1.Location = new System.Drawing.Point(0, 0);
			this.totalMetricCharts1.Name = "totalMetricCharts1";
			this.totalMetricCharts1.Size = new System.Drawing.Size(349, 332);
			this.totalMetricCharts1.TabIndex = 0;
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 527);
			this.Controls.Add(this.mainTab);
			this.Name = "AdminForm";
			this.ShowIcon = false;
			this.Text = "Backend Admin";
			this.mainTab.ResumeLayout(false);
			this.dashboardTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl mainTab;
		private System.Windows.Forms.TabPage dashboardTab;
		private System.Windows.Forms.TabPage fileManagerTab;
		private TotalMetricCharts totalMetricCharts1;
	}
}