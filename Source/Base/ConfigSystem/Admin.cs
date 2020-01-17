// Copyright 2019. All Rights Reserved.
namespace Backend.Base.ConfigSystem
{
	public struct Admin
	{
		public struct User
		{
			public string Username;
			public string Password;
		}

		public User[] Users;
		public string[] UploadPaths;
	}
}