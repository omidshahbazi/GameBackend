namespace Backend.Admin
{
	partial class TotalMetricCharts
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			this.upTimeLabel = new System.Windows.Forms.Label();
			this.cpuUsageLabel = new System.Windows.Forms.Label();
			this.memoryUsageLabel = new System.Windows.Forms.Label();
			this.incomingTrafficLabel = new System.Windows.Forms.Label();
			this.outgoingTrafficLabel = new System.Windows.Forms.Label();
			this.ccuLabel = new System.Windows.Forms.Label();
			this.outgoingMessageLabel = new System.Windows.Forms.Label();
			this.incomingMessageLabel = new System.Windows.Forms.Label();
			this.incomingFailedMessageLabel = new System.Windows.Forms.Label();
			this.incomingInvalidMessageLabel = new System.Windows.Forms.Label();
			this.averageProcessTimeLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.trafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.ccuChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.messageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.cpuChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.memoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trafficChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ccuChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.messageChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cpuChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoryChart)).BeginInit();
			this.SuspendLayout();
			// 
			// upTimeLabel
			// 
			this.upTimeLabel.AutoSize = true;
			this.upTimeLabel.Location = new System.Drawing.Point(3, 3);
			this.upTimeLabel.Name = "upTimeLabel";
			this.upTimeLabel.Size = new System.Drawing.Size(67, 13);
			this.upTimeLabel.TabIndex = 0;
			this.upTimeLabel.Tag = "Up Time: {0}";
			this.upTimeLabel.Text = "Up Time: {0}";
			// 
			// cpuUsageLabel
			// 
			this.cpuUsageLabel.AutoSize = true;
			this.cpuUsageLabel.Location = new System.Drawing.Point(3, 21);
			this.cpuUsageLabel.Name = "cpuUsageLabel";
			this.cpuUsageLabel.Size = new System.Drawing.Size(91, 13);
			this.cpuUsageLabel.TabIndex = 1;
			this.cpuUsageLabel.Tag = "CPU Usage: {0}%";
			this.cpuUsageLabel.Text = "CPU Usage: {0}%";
			// 
			// memoryUsageLabel
			// 
			this.memoryUsageLabel.AutoSize = true;
			this.memoryUsageLabel.Location = new System.Drawing.Point(3, 39);
			this.memoryUsageLabel.Name = "memoryUsageLabel";
			this.memoryUsageLabel.Size = new System.Drawing.Size(106, 13);
			this.memoryUsageLabel.TabIndex = 2;
			this.memoryUsageLabel.Tag = "Memory Usage: {0}%";
			this.memoryUsageLabel.Text = "Memory Usage: {0}%";
			// 
			// incomingTrafficLabel
			// 
			this.incomingTrafficLabel.AutoSize = true;
			this.incomingTrafficLabel.Location = new System.Drawing.Point(3, 57);
			this.incomingTrafficLabel.Name = "incomingTrafficLabel";
			this.incomingTrafficLabel.Size = new System.Drawing.Size(109, 13);
			this.incomingTrafficLabel.TabIndex = 3;
			this.incomingTrafficLabel.Tag = "Incoming Traffic: {0}b";
			this.incomingTrafficLabel.Text = "Incoming Traffic: {0}b";
			// 
			// outgoingTrafficLabel
			// 
			this.outgoingTrafficLabel.AutoSize = true;
			this.outgoingTrafficLabel.Location = new System.Drawing.Point(3, 75);
			this.outgoingTrafficLabel.Name = "outgoingTrafficLabel";
			this.outgoingTrafficLabel.Size = new System.Drawing.Size(109, 13);
			this.outgoingTrafficLabel.TabIndex = 4;
			this.outgoingTrafficLabel.Tag = "Outgoing Traffic: {0}b";
			this.outgoingTrafficLabel.Text = "Outgoing Traffic: {0}b";
			// 
			// ccuLabel
			// 
			this.ccuLabel.AutoSize = true;
			this.ccuLabel.Location = new System.Drawing.Point(3, 93);
			this.ccuLabel.Name = "ccuLabel";
			this.ccuLabel.Size = new System.Drawing.Size(49, 13);
			this.ccuLabel.TabIndex = 5;
			this.ccuLabel.Tag = "CCU: {0}";
			this.ccuLabel.Text = "CCU: {0}";
			// 
			// outgoingMessageLabel
			// 
			this.outgoingMessageLabel.AutoSize = true;
			this.outgoingMessageLabel.Location = new System.Drawing.Point(3, 129);
			this.outgoingMessageLabel.Name = "outgoingMessageLabel";
			this.outgoingMessageLabel.Size = new System.Drawing.Size(116, 13);
			this.outgoingMessageLabel.TabIndex = 7;
			this.outgoingMessageLabel.Tag = "Outgoing Message: {0}";
			this.outgoingMessageLabel.Text = "Outgoing Message: {0}";
			// 
			// incomingMessageLabel
			// 
			this.incomingMessageLabel.AutoSize = true;
			this.incomingMessageLabel.Location = new System.Drawing.Point(3, 111);
			this.incomingMessageLabel.Name = "incomingMessageLabel";
			this.incomingMessageLabel.Size = new System.Drawing.Size(116, 13);
			this.incomingMessageLabel.TabIndex = 6;
			this.incomingMessageLabel.Tag = "Incoming Message: {0}";
			this.incomingMessageLabel.Text = "Incoming Message: {0}";
			// 
			// incomingFailedMessageLabel
			// 
			this.incomingFailedMessageLabel.AutoSize = true;
			this.incomingFailedMessageLabel.Location = new System.Drawing.Point(3, 165);
			this.incomingFailedMessageLabel.Name = "incomingFailedMessageLabel";
			this.incomingFailedMessageLabel.Size = new System.Drawing.Size(147, 13);
			this.incomingFailedMessageLabel.TabIndex = 9;
			this.incomingFailedMessageLabel.Tag = "Incoming Failed Message: {0}";
			this.incomingFailedMessageLabel.Text = "Incoming Failed Message: {0}";
			// 
			// incomingInvalidMessageLabel
			// 
			this.incomingInvalidMessageLabel.AutoSize = true;
			this.incomingInvalidMessageLabel.Location = new System.Drawing.Point(3, 147);
			this.incomingInvalidMessageLabel.Name = "incomingInvalidMessageLabel";
			this.incomingInvalidMessageLabel.Size = new System.Drawing.Size(150, 13);
			this.incomingInvalidMessageLabel.TabIndex = 8;
			this.incomingInvalidMessageLabel.Tag = "Incoming Invalid Message: {0}";
			this.incomingInvalidMessageLabel.Text = "Incoming Invalid Message: {0}";
			// 
			// averageProcessTimeLabel
			// 
			this.averageProcessTimeLabel.AutoSize = true;
			this.averageProcessTimeLabel.Location = new System.Drawing.Point(3, 183);
			this.averageProcessTimeLabel.Name = "averageProcessTimeLabel";
			this.averageProcessTimeLabel.Size = new System.Drawing.Size(139, 13);
			this.averageProcessTimeLabel.TabIndex = 10;
			this.averageProcessTimeLabel.Tag = "Average Process Time: {0}s";
			this.averageProcessTimeLabel.Text = "Average Process Time: {0}s";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.memoryChart, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.cpuChart, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.messageChart, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.trafficChart, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.ccuChart, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 205F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 728);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.upTimeLabel);
			this.panel1.Controls.Add(this.cpuUsageLabel);
			this.panel1.Controls.Add(this.averageProcessTimeLabel);
			this.panel1.Controls.Add(this.memoryUsageLabel);
			this.panel1.Controls.Add(this.incomingFailedMessageLabel);
			this.panel1.Controls.Add(this.incomingTrafficLabel);
			this.panel1.Controls.Add(this.incomingInvalidMessageLabel);
			this.panel1.Controls.Add(this.outgoingTrafficLabel);
			this.panel1.Controls.Add(this.outgoingMessageLabel);
			this.panel1.Controls.Add(this.ccuLabel);
			this.panel1.Controls.Add(this.incomingMessageLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(457, 199);
			this.panel1.TabIndex = 12;
			// 
			// trafficChart
			// 
			chartArea4.Name = "ChartArea1";
			this.trafficChart.ChartAreas.Add(chartArea4);
			this.trafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend4.Name = "Legend1";
			this.trafficChart.Legends.Add(legend4);
			this.trafficChart.Location = new System.Drawing.Point(466, 3);
			this.trafficChart.Name = "trafficChart";
			this.trafficChart.Size = new System.Drawing.Size(457, 199);
			this.trafficChart.TabIndex = 13;
			this.trafficChart.Text = "chart1";
			// 
			// ccuChart
			// 
			chartArea5.Name = "ChartArea1";
			this.ccuChart.ChartAreas.Add(chartArea5);
			this.ccuChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend5.Name = "Legend1";
			this.ccuChart.Legends.Add(legend5);
			this.ccuChart.Location = new System.Drawing.Point(3, 208);
			this.ccuChart.Name = "ccuChart";
			this.ccuChart.Size = new System.Drawing.Size(457, 255);
			this.ccuChart.TabIndex = 14;
			this.ccuChart.Text = "chart2";
			// 
			// messageChart
			// 
			chartArea3.Name = "ChartArea1";
			this.messageChart.ChartAreas.Add(chartArea3);
			this.messageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend3.Name = "Legend1";
			this.messageChart.Legends.Add(legend3);
			this.messageChart.Location = new System.Drawing.Point(466, 208);
			this.messageChart.Name = "messageChart";
			this.messageChart.Size = new System.Drawing.Size(457, 255);
			this.messageChart.TabIndex = 15;
			this.messageChart.Text = "chart3";
			// 
			// cpuChart
			// 
			chartArea2.Name = "ChartArea1";
			this.cpuChart.ChartAreas.Add(chartArea2);
			this.cpuChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend2.Name = "Legend1";
			this.cpuChart.Legends.Add(legend2);
			this.cpuChart.Location = new System.Drawing.Point(3, 469);
			this.cpuChart.Name = "cpuChart";
			this.cpuChart.Size = new System.Drawing.Size(457, 256);
			this.cpuChart.TabIndex = 16;
			this.cpuChart.Text = "chart4";
			// 
			// memoryChart
			// 
			chartArea1.Name = "ChartArea1";
			this.memoryChart.ChartAreas.Add(chartArea1);
			this.memoryChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.memoryChart.Legends.Add(legend1);
			this.memoryChart.Location = new System.Drawing.Point(466, 469);
			this.memoryChart.Name = "memoryChart";
			this.memoryChart.Size = new System.Drawing.Size(457, 256);
			this.memoryChart.TabIndex = 17;
			this.memoryChart.Text = "chart5";
			// 
			// TotalMetricCharts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "TotalMetricCharts";
			this.Size = new System.Drawing.Size(926, 728);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trafficChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ccuChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.messageChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cpuChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoryChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label upTimeLabel;
		private System.Windows.Forms.Label cpuUsageLabel;
		private System.Windows.Forms.Label memoryUsageLabel;
		private System.Windows.Forms.Label incomingTrafficLabel;
		private System.Windows.Forms.Label outgoingTrafficLabel;
		private System.Windows.Forms.Label ccuLabel;
		private System.Windows.Forms.Label outgoingMessageLabel;
		private System.Windows.Forms.Label incomingMessageLabel;
		private System.Windows.Forms.Label incomingFailedMessageLabel;
		private System.Windows.Forms.Label incomingInvalidMessageLabel;
		private System.Windows.Forms.Label averageProcessTimeLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart memoryChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart cpuChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart messageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart trafficChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart ccuChart;
	}
}
