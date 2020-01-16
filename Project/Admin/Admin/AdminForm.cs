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
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();

			updateIntervalBox.SelectedIndex = updateIntervalBox.Items.IndexOf(Configurations.Instance.Profile.Dashboard.RefreshInterval.ToString());

			connection.RegisterHandler<LogoutReq>(HandleLogout);

			Timer_Tick(null, null);
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

		private void UpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
		{
			uint interval = Convert.ToUInt32(updateIntervalBox.SelectedItem);
			Configurations.Instance.Profile.Dashboard.RefreshInterval = interval;
			Configurations.Instance.Save();

			timer.Interval = (int)interval * 1000;
		}

		private void MessagesStasButton_Click(object sender, EventArgs e)
		{

		}

		private void SocketsStatsButton_Click(object sender, EventArgs e)
		{

		}
	}
}
