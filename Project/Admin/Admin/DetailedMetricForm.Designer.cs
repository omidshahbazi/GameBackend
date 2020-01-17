namespace Backend.Admin
{
	partial class DetailedMetricForm
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
			this.detailsList = new System.Windows.Forms.ListBox();
			this.detailedMetricCharts1 = new Backend.Admin.DetailedMetricCharts();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// detailsList
			// 
			this.detailsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailsList.FormattingEnabled = true;
			this.detailsList.Location = new System.Drawing.Point(3, 3);
			this.detailsList.Name = "detailsList";
			this.detailsList.Size = new System.Drawing.Size(261, 723);
			this.detailsList.TabIndex = 0;
			this.detailsList.SelectedIndexChanged += new System.EventHandler(this.DetailsList_SelectedIndexChanged);
			// 
			// detailedMetricCharts1
			// 
			this.detailedMetricCharts1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detailedMetricCharts1.Location = new System.Drawing.Point(270, 3);
			this.detailedMetricCharts1.Name = "detailedMetricCharts1";
			this.detailedMetricCharts1.Size = new System.Drawing.Size(735, 723);
			this.detailedMetricCharts1.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.detailsList, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.detailedMetricCharts1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 729);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// DetailedMetricForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(1024, 768);
			this.Name = "DetailedMetricForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Details";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox detailsList;
		private DetailedMetricCharts detailedMetricCharts1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}