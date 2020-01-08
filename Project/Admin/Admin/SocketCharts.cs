using Backend.Base.Metric;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	public partial class SocketCharts : UserControl
	{
		private const int MAX_MEMORY_USAGE_SAMPLE_COUNT = 10;

		private const int MAX_CCU_SAMPLE_COUNT = 10;
		private const int MAX_INCOMING_TRAFFIC_SAMPLE_COUNT = 10;
		private const int MAX_OUTGOING_TRAFFIC_SAMPLE_COUNT = 10;
		private const int MAX_INCOMING_MESSAGE_SAMPLE_COUNT = 10;
		private const int MAX_OUTGOING_MESSAGE_SAMPLE_COUNT = 10;
		private const int MAX_INCOMING_INVALID_MESSAGE_SAMPLE_COUNT = 10;
		private const int MAX_INCOMING_FAILED_MESSAGES_SAMPLE_COUNT = 10;

		private Series ccuSeries = null;
		private Series incomingTrafficSeries = null;
		private Series outgoingTrafficSeries = null;
		private Series incomingMessageSeries = null;
		private Series outgoingMessageSeries = null;
		private Series incomingInvalidMessageSeries = null;
		private Series incomingFailedMessageSeries = null;

		public SocketCharts()
		{
			InitializeComponent();

			ccuSeries = ChartUtilities.ConfigChartSeries(ccuChart, "CCU");
			incomingTrafficSeries = ChartUtilities.ConfigChartSeries(incomingTrafficChart, "Incoming Traffic");
			outgoingTrafficSeries = ChartUtilities.ConfigChartSeries(outgoingTrafficChart, "Outgoing Traffic");
			incomingMessageSeries = ChartUtilities.ConfigChartSeries(incomingMessageChart, "Incoming Message");
			outgoingMessageSeries = ChartUtilities.ConfigChartSeries(outgoingMessageChart, "Outgoing Message");
			incomingInvalidMessageSeries = ChartUtilities.ConfigChartSeries(incomingInvalidMessageChart, "Incoming Invalid Message");
			incomingFailedMessageSeries = ChartUtilities.ConfigChartSeries(incomingFailedMessageChart, "Incoming Failed Message");
		}

		public void AddSamples(GetMetricsRes.SocketMetric Data)
		{
			ccuSeries.Points.Add(Data.ClientCount);
			if (ccuSeries.Points.Count > MAX_CCU_SAMPLE_COUNT)
				ccuSeries.Points.RemoveAt(0);

			AddAbsoluteValue(incomingTrafficSeries, Data.IncomingTraffic, MAX_INCOMING_TRAFFIC_SAMPLE_COUNT);

			AddAbsoluteValue(outgoingTrafficSeries, Data.OutgoingTraffic, MAX_OUTGOING_TRAFFIC_SAMPLE_COUNT);

			AddAbsoluteValue(incomingMessageSeries, Data.IncomingMessageCount, MAX_INCOMING_MESSAGE_SAMPLE_COUNT);

			AddAbsoluteValue(outgoingMessageSeries, Data.OutgoingMessageCount, MAX_OUTGOING_MESSAGE_SAMPLE_COUNT);

			AddAbsoluteValue(incomingInvalidMessageSeries, Data.IncomingInvalidMessageCount, MAX_INCOMING_INVALID_MESSAGE_SAMPLE_COUNT);

			AddAbsoluteValue(incomingFailedMessageSeries, Data.IncomingFailedMessageCount, MAX_INCOMING_FAILED_MESSAGES_SAMPLE_COUNT);
		}

		private static void AddAbsoluteValue(Series Series, ulong Value, int MaxSampleCount)
		{
			Series.Points.Add(Value - Series.Points[Series.Points.Count - 1].YValues[0]);
			if (Series.Points.Count > MaxSampleCount)
				Series.Points.RemoveAt(0);
		}
	}
}
