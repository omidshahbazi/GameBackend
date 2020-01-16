using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class LoginForm : Form
	{
		private Connection connection = null;

		public LoginForm(Connection Connection)
		{
			connection = Connection;
			connection.OnConnectionFailed += Connection_OnConnectionFailed;

			InitializeComponent();

			UpdateLastConnectionUI();

			UpdateConnectionListUI();

			cancelButton.Enabled = false;
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			UpdateLastConnection();

			connection.OnConnected += Connection_OnConnected;

			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;

			connection.Connect(con.Protocol, con.Host, con.Port);

			connectButton.Enabled = false;
			cancelButton.Enabled = true;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			connection.OnConnectionFailed += Connection_OnConnectionFailed;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			connection.OnConnected -= Connection_OnConnected;

			connection.Disconnect();

			connectButton.Enabled = true;
			cancelButton.Enabled = false;

		}

		private void Connection_OnConnected(Connection Connection)
		{
			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;

			connection.Send<LoginReq, LoginRes>(new LoginReq() { Username = con.Username, Password = con.Password }, (Data) =>
			{
				if (Data.Result)
					Close();
				else
					connection.Disconnect();
			});

			connection.OnConnected -= Connection_OnConnected;
		}

		private void Connection_OnConnectionFailed(Connection Connection)
		{
			connectButton.Enabled = true;
			cancelButton.Enabled = false;
		}

		private void UpdateLastConnection()
		{
			ProfileInfo.Connection con = new ProfileInfo.Connection();
			con.Name = loginInfo.ConnectionName;
			con.Protocol = loginInfo.Protocol;
			con.Host = loginInfo.Host;
			con.Port = loginInfo.Port;
			con.Username = loginInfo.Username;
			con.Password = loginInfo.Password;

			Configurations.Instance.Profile.LastConnection = con;

			Configurations.Instance.Save();
		}

		private void UpdateLastConnectionUI()
		{
			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;
			loginInfo.ConnectionName = con.Name;
			loginInfo.Protocol = con.Protocol;
			loginInfo.Host = con.Host;
			loginInfo.Port = con.Port;
			loginInfo.Username = con.Username;
			loginInfo.Password = con.Password;
		}

		private void UpdateConnectionListUI()
		{
			connectionList.Items.Clear();

			ProfileInfo profileInfo = Configurations.Instance.Profile;

			if (profileInfo.Connections != null)
				for (int i = 0; i < profileInfo.Connections.Length; ++i)
					connectionList.Items.Add(profileInfo.Connections[i].Name);
		}
	}
}
