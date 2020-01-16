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
			this.SuspendLayout();
			// 
			// upTimeLabel
			// 
			this.upTimeLabel.AutoSize = true;
			this.upTimeLabel.Location = new System.Drawing.Point(3, 2);
			this.upTimeLabel.Name = "upTimeLabel";
			this.upTimeLabel.Size = new System.Drawing.Size(67, 13);
			this.upTimeLabel.TabIndex = 0;
			this.upTimeLabel.Tag = "Up Time: {0}";
			this.upTimeLabel.Text = "Up Time: {0}";
			// 
			// cpuUsageLabel
			// 
			this.cpuUsageLabel.AutoSize = true;
			this.cpuUsageLabel.Location = new System.Drawing.Point(3, 20);
			this.cpuUsageLabel.Name = "cpuUsageLabel";
			this.cpuUsageLabel.Size = new System.Drawing.Size(91, 13);
			this.cpuUsageLabel.TabIndex = 1;
			this.cpuUsageLabel.Tag = "CPU Usage: {0}%";
			this.cpuUsageLabel.Text = "CPU Usage: {0}%";
			// 
			// memoryUsageLabel
			// 
			this.memoryUsageLabel.AutoSize = true;
			this.memoryUsageLabel.Location = new System.Drawing.Point(3, 38);
			this.memoryUsageLabel.Name = "memoryUsageLabel";
			this.memoryUsageLabel.Size = new System.Drawing.Size(106, 13);
			this.memoryUsageLabel.TabIndex = 2;
			this.memoryUsageLabel.Tag = "Memory Usage: {0}%";
			this.memoryUsageLabel.Text = "Memory Usage: {0}%";
			// 
			// incomingTrafficLabel
			// 
			this.incomingTrafficLabel.AutoSize = true;
			this.incomingTrafficLabel.Location = new System.Drawing.Point(3, 56);
			this.incomingTrafficLabel.Name = "incomingTrafficLabel";
			this.incomingTrafficLabel.Size = new System.Drawing.Size(109, 13);
			this.incomingTrafficLabel.TabIndex = 3;
			this.incomingTrafficLabel.Tag = "Incoming Traffic: {0}b";
			this.incomingTrafficLabel.Text = "Incoming Traffic: {0}b";
			// 
			// outgoingTrafficLabel
			// 
			this.outgoingTrafficLabel.AutoSize = true;
			this.outgoingTrafficLabel.Location = new System.Drawing.Point(3, 74);
			this.outgoingTrafficLabel.Name = "outgoingTrafficLabel";
			this.outgoingTrafficLabel.Size = new System.Drawing.Size(109, 13);
			this.outgoingTrafficLabel.TabIndex = 4;
			this.outgoingTrafficLabel.Tag = "Outgoing Traffic: {0}b";
			this.outgoingTrafficLabel.Text = "Outgoing Traffic: {0}b";
			// 
			// ccuLabel
			// 
			this.ccuLabel.AutoSize = true;
			this.ccuLabel.Location = new System.Drawing.Point(3, 92);
			this.ccuLabel.Name = "ccuLabel";
			this.ccuLabel.Size = new System.Drawing.Size(49, 13);
			this.ccuLabel.TabIndex = 5;
			this.ccuLabel.Tag = "CCU: {0}";
			this.ccuLabel.Text = "CCU: {0}";
			// 
			// outgoingMessageLabel
			// 
			this.outgoingMessageLabel.AutoSize = true;
			this.outgoingMessageLabel.Location = new System.Drawing.Point(3, 128);
			this.outgoingMessageLabel.Name = "outgoingMessageLabel";
			this.outgoingMessageLabel.Size = new System.Drawing.Size(116, 13);
			this.outgoingMessageLabel.TabIndex = 7;
			this.outgoingMessageLabel.Tag = "Outgoing Message: {0}";
			this.outgoingMessageLabel.Text = "Outgoing Message: {0}";
			// 
			// incomingMessageLabel
			// 
			this.incomingMessageLabel.AutoSize = true;
			this.incomingMessageLabel.Location = new System.Drawing.Point(3, 110);
			this.incomingMessageLabel.Name = "incomingMessageLabel";
			this.incomingMessageLabel.Size = new System.Drawing.Size(116, 13);
			this.incomingMessageLabel.TabIndex = 6;
			this.incomingMessageLabel.Tag = "Incoming Message: {0}";
			this.incomingMessageLabel.Text = "Incoming Message: {0}";
			// 
			// incomingFailedMessageLabel
			// 
			this.incomingFailedMessageLabel.AutoSize = true;
			this.incomingFailedMessageLabel.Location = new System.Drawing.Point(3, 164);
			this.incomingFailedMessageLabel.Name = "incomingFailedMessageLabel";
			this.incomingFailedMessageLabel.Size = new System.Drawing.Size(147, 13);
			this.incomingFailedMessageLabel.TabIndex = 9;
			this.incomingFailedMessageLabel.Tag = "Incoming Failed Message: {0}";
			this.incomingFailedMessageLabel.Text = "Incoming Failed Message: {0}";
			// 
			// incomingInvalidMessageLabel
			// 
			this.incomingInvalidMessageLabel.AutoSize = true;
			this.incomingInvalidMessageLabel.Location = new System.Drawing.Point(3, 146);
			this.incomingInvalidMessageLabel.Name = "incomingInvalidMessageLabel";
			this.incomingInvalidMessageLabel.Size = new System.Drawing.Size(150, 13);
			this.incomingInvalidMessageLabel.TabIndex = 8;
			this.incomingInvalidMessageLabel.Tag = "Incoming Invalid Message: {0}";
			this.incomingInvalidMessageLabel.Text = "Incoming Invalid Message: {0}";
			// 
			// averageProcessTimeLabel
			// 
			this.averageProcessTimeLabel.AutoSize = true;
			this.averageProcessTimeLabel.Location = new System.Drawing.Point(3, 182);
			this.averageProcessTimeLabel.Name = "averageProcessTimeLabel";
			this.averageProcessTimeLabel.Size = new System.Drawing.Size(139, 13);
			this.averageProcessTimeLabel.TabIndex = 10;
			this.averageProcessTimeLabel.Tag = "Average Process Time: {0}s";
			this.averageProcessTimeLabel.Text = "Average Process Time: {0}s";
			// 
			// TotalMetricCharts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.averageProcessTimeLabel);
			this.Controls.Add(this.incomingFailedMessageLabel);
			this.Controls.Add(this.incomingInvalidMessageLabel);
			this.Controls.Add(this.outgoingMessageLabel);
			this.Controls.Add(this.incomingMessageLabel);
			this.Controls.Add(this.ccuLabel);
			this.Controls.Add(this.outgoingTrafficLabel);
			this.Controls.Add(this.incomingTrafficLabel);
			this.Controls.Add(this.memoryUsageLabel);
			this.Controls.Add(this.cpuUsageLabel);
			this.Controls.Add(this.upTimeLabel);
			this.Name = "TotalMetricCharts";
			this.Size = new System.Drawing.Size(349, 332);
			this.ResumeLayout(false);
			this.PerformLayout();

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
	}
}
