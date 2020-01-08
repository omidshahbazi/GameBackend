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
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.cpuUsageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.cpuUsageChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// cpuUsageChart
			// 
			this.cpuUsageChart.BackColor = System.Drawing.SystemColors.Control;
			this.cpuUsageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.cpuUsageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea1.Name = "ChartArea1";
			this.cpuUsageChart.ChartAreas.Add(chartArea1);
			this.cpuUsageChart.Location = new System.Drawing.Point(12, 12);
			this.cpuUsageChart.Name = "cpuUsageChart";
			this.cpuUsageChart.Size = new System.Drawing.Size(300, 300);
			this.cpuUsageChart.TabIndex = 0;
			// 
			// chart1
			// 
			chartArea2.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea2);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(354, 75);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(300, 300);
			this.chart1.TabIndex = 1;
			this.chart1.Text = "chart1";
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.cpuUsageChart);
			this.Name = "StatisticsForm";
			this.Text = "StatisticsForm";
			((System.ComponentModel.ISupportInitialize)(this.cpuUsageChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart cpuUsageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}