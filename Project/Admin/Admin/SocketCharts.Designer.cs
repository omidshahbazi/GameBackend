namespace Backend.Admin
{
	partial class SocketCharts
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.incomingInvalidMessageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.incomingFailedMessageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.outgoingMessageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.incomingMessageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.infoLabel2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.outgoingTrafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.incomingTrafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.ccuChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.infoLabel1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.incomingInvalidMessageChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.incomingFailedMessageChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.outgoingMessageChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.incomingMessageChart)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.outgoingTrafficChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.incomingTrafficChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ccuChart)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.incomingInvalidMessageChart, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.incomingFailedMessageChart, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.outgoingMessageChart, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.incomingMessageChart, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(871, 63);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(863, 497);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// incomingInvalidMessageChart
			// 
			this.incomingInvalidMessageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.incomingInvalidMessageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea1.Name = "ChartArea1";
			this.incomingInvalidMessageChart.ChartAreas.Add(chartArea1);
			this.incomingInvalidMessageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incomingInvalidMessageChart.Location = new System.Drawing.Point(3, 251);
			this.incomingInvalidMessageChart.Name = "incomingInvalidMessageChart";
			this.incomingInvalidMessageChart.Size = new System.Drawing.Size(425, 243);
			this.incomingInvalidMessageChart.TabIndex = 5;
			// 
			// incomingFailedMessageChart
			// 
			this.incomingFailedMessageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.incomingFailedMessageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea2.Name = "ChartArea1";
			this.incomingFailedMessageChart.ChartAreas.Add(chartArea2);
			this.incomingFailedMessageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incomingFailedMessageChart.Location = new System.Drawing.Point(434, 251);
			this.incomingFailedMessageChart.Name = "incomingFailedMessageChart";
			this.incomingFailedMessageChart.Size = new System.Drawing.Size(426, 243);
			this.incomingFailedMessageChart.TabIndex = 4;
			// 
			// outgoingMessageChart
			// 
			this.outgoingMessageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.outgoingMessageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea3.Name = "ChartArea1";
			this.outgoingMessageChart.ChartAreas.Add(chartArea3);
			this.outgoingMessageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outgoingMessageChart.Location = new System.Drawing.Point(434, 3);
			this.outgoingMessageChart.Name = "outgoingMessageChart";
			this.outgoingMessageChart.Size = new System.Drawing.Size(426, 242);
			this.outgoingMessageChart.TabIndex = 3;
			// 
			// incomingMessageChart
			// 
			this.incomingMessageChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.incomingMessageChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea4.Name = "ChartArea1";
			this.incomingMessageChart.ChartAreas.Add(chartArea4);
			this.incomingMessageChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incomingMessageChart.Location = new System.Drawing.Point(3, 3);
			this.incomingMessageChart.Name = "incomingMessageChart";
			this.incomingMessageChart.Size = new System.Drawing.Size(425, 242);
			this.incomingMessageChart.TabIndex = 4;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.infoLabel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.infoLabel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1737, 563);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// infoLabel2
			// 
			this.infoLabel2.AutoSize = true;
			this.infoLabel2.Location = new System.Drawing.Point(871, 0);
			this.infoLabel2.Name = "infoLabel2";
			this.infoLabel2.Size = new System.Drawing.Size(150, 52);
			this.infoLabel2.TabIndex = 4;
			this.infoLabel2.Tag = "";
			this.infoLabel2.Text = "Incoming Message: {0}\r\nOutgoing Traffic: {1}\r\nIncoming Invalid Message: {2}\r\nInco" +
    "ming Failed Message: {3}";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.outgoingTrafficChart, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.incomingTrafficChart, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.ccuChart, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 63);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(862, 497);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// outgoingTrafficChart
			// 
			this.outgoingTrafficChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.outgoingTrafficChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea5.Name = "ChartArea1";
			this.outgoingTrafficChart.ChartAreas.Add(chartArea5);
			this.outgoingTrafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outgoingTrafficChart.Location = new System.Drawing.Point(3, 333);
			this.outgoingTrafficChart.Name = "outgoingTrafficChart";
			this.outgoingTrafficChart.Size = new System.Drawing.Size(856, 161);
			this.outgoingTrafficChart.TabIndex = 7;
			// 
			// incomingTrafficChart
			// 
			this.incomingTrafficChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.incomingTrafficChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea6.Name = "ChartArea1";
			this.incomingTrafficChart.ChartAreas.Add(chartArea6);
			this.incomingTrafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incomingTrafficChart.Location = new System.Drawing.Point(3, 168);
			this.incomingTrafficChart.Name = "incomingTrafficChart";
			this.incomingTrafficChart.Size = new System.Drawing.Size(856, 159);
			this.incomingTrafficChart.TabIndex = 6;
			// 
			// ccuChart
			// 
			this.ccuChart.BorderlineColor = System.Drawing.Color.DarkGray;
			this.ccuChart.BorderSkin.BackColor = System.Drawing.Color.Silver;
			chartArea7.Name = "ChartArea1";
			this.ccuChart.ChartAreas.Add(chartArea7);
			this.ccuChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ccuChart.Location = new System.Drawing.Point(3, 3);
			this.ccuChart.Name = "ccuChart";
			this.ccuChart.Size = new System.Drawing.Size(856, 159);
			this.ccuChart.TabIndex = 5;
			// 
			// infoLabel1
			// 
			this.infoLabel1.AutoSize = true;
			this.infoLabel1.Location = new System.Drawing.Point(3, 0);
			this.infoLabel1.Name = "infoLabel1";
			this.infoLabel1.Size = new System.Drawing.Size(103, 52);
			this.infoLabel1.TabIndex = 3;
			this.infoLabel1.Tag = "";
			this.infoLabel1.Text = "Socket: {0}\r\nCCU : {1}\r\nIncoming Traffic: {2}\r\nOutgoing Traffic: {3}";
			// 
			// SocketCharts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SocketCharts";
			this.Size = new System.Drawing.Size(1737, 563);
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.incomingInvalidMessageChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.incomingFailedMessageChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.outgoingMessageChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.incomingMessageChart)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.outgoingTrafficChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.incomingTrafficChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ccuChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.DataVisualization.Charting.Chart incomingInvalidMessageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart incomingFailedMessageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart outgoingMessageChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart incomingMessageChart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.DataVisualization.Charting.Chart incomingTrafficChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart ccuChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart outgoingTrafficChart;
		private System.Windows.Forms.Label infoLabel1;
		private System.Windows.Forms.Label infoLabel2;
	}
}
