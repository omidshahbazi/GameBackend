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

			connection.OnDisconnected += Connection_OnDisconnected;
			connection.RegisterHandler<LogoutReq>(HandleLogout);

			connection.Send<FetchFilesReq, FetchFilesRes>(new FetchFilesReq(), HandleFeetchFiles);

			Timer_Tick(null, null);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			connection.OnDisconnected -= Connection_OnDisconnected;

			timer.Stop();
		}

		private void HandleLogout(LogoutReq Data)
		{
			Close();
		}

		private void HandleFeetchFiles(FetchFilesRes Data)
		{
		}

		private void HandleGetTotalMetrics(GetTotalMetricsRes Data)
		{
			totalMetricCharts1.SetMetric(Data);
		}

		private void Connection_OnDisconnected(Connection Connection)
		{
			Close();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			connection.Send<GetTotalMetricsReq, GetTotalMetricsRes>(new GetTotalMetricsReq(), HandleGetTotalMetrics);
		}

		private void UpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
		{
			uint interval = Convert.ToUInt32(updateIntervalBox.SelectedItem);
			Configurations.Instance.Profile.Dashboard.RefreshInterval = interval;
			Configurations.Instance.Save();

			timer.Interval = (int)interval * 1000;
		}

		private void RequestsStasButton_Click(object sender, EventArgs e)
		{
			new DetailedMetricForm(connection, DetailedMetricForm.Type.Request).ShowDialog();
		}

		private void SocketsStatsButton_Click(object sender, EventArgs e)
		{
			new DetailedMetricForm(connection, DetailedMetricForm.Type.Socket).ShowDialog();
		}

		private void RestartButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Would you like to restart the server ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;

			connection.Send(new RestartReq());
		}

		private void ShutdownButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Would you like to shutdown the server ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;

			connection.Send(new ShutdownReq());
		}
	}
}
