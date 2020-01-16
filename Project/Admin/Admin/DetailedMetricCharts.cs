using Backend.Base.Admin;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	public partial class DetailedMetricCharts : UserControl
	{
		private SocketMetric prevSocketMetrics;
		private RequestMetric prevRequestMetrics;

		private Series incomingTrafficSeries = null;
		private Series outgoingTrafficSeries = null;

		private Series incomingMessageSeries = null;
		private Series outgoingMessageSeries = null;
		private Series incomingInvalidMessageSeries = null;
		private Series incomingFailedMessageSeries = null;

		public DetailedMetricCharts()
		{
			InitializeComponent();

			incomingTrafficSeries = ChartUtilities.ConfigChartSeries(trafficChart, "Incoming Traffic");
			outgoingTrafficSeries = ChartUtilities.ConfigChartSeries(trafficChart, "Outgoing Traffic");

			incomingMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Incoming Message");
			outgoingMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Outgoing Message");
			incomingInvalidMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Incoming Invalid Message");
			incomingFailedMessageSeries = ChartUtilities.ConfigChartSeries(messageChart, "Incoming Failed Message");
		}

		public void Reset()
		{
			prevSocketMetrics = null;
			prevRequestMetrics = null;

			incomingTrafficSeries.Points.Clear();
			outgoingTrafficSeries.Points.Clear();

			incomingMessageSeries.Points.Clear();
			outgoingMessageSeries.Points.Clear();
			incomingInvalidMessageSeries.Points.Clear();
			incomingFailedMessageSeries.Points.Clear();
		}

		public void SetMetric(SocketMetric Metric)
		{
			if (prevSocketMetrics == null)
				prevSocketMetrics = Metric;

			Metric totalMetric = Metric;

			incomingTrafficLabel.Text = string.Format(incomingTrafficLabel.Tag.ToString(), totalMetric.IncomingTraffic);
			outgoingTrafficLabel.Text = string.Format(outgoingTrafficLabel.Tag.ToString(), totalMetric.OutgoingTraffic);

			incomingMessageLabel.Text = string.Format(incomingMessageLabel.Tag.ToString(), totalMetric.IncomingMessageCount);
			outgoingMessageLabel.Text = string.Format(outgoingMessageLabel.Tag.ToString(), totalMetric.OutgoingMessageCount);
			incomingInvalidMessageLabel.Text = string.Format(incomingInvalidMessageLabel.Tag.ToString(), totalMetric.IncomingInvalidMessageCount);
			incomingFailedMessageLabel.Text = string.Format(incomingFailedMessageLabel.Tag.ToString(), totalMetric.IncomingFailedMessageCount);

			averageProcessTimeLabel.Text = string.Format(averageProcessTimeLabel.Tag.ToString(), totalMetric.AverageProcessTime);

			ChartUtilities.AddAbsoluteValue(incomingTrafficSeries, Metric.IncomingTraffic - prevSocketMetrics.IncomingTraffic);
			ChartUtilities.AddAbsoluteValue(outgoingTrafficSeries, Metric.OutgoingTraffic - prevSocketMetrics.OutgoingTraffic);

			ChartUtilities.AddAbsoluteValue(incomingMessageSeries, Metric.IncomingMessageCount - prevSocketMetrics.IncomingMessageCount);
			ChartUtilities.AddAbsoluteValue(outgoingMessageSeries, Metric.OutgoingMessageCount - prevSocketMetrics.OutgoingMessageCount);
			ChartUtilities.AddAbsoluteValue(incomingInvalidMessageSeries, Metric.IncomingInvalidMessageCount - prevSocketMetrics.IncomingInvalidMessageCount);
			ChartUtilities.AddAbsoluteValue(incomingFailedMessageSeries, Metric.IncomingFailedMessageCount - prevSocketMetrics.IncomingFailedMessageCount);

			prevSocketMetrics = Metric;
		}

		public void SetMetric(RequestMetric Metric)
		{
			if (prevRequestMetrics == null)
				prevRequestMetrics = Metric;

			Metric totalMetric = Metric;

			incomingTrafficLabel.Text = string.Format(incomingTrafficLabel.Tag.ToString(), totalMetric.IncomingTraffic);
			outgoingTrafficLabel.Text = string.Format(outgoingTrafficLabel.Tag.ToString(), totalMetric.OutgoingTraffic);

			incomingMessageLabel.Text = string.Format(incomingMessageLabel.Tag.ToString(), totalMetric.IncomingMessageCount);
			outgoingMessageLabel.Text = string.Format(outgoingMessageLabel.Tag.ToString(), totalMetric.OutgoingMessageCount);
			incomingInvalidMessageLabel.Text = string.Format(incomingInvalidMessageLabel.Tag.ToString(), totalMetric.IncomingInvalidMessageCount);
			incomingFailedMessageLabel.Text = string.Format(incomingFailedMessageLabel.Tag.ToString(), totalMetric.IncomingFailedMessageCount);

			averageProcessTimeLabel.Text = string.Format(averageProcessTimeLabel.Tag.ToString(), totalMetric.AverageProcessTime);

			ChartUtilities.AddAbsoluteValue(incomingTrafficSeries, Metric.IncomingTraffic - prevRequestMetrics.IncomingTraffic);
			ChartUtilities.AddAbsoluteValue(outgoingTrafficSeries, Metric.OutgoingTraffic - prevRequestMetrics.OutgoingTraffic);

			ChartUtilities.AddAbsoluteValue(incomingMessageSeries, Metric.IncomingMessageCount - prevRequestMetrics.IncomingMessageCount);
			ChartUtilities.AddAbsoluteValue(outgoingMessageSeries, Metric.OutgoingMessageCount - prevRequestMetrics.OutgoingMessageCount);
			ChartUtilities.AddAbsoluteValue(incomingInvalidMessageSeries, Metric.IncomingInvalidMessageCount - prevRequestMetrics.IncomingInvalidMessageCount);
			ChartUtilities.AddAbsoluteValue(incomingFailedMessageSeries, Metric.IncomingFailedMessageCount - prevRequestMetrics.IncomingFailedMessageCount);

			prevRequestMetrics = Metric;
		}
	}
}
