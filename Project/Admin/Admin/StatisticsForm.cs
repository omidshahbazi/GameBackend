using Backend.Base.Metric;
using Backend.Common.NetworkSystem;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class StatisticsForm : Form
	{
		private Timer timer = null;
		private Connection connection = null;

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
		}

		private void Timer_Tick(object sender, System.EventArgs e)
		{
			connection.Service();
		}

		private void Connection_OnConnected(Connection Connection)
		{
			connection.Send<GetMetricsReq, GetMetricsRes>(new GetMetricsReq(), GetMetricsHandler);
		}

		private void Connection_OnConnectionFailed(Connection Connection)
		{
		}

		private void Connection_OnDisconnected(Connection Connection)
		{
		}

		private void GetMetricsHandler(GetMetricsRes Data)
		{

		}
	}
}