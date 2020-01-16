namespace Backend.Admin
{
	partial class DetailedMetricCharts
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			this.incomingTrafficLabel = new System.Windows.Forms.Label();
			this.outgoingTrafficLabel = new System.Windows.Forms.Label();
			this.outgoingMessageLabel = new System.Windows.Forms.Label();
			this.incomingMessageLabel = new System.Windows.Forms.Label();
			this.incomingFailedMessageLabel = new System.Windows.Forms.Label();
			this.incomingInvalidMessageLabel = new System.Windows.Forms.Label();
			this.averageProcessTimeLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.messageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel1 = new System.Windows.Forms.Panel();
			this.trafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.messageChart)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trafficChart)).BeginInit();
			this.SuspendLayout();
			// 
			// incomingTrafficLabel
			// 
			this.incomingTrafficLabel.AutoSize = true;
			this.incomingTrafficLabel.Location = new System.Drawing.Point(3, 3);
			this.incomingTrafficLabel.Name = "incomingTrafficLabel";
			this.incomingTrafficLabel.Size = new System.Drawing.Size(109, 13);
			this.incomingTrafficLabel.TabIndex = 3;
			this.incomingTrafficLabel.Tag = "Incoming Traffic: {0}b";
			this.incomingTrafficLabel.Text = "Incoming Traffic: {0}b";
			// 
			// outgoingTrafficLabel
			// 
			this.outgoingTrafficLabel.AutoSize = true;
			this.outgoingTrafficLabel.Location = new System.Drawing.Point(3, 21);
			this.outgoingTrafficLabel.Name = "outgoingTrafficLabel";
			this.outgoingTrafficLabel.Size = new System.Drawing.Size(109, 13);
			this.outgoingTrafficLabel.TabIndex = 4;
			this.outgoingTrafficLabel.Tag = "Outgoing Traffic: {0}b";
			this.outgoingTrafficLabel.Text = "Outgoing Traffic: {0}b";
			// 
			// outgoingMessageLabel
			// 
			this.outgoingMessageLabel.AutoSize = true;
			this.outgoingMessageLabel.Location = new System.Drawing.Point(3, 57);
			this.outgoingMessageLabel.Name = "outgoingMessageLabel";
			this.outgoingMessageLabel.Size = new System.Drawing.Size(116, 13);
			this.outgoingMessageLabel.TabIndex = 7;
			this.outgoingMessageLabel.Tag = "Outgoing Message: {0}";
			this.outgoingMessageLabel.Text = "Outgoing Message: {0}";
			// 
			// incomingMessageLabel
			// 
			this.incomingMessageLabel.AutoSize = true;
			this.incomingMessageLabel.Location = new System.Drawing.Point(3, 39);
			this.incomingMessageLabel.Name = "incomingMessageLabel";
			this.incomingMessageLabel.Size = new System.Drawing.Size(116, 13);
			this.incomingMessageLabel.TabIndex = 6;
			this.incomingMessageLabel.Tag = "Incoming Message: {0}";
			this.incomingMessageLabel.Text = "Incoming Message: {0}";
			// 
			// incomingFailedMessageLabel
			// 
			this.incomingFailedMessageLabel.AutoSize = true;
			this.incomingFailedMessageLabel.Location = new System.Drawing.Point(3, 93);
			this.incomingFailedMessageLabel.Name = "incomingFailedMessageLabel";
			this.incomingFailedMessageLabel.Size = new System.Drawing.Size(147, 13);
			this.incomingFailedMessageLabel.TabIndex = 9;
			this.incomingFailedMessageLabel.Tag = "Incoming Failed Message: {0}";
			this.incomingFailedMessageLabel.Text = "Incoming Failed Message: {0}";
			// 
			// incomingInvalidMessageLabel
			// 
			this.incomingInvalidMessageLabel.AutoSize = true;
			this.incomingInvalidMessageLabel.Location = new System.Drawing.Point(3, 75);
			this.incomingInvalidMessageLabel.Name = "incomingInvalidMessageLabel";
			this.incomingInvalidMessageLabel.Size = new System.Drawing.Size(150, 13);
			this.incomingInvalidMessageLabel.TabIndex = 8;
			this.incomingInvalidMessageLabel.Tag = "Incoming Invalid Message: {0}";
			this.incomingInvalidMessageLabel.Text = "Incoming Invalid Message: {0}";
			// 
			// averageProcessTimeLabel
			// 
			this.averageProcessTimeLabel.AutoSize = true;
			this.averageProcessTimeLabel.Location = new System.Drawing.Point(3, 111);
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
			this.tableLayoutPanel1.Controls.Add(this.messageChart, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.trafficChart, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 438);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// messageChart
			// 
			chartArea1.Name = "ChartArea1";
			this.messageChart.ChartAreas.Add(chartArea1);
			this.messageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.messageChart.Legends.Add(legend1);
			this.messageChart.Location = new System.Drawing.Point(466, 140);
			this.messageChart.Name = "messageChart";
			this.messageChart.Size = new System.Drawing.Size(457, 295);
			this.messageChart.TabIndex = 15;
			this.messageChart.Text = "chart3";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.averageProcessTimeLabel);
			this.panel1.Controls.Add(this.incomingFailedMessageLabel);
			this.panel1.Controls.Add(this.incomingTrafficLabel);
			this.panel1.Controls.Add(this.incomingInvalidMessageLabel);
			this.panel1.Controls.Add(this.outgoingTrafficLabel);
			this.panel1.Controls.Add(this.outgoingMessageLabel);
			this.panel1.Controls.Add(this.incomingMessageLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(457, 131);
			this.panel1.TabIndex = 12;
			// 
			// trafficChart
			// 
			chartArea2.Name = "ChartArea1";
			this.trafficChart.ChartAreas.Add(chartArea2);
			this.trafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend2.Name = "Legend1";
			this.trafficChart.Legends.Add(legend2);
			this.trafficChart.Location = new System.Drawing.Point(3, 140);
			this.trafficChart.Name = "trafficChart";
			this.trafficChart.Size = new System.Drawing.Size(457, 295);
			this.trafficChart.TabIndex = 13;
			this.trafficChart.Text = "chart1";
			// 
			// DetailedMetricCharts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DetailedMetricCharts";
			this.Size = new System.Drawing.Size(926, 438);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.messageChart)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trafficChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label incomingTrafficLabel;
		private System.Windows.Forms.Label outgoingTrafficLabel;
		private System.Windows.Forms.Label outgoingMessageLabel;
		private System.Windows.Forms.Label incomingMessageLabel;
		private System.Windows.Forms.Label incomingFailedMessageLabel;
		private System.Windows.Forms.Label incomingInvalidMessageLabel;
		private System.Windows.Forms.Label averageProcessTimeLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart messageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart trafficChart;
	}
}
