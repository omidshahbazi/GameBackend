using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class DetailedMetricForm : Form
	{
		public enum Type
		{
			Socket = 0,
			Request = 1
		}

		private Connection connection = null;
		private Type type;
		private Timer timer = null;

		public DetailedMetricForm(Connection Connection, Type Type)
		{
			connection = Connection;
			type = Type;

			InitializeComponent();

			timer = new Timer();
			timer.Interval = (int)Configurations.Instance.Profile.Dashboard.RefreshInterval * 1000;
			timer.Tick += Timer_Tick;
			timer.Start();

			if (type == Type.Socket)
				connection.Send<GetDetailedSocketMetricsReq, GetDetailedSocketMetricsRes>(new GetDetailedSocketMetricsReq(), HandleFirstGetDetailedSocketMetrics);
			else if (type == Type.Request)
				connection.Send<GetDetailedRequestMetricsReq, GetDetailedRequestMetricsRes>(new GetDetailedRequestMetricsReq(), HandleFirstGetDetailedRequestMetrics);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			timer.Stop();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (type == Type.Socket)
				connection.Send<GetDetailedSocketMetricsReq, GetDetailedSocketMetricsRes>(new GetDetailedSocketMetricsReq(), HandleGetDetailedSocketMetrics);
			else if (type == Type.Request)
				connection.Send<GetDetailedRequestMetricsReq, GetDetailedRequestMetricsRes>(new GetDetailedRequestMetricsReq(), HandleGetDetailedRequestMetrics);
		}

		private void HandleFirstGetDetailedSocketMetrics(GetDetailedSocketMetricsRes Data)
		{
			for (int i =0; i < Data.SocketsMetric.Length; ++i)
			{
				SocketMetric metric = Data.SocketsMetric[i];

				detailsList.Items.Add(metric.Port + "/" + metric.Protocol);
			}

			detailsList.SelectedIndex = 0;
		}

		private void HandleFirstGetDetailedRequestMetrics(GetDetailedRequestMetricsRes Data)
		{
			for (int i = 0; i < Data.RequestsMetric.Length; ++i)
			{
				RequestMetric metric = Data.RequestsMetric[i];

				detailsList.Items.Add(metric.Type);
			}

			detailsList.SelectedIndex = 0;
		}

		private void HandleGetDetailedSocketMetrics(GetDetailedSocketMetricsRes Data)
		{
			if (detailsList.SelectedIndex == -1)
				return;

			SocketMetric metric = Data.SocketsMetric[detailsList.SelectedIndex];

			detailedMetricCharts1.SetMetric(metric);
		}

		private void HandleGetDetailedRequestMetrics(GetDetailedRequestMetricsRes Data)
		{
			if (detailsList.SelectedIndex == -1)
				return;

			RequestMetric metric = Data.RequestsMetric[detailsList.SelectedIndex];

			detailedMetricCharts1.SetMetric(metric);
		}

		private void DetailsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			detailedMetricCharts1.Reset();
		}
	}
}
