using Backend.Common;
using GameFramework.ASCIISerializer;
using GameFramework.Common.FileLayer;
using GameFramework.Common.MemoryManagement;

namespace Backend.Admin
{
	struct ProfileInfo
	{
		public struct Connection
		{
			public string Name;
			public ProtocolTypes Protocol;
			public string Host;
			public ushort Port;
			public string Username;
			public string Password;
		}

		public struct DashboardConfiguration
		{
			public uint RefreshInterval;
		}

		public Connection LastConnection;

		public Connection[] Connections;

		public DashboardConfiguration Dashboard;
	}

	class Configurations : Singleton<Configurations>
	{
		private const string FILE_NAME = "Configuration.json";

		public ProfileInfo Profile;

		private Configurations()
		{
			string configContent = FileSystem.Read(FILE_NAME);
			if (string.IsNullOrEmpty(configContent))
			{
				Profile = new ProfileInfo();

				Profile.LastConnection = new ProfileInfo.Connection();
				Profile.LastConnection.Name = "Local";
				Profile.LastConnection.Protocol = ProtocolTypes.TCP;
				Profile.LastConnection.Host = "::1";
				Profile.LastConnection.Port = 5000;
				Profile.LastConnection.Username = "Admin";
				Profile.LastConnection.Password = "";

				Profile.Dashboard = new ProfileInfo.DashboardConfiguration();
				Profile.Dashboard.RefreshInterval = 1;

				Save();
			}
			else
			{
				Profile = Creator.Bind<ProfileInfo>(Creator.Create<ISerializeObject>(configContent));
			}
		}

		public void Save()
		{
			ISerializeObject obj = Creator.Serialize<ISerializeObject>(Profile);

			FileSystem.Write(FILE_NAME, obj.Content);
		}
	}
}
