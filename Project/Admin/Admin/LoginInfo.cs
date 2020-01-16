using Backend.Common;
using System;
using System.Windows.Forms;

namespace Backend.Admin
{
	partial class LoginInfo : UserControl
	{
		public ProfileInfo.Connection Connection
		{
			get
			{
				ProfileInfo.Connection con = new ProfileInfo.Connection();

				con.Name = nameBox.Text;
				con.Protocol = (ProtocolTypes)protocolBox.SelectedItem;
				con.Host = hostBox.Text;
				con.Port = (ushort)portBox.Value;
				con.Username = usernameBox.Text;
				con.Password = passwordBox.Text;

				return con;
			}
			set
			{
				nameBox.Text = value.Name;
				protocolBox.SelectedItem = value.Protocol;
				hostBox.Text = value.Host;
				portBox.Value = value.Port;
				usernameBox.Text = value.Username;
				passwordBox.Text = value.Password;
			}
		}

		public LoginInfo()
		{
			InitializeComponent();

			protocolBox.DataSource = Enum.GetValues(typeof(ProtocolTypes));
		}
	}
}
