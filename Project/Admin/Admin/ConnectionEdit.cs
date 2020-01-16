using System.Windows.Forms;

namespace Backend.Admin
{
	partial class ConnectionEdit : Form
	{
		public ConnectionEdit()
		{
			InitializeComponent();
		}

		public DialogResult ShowDialog(ref ProfileInfo.Connection Connection)
		{
			loginInfo.Connection = Connection;

			base.ShowDialog();

			Connection = loginInfo.Connection;

			return DialogResult;
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
