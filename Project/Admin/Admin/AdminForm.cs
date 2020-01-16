using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class AdminForm : Form
	{
		private Connection connection = null;
		private Timer timer = null;

		public AdminForm(Connection Connection)
		{
			connection = Connection;

			InitializeComponent();

			timer = new Timer();
			timer.Interval = (int)Configurations.Instance.Profile.Dashboard.RefreshInterval;
			timer.Tick += Timer_Tick;
			timer.Start();

			connection.RegisterHandler<LogoutReq>(HandleLogout);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			timer.Stop();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			connection.Send<GetTotalMetricsReq, GetTotalMetricsRes>(new GetTotalMetricsReq(), HandleGetTotalMetrics);
		}

		private void HandleLogout(LogoutReq Data)
		{
			Close();
		}

		private void HandleGetTotalMetrics(GetTotalMetricsRes Data)
		{
			totalMetricCharts1.SetMetric(Data);
		}
	}
}
