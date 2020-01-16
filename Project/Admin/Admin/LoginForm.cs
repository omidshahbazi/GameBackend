using Backend.Base.Admin;
using Backend.Common.NetworkSystem;
using GameFramework.Common.Extensions;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	partial class LoginForm : Form
	{
		private Connection connection = null;

		public LoginForm(Connection Connection)
		{
			connection = Connection;
			connection.OnConnectionFailed += Connection_OnConnectionFailed;

			InitializeComponent();

			loginInfo.Connection = Configurations.Instance.Profile.LastConnection;

			UpdateConnectionListUI();

			SetDisconnectedStateUI();

			SetErrorMessage("");
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			connection.OnConnectionFailed += Connection_OnConnectionFailed;
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			UpdateLastConnection();

			connection.OnConnected += Connection_OnConnected;

			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;

			connection.Connect(con.Protocol, con.Host, con.Port);

			SetConneectingStateUI();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			connection.OnConnected -= Connection_OnConnected;

			connection.Disconnect();

			SetDisconnectedStateUI();
		}

		private void SelectButton_Click(object sender, EventArgs e)
		{
			if (connectionList.SelectedIndex < 0)
				return;

			ProfileInfo.Connection con = Configurations.Instance.Profile.Connections[connectionList.SelectedIndex];

			loginInfo.Connection = con;
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			if (connectionList.SelectedIndex < 0)
				return;

			ProfileInfo.Connection con = Configurations.Instance.Profile.Connections[connectionList.SelectedIndex];

			if (new ConnectionEdit().ShowDialog(ref con) != DialogResult.OK)
				return;

			Configurations.Instance.Profile.Connections[connectionList.SelectedIndex] = con;

			Configurations.Instance.Save();

			UpdateConnectionListUI();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			ProfileInfo.Connection con = new ProfileInfo.Connection();

			if (new ConnectionEdit().ShowDialog(ref con) != DialogResult.OK)
				return;

			ProfileInfo.Connection[] cons = Configurations.Instance.Profile.Connections;

			ArrayUtilities.Add(ref cons, con);

			Configurations.Instance.Profile.Connections = cons;

			Configurations.Instance.Save();

			UpdateConnectionListUI();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (connectionList.SelectedIndex < 0)
				return;

			if (MessageBox.Show("Would you like to delete ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;

			ProfileInfo.Connection[] cons = Configurations.Instance.Profile.Connections;

			ArrayUtilities.RemoveAt(ref cons, connectionList.SelectedIndex);

			Configurations.Instance.Profile.Connections = cons;

			Configurations.Instance.Save();

			UpdateConnectionListUI();
		}

		private void Connection_OnConnected(Connection Connection)
		{
			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;

			connection.Send<LoginReq, LoginRes>(new LoginReq() { Username = con.Username, Password = con.Password }, (Data) =>
			{
				if (Data.Result)
					Close();
				else
				{
					connection.Disconnect();

					SetDisconnectedStateUI();
					SetErrorMessage("Invalid username or password");
				}
			});

			connection.OnConnected -= Connection_OnConnected;
		}

		private void Connection_OnConnectionFailed(Connection Connection)
		{
			SetDisconnectedStateUI();

			SetErrorMessage("Couldn't connect to host");
		}

		private void UpdateLastConnection()
		{
			Configurations.Instance.Profile.LastConnection = loginInfo.Connection;

			Configurations.Instance.Save();
		}

		private void UpdateConnectionListUI()
		{
			connectionList.Items.Clear();

			ProfileInfo profileInfo = Configurations.Instance.Profile;

			if (profileInfo.Connections != null)
				for (int i = 0; i < profileInfo.Connections.Length; ++i)
				{
					ProfileInfo.Connection con = profileInfo.Connections[i];
					connectionList.Items.Add(string.Format("{0} - [{1}]:{2}/{3}", con.Name, con.Host, con.Port, con.Protocol));
				}
		}

		void SetConneectingStateUI()
		{
			connectButton.Enabled = false;
			cancelButton.Enabled = true;

			selectButton.Enabled = false;
			editButton.Enabled = false;
			addButton.Enabled = false;
			deleteButton.Enabled = false;

			SetErrorMessage("");
		}

		void SetDisconnectedStateUI()
		{
			connectButton.Enabled = true;
			cancelButton.Enabled = false;

			selectButton.Enabled = true;
			editButton.Enabled = true;
			addButton.Enabled = true;
			deleteButton.Enabled = true;
		}

		void SetErrorMessage(string Message)
		{
			errorMessageLabel.Text = Message;
		}
	}
}
