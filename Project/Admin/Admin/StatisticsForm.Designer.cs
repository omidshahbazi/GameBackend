namespace Backend.Admin
{
	partial class StatisticsForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			this.cpuUsageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.memoryUsageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.cpuUsageChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoryUsageChart)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.mainTableLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// cpuUsageChart
			// 
			this.cpuUsageChart.BackColor = System.Drawing.SystemColors.Control;
			this.cpuUsageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.cpuUsageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea1.Name = "ChartArea1";
			this.cpuUsageChart.ChartAreas.Add(chartArea1);
			this.cpuUsageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cpuUsageChart.Location = new System.Drawing.Point(3, 3);
			this.cpuUsageChart.Name = "cpuUsageChart";
			this.cpuUsageChart.Size = new System.Drawing.Size(541, 693);
			this.cpuUsageChart.TabIndex = 0;
			// 
			// memoryUsageChart
			// 
			this.memoryUsageChart.BackColor = System.Drawing.SystemColors.Control;
			this.memoryUsageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.memoryUsageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea2.Name = "ChartArea1";
			this.memoryUsageChart.ChartAreas.Add(chartArea2);
			this.memoryUsageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoryUsageChart.Location = new System.Drawing.Point(550, 3);
			this.memoryUsageChart.Name = "memoryUsageChart";
			this.memoryUsageChart.Size = new System.Drawing.Size(541, 693);
			this.memoryUsageChart.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.memoryUsageChart, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.cpuUsageChart, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.40052F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1094, 699);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// mainTableLayout
			// 
			this.mainTableLayout.ColumnCount = 1;
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayout.Name = "mainTableLayout";
			this.mainTableLayout.RowCount = 1;
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F));
			this.mainTableLayout.Size = new System.Drawing.Size(1100, 705);
			this.mainTableLayout.TabIndex = 4;
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1100, 705);
			this.Controls.Add(this.mainTableLayout);
			this.Name = "StatisticsForm";
			this.Text = "StatisticsForm";
			((System.ComponentModel.ISupportInitialize)(this.cpuUsageChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoryUsageChart)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.mainTableLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart cpuUsageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart memoryUsageChart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel mainTableLayout;
	}
}