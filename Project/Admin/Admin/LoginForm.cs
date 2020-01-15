﻿using Backend.Base.Admin;
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
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Connect();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			connection.OnConnectionFailed += Connection_OnConnectionFailed;
		}

		private void Connect()
		{
			connection.OnConnected += Connection_OnConnected;

			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;

			connection.Connect(con.Protocol, con.Host, con.Port);
		}

		private void CancelConnect()
		{
			connection.OnConnected -= Connection_OnConnected;

			connection.Disconnect();
		}

		private void Connection_OnConnected(Connection Connection)
		{
			ProfileInfo.Connection con = Configurations.Instance.Profile.LastConnection;

			connection.Send<LoginReq, LoginRes>(new LoginReq() { Username = con.Username, Password = "qwer1234" }, (Data) =>
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
		}
	}
}