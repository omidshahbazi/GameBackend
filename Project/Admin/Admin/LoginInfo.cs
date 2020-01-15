using Backend.Common;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	public partial class LoginInfo : UserControl
	{
		public string ConnectionName
		{
			get { return nameBox.Text; }
			set { nameBox.Text = value; }
		}

		public ProtocolTypes Protocol
		{
			get { return (ProtocolTypes)protocolBox.SelectedItem; }
			set { protocolBox.SelectedItem = value; }
		}

		public string Host
		{
			get { return hostBox.Text; }
			set { hostBox.Text = value; }
		}

		public ushort Port
		{
			get { return (ushort)portBox.Value; }
			set { portBox.Value = value; }
		}

		public string Username
		{
			get { return usernameBox.Text; }
			set { usernameBox.Text = value; }
		}

		public string Password
		{
			get { return passwordBox.Text; }
			set { passwordBox.Text = value; }
		}

		public LoginInfo()
		{
			InitializeComponent();

			protocolBox.DataSource = Enum.GetValues(typeof(ProtocolTypes));
		}
	}
}
