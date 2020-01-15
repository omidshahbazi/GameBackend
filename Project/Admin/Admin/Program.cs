using Backend.Common.NetworkSystem;
using GameFramework.Common.FileLayer;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	static class Program
	{
		private static Connection connection = null;

		[STAThread]
		static void Main()
		{
			FileSystem.DataPath = Environment.CurrentDirectory;

			Configurations temp = Configurations.Instance;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			connection = new Connection();

			Timer timer = new Timer();
			timer.Interval = 10;
			timer.Tick += Timer_Tick;
			timer.Start();

			while (true)
			{
				connection.Disconnect();

				Application.Run(new LoginForm(connection));

				if (!connection.IsConnected)
					return;

				Application.Run(new AdminForm(connection));
			}
		}

		private static void Timer_Tick(object sender, EventArgs e)
		{
			connection.Service();
		}
	}
}