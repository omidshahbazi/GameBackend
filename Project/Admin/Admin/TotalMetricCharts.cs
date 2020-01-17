using Backend.Base.Admin;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	public partial class TotalMetricCharts : UserControl
	{
		private const string UP_TIME_FORMAT = @"%d\ \D\a\y\s\ hh\:mm";

		private GetTotalMetricsRes prevMetrics;

		private Series incomingTrafficSeries = null;
		private Series outgoingTrafficSeries = null;

		private Series ccuSeries = null;

		private Series incomingMessageSeries = null;
		private Series outgoingMessageSeries = null;
		private Series incomingInvalidMessageSeries = null;
		private Series incomingFailedMessageSeries = null;

		private Series cpuUsageSeries = null;
		private Series memoryUsageSeries = null;

		public TotalMetricCharts()
		{
			InitializeComponent();

			incomingTrafficSeries = ChartUtilities.ConfigChartSeries(trafficChart, "Incoming Traffic");
			outgoingTrafficSeries = ChartUtilities.ConfigChartSeries(trafficChart, "Outgoing Traffic");

			ccuSeries = ChartUtilities.ConfigChartSeries(ccuChart, "CCU");

			incomingMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Incoming Message");
			outgoingMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Outgoing Message");
			incomingInvalidMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Incoming Invalid Message");
			incomingFailedMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Incoming Failed Message");

			cpuUsageSeries = ChartUtilities.ConfigChartSeries(cpuChart, "CPU Usage");
			memoryUsageSeries = ChartUtilities.ConfigChartSeries(memoryChart, "Meemory Usage");
		}

		public void SetMetric(GetTotalMetricsRes Metric)
		{
			if (prevMetrics == null)
				prevMetrics = Metric;

			upTimeLabel.Text = string.Format(upTimeLabel.Tag.ToString(), TimeSpan.FromSeconds(Metric.UpTime).ToString(UP_TIME_FORMAT));
			cpuUsageLabel.Text = string.Format(cpuUsageLabel.Tag.ToString(), (int)(Metric.CPUUsage * 100));
			memoryUsageLabel.Text = string.Format(memoryUsageLabel.Tag.ToString(), (int)(Metric.MemoryUsage * 100));

			Metric totalMetric = Metric.TotalMetric;

			incomingTrafficLabel.Text = string.Format(incomingTrafficLabel.Tag.ToString(), totalMetric.IncomingTraffic);
			outgoingTrafficLabel.Text = string.Format(outgoingTrafficLabel.Tag.ToString(), totalMetric.OutgoingTraffic);

			ccuLabel.Text = string.Format(ccuLabel.Tag.ToString(), Metric.ClientCount);

			incomingMessageLabel.Text = string.Format(incomingMessageLabel.Tag.ToString(), totalMetric.IncomingMessageCount);
			outgoingMessageLabel.Text = string.Format(outgoingMessageLabel.Tag.ToString(), totalMetric.OutgoingMessageCount);
			incomingInvalidMessageLabel.Text = string.Format(incomingInvalidMessageLabel.Tag.ToString(), totalMetric.IncomingInvalidMessageCount);
			incomingFailedMessageLabel.Text = string.Format(incomingFailedMessageLabel.Tag.ToString(), totalMetric.IncomingFailedMessageCount);

			averageProcessTimeLabel.Text = string.Format(averageProcessTimeLabel.Tag.ToString(), totalMetric.AverageProcessTime);

			ChartUtilities.AddAbsoluteValue(incomingTrafficSeries, Metric.TotalMetric.IncomingTraffic - prevMetrics.TotalMetric.IncomingTraffic);
			ChartUtilities.AddAbsoluteValue(outgoingTrafficSeries, Metric.TotalMetric.OutgoingTraffic - prevMetrics.TotalMetric.OutgoingTraffic);

			ChartUtilities.AddAbsoluteValue(ccuSeries, Metric.ClientCount);

			ChartUtilities.AddAbsoluteValue(incomingMessageSeries, Metric.TotalMetric.IncomingMessageCount - prevMetrics.TotalMetric.IncomingMessageCount);
			ChartUtilities.AddAbsoluteValue(outgoingMessageSeries, Metric.TotalMetric.OutgoingMessageCount - prevMetrics.TotalMetric.OutgoingMessageCount);
			ChartUtilities.AddAbsoluteValue(incomingInvalidMessageSeries, Metric.TotalMetric.IncomingInvalidMessageCount - prevMetrics.TotalMetric.IncomingInvalidMessageCount);
			ChartUtilities.AddAbsoluteValue(incomingFailedMessageSeries, Metric.TotalMetric.IncomingFailedMessageCount - prevMetrics.TotalMetric.IncomingFailedMessageCount);

			ChartUtilities.AddAbsoluteValue(cpuUsageSeries, (uint)(Metric.CPUUsage * 100));
			ChartUtilities.AddAbsoluteValue(memoryUsageSeries, (uint)(Metric.MemoryUsage * 100));

			prevMetrics = Metric;
		}
	}
}
