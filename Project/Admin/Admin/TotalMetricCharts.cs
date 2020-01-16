using Backend.Base.Admin;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class TotalMetricCharts : UserControl
	{
		public TotalMetricCharts()
		{
			InitializeComponent();
		}

		public void SetMetric(GetTotalMetricsRes Metric)
		{
			upTimeLabel.Text = string.Format(upTimeLabel.Tag.ToString(), TimeSpan.FromSeconds(Metric.UpTime).ToString(Configurations.UP_TIME_FORMAT));
			cpuUsageLabel.Text = string.Format(cpuUsageLabel.Tag.ToString(), (int)(Metric.CPUUsage * 100));
			memoryUsageLabel.Text = string.Format(memoryUsageLabel.Tag.ToString(), (int)(Metric.MemoryUsage * 100));

			Metric totalMetric = Metric.TotalMetric;

			incomingTrafficLabel.Text = string.Format(incomingTrafficLabel.Tag.ToString(), totalMetric.IncomingTraffic);
			outgoingTrafficLabel.Text = string.Format(outgoingTrafficLabel.Tag.ToString(), totalMetric.OutgoingTraffic);

			ccuLabel.Text = string.Format(ccuLabel.Tag.ToString(), totalMetric.ClientCount);

			incomingMessageLabel.Text = string.Format(incomingMessageLabel.Tag.ToString(), totalMetric.IncomingMessageCount);
			outgoingMessageLabel.Text = string.Format(outgoingMessageLabel.Tag.ToString(), totalMetric.OutgoingMessageCount);
			incomingInvalidMessageLabel.Text = string.Format(incomingInvalidMessageLabel.Tag.ToString(), totalMetric.IncomingInvalidMessageCount);
			incomingFailedMessageLabel.Text = string.Format(incomingFailedMessageLabel.Tag.ToString(), totalMetric.IncomingFailedMessageCount);

			averageProcessTimeLabel.Text = string.Format(averageProcessTimeLabel.Tag.ToString(), totalMetric.AverageProcessTime);
		}
	}
}
