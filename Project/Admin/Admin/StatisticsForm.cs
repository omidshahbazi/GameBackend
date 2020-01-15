using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
using GameFramework.Common.Timing;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	public partial class StatisticsForm : Form
	{
		private const float UPDATE_METRICS_INTERVAL = 1.0F;
		private const int MAX_CPU_USAGE_SAMPLE_COUNT = 10;
		private const int MAX_MEMORY_USAGE_SAMPLE_COUNT = 10;

		private Timer timer = null;
		private double nextUpdateMetricTime = 0;

		private Connection connection = null;
		private bool isLoggedIn = false;

		private Series cpuUsageSeries = null;
		private Series memoryUsageSeries = null;

		private SocketCharts[] socketCharts = null;

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

			connection.RegisterHandler<Logout>(LogoutHandler);

			connection.Connect(Common.ProtocolTypes.TCP, "::1", 5000);

			cpuUsageSeries = ChartUtilities.ConfigChartSeries(cpuUsageChart, "CPU Usage");
			memoryUsageSeries = ChartUtilities.ConfigChartSeries(memoryUsageChart, "Memory Usage");
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			connection.Service();

			if (isLoggedIn)
			{
				if (nextUpdateMetricTime <= Time.CurrentEpochTime)
				{
					connection.Send<GetDetailedSocketMetricsReq, GetDetailedSocketMetricsRes>(new GetDetailedSocketMetricsReq(), GetMetricsHandler);

					nextUpdateMetricTime = Time.CurrentEpochTime + UPDATE_METRICS_INTERVAL;
				}
			}
		}

		private void Connection_OnConnected(Connection Connection)
		{
			connection.Send<LoginReq, LoginRes>(new LoginReq() { Username = "Admin", Password = "qwer1234" }, LoginResHandler);
		}

		private void Connection_OnConnectionFailed(Connection Connection)
		{
		}

		private void Connection_OnDisconnected(Connection Connection)
		{
		}

		private void LoginResHandler(LoginRes Data)
		{
			if (!Data.Result)
				Application.Exit();

			isLoggedIn = true;

			connection.Send<GetDetailedSocketMetricsReq, GetDetailedSocketMetricsRes>(new GetDetailedSocketMetricsReq(), GetFirstMetricsHandler);


			connection.Send<UploadFile>(new UploadFile() { FilePath = "Libraries/omid.dll", Content = System.IO.File.ReadAllBytes("D:/instruction_tables.pdf") });
		}

		private void LogoutHandler(Logout Data)
		{
			isLoggedIn = false;

			Application.Exit();
		}

		private void GetFirstMetricsHandler(GetDetailedSocketMetricsRes Data)
		{
			if (Data.SocketsMetric != null)
			{
				socketCharts = new SocketCharts[Data.SocketsMetric.Length];

				mainTableLayout.RowCount = Data.SocketsMetric.Length + 1;

				float percent = 100.0F / mainTableLayout.RowCount;
				mainTableLayout.RowStyles[0].Height = percent;

				for (int i = 0; i < Data.SocketsMetric.Length; ++i)
				{
					mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, percent));

					SocketCharts socketChart = socketCharts[i] = new SocketCharts();
					socketChart.Dock = DockStyle.Fill;

					mainTableLayout.Controls.Add(socketChart, 0, i + 1);
				}
			}

			GetMetricsHandler(Data);
		}

		private void GetMetricsHandler(GetDetailedSocketMetricsRes Data)
		{
			//cpuUsageSeries.Points.Add((int)(Data.CPUUsage * 100));
			//if (cpuUsageSeries.Points.Count > MAX_CPU_USAGE_SAMPLE_COUNT)
			//	cpuUsageSeries.Points.RemoveAt(0);

			//memoryUsageSeries.Points.Add((int)(Data.MemoryUsage * 100));
			//if (memoryUsageSeries.Points.Count > MAX_MEMORY_USAGE_SAMPLE_COUNT)
			//	memoryUsageSeries.Points.RemoveAt(0);

			if (Data.SocketsMetric != null)
			{
				for (int i = 0; i < Data.SocketsMetric.Length; ++i)
					socketCharts[i].AddSamples(Data.SocketsMetric[i]);
			}
		}
	}
}