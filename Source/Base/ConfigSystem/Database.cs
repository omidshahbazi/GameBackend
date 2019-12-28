// Copyright 2019. All Rights Reserved.
namespace Backend.Base.ConfigSystem
{
	public struct Database
	{
		public enum DBMSTypes
		{
			MySQL = 0
		}

		public string Host;
		public ushort Port;
		public string Username;
		public string Password;
		public string Name;
		public DBMSTypes Type;
		public string TestQuery;
	}
}