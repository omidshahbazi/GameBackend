using Backend.Base.Metric;
using Backend.Common.NetworkSystem;
using GameFramework.Common.Timing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	public partial class StatisticsForm : Form
	{
		private const float UPDATE_METRICS_INTERVAL = 1.0F;

		private Timer timer = null;
		private double nextUpdateMetricTime = 0;

		private Connection connection = null;

		private Series cpuUsageSeries = null;

		public StatisticsForm()
		{
			InitializeComponent();

			timer = new Timer();
			timer.Interval = 100;
			timer.Tick += Timer_Tick;
			timer.Start();

			connection = new Connection();
			connection.OnConnected += Connection_OnConnected;
			connection.OnConnectionFailed += Connection_OnConnectionFailed;
			connection.OnDisconnected += Connection_OnDisconnected;
			connection.Connect(Common.ProtocolTypes.TCP, "::1", 5000);

			cpuUsageSeries = cpuUsageChart.Series.Add("CPU Usage");
			cpuUsageSeries.ChartType = SeriesChartType.Spline;
		}

		private void Timer_Tick(object sender, System.EventArgs e)
		{
			connection.Service();

			if (connection.IsConnected)
			{
				if (nextUpdateMetricTime <= Time.CurrentEpochTime)
				{
					connection.Send<GetMetricsReq, GetMetricsRes>(new GetMetricsReq(), GetMetricsHandler);

					nextUpdateMetricTime = Time.CurrentEpochTime + UPDATE_METRICS_INTERVAL;
				}
			}
		}

		private void Connection_OnConnected(Connection Connection)
		{
		}

		private void Connection_OnConnectionFailed(Connection Connection)
		{
		}

		private void Connection_OnDisconnected(Connection Connection)
		{
		}

		private void GetMetricsHandler(GetMetricsRes Data)
		{
			cpuUsageSeries.Points.Add(Data.CPUUsage);
		}
	}
}