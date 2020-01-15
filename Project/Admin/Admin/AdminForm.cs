using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
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
			timer.Interval = 100;
			timer.Tick += Timer_Tick;
			timer.Start();

			connection.Service();
			connection.Send(new LoginRes(), () =>
			{

			});
		}

		private void Timer_Tick(object sender, System.EventArgs e)
		{
		}
	}
}
