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
			this.cpuUsageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.cpuUsageChart)).BeginInit();
			this.SuspendLayout();
			// 
			// cpuUsageChart
			// 
			chartArea1.Name = "ChartArea1";
			this.cpuUsageChart.ChartAreas.Add(chartArea1);
			this.cpuUsageChart.Location = new System.Drawing.Point(159, 126);
			this.cpuUsageChart.Name = "cpuUsageChart";
			this.cpuUsageChart.Size = new System.Drawing.Size(300, 300);
			this.cpuUsageChart.TabIndex = 0;
			// 
			// StatisticsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cpuUsageChart);
			this.Name = "StatisticsForm";
			this.Text = "StatisticsForm";
			((System.ComponentModel.ISupportInitialize)(this.cpuUsageChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart cpuUsageChart;
	}
}