// Copyright 2019. All Rights Reserved.
using Backend.Core;
using System.Threading;

namespace Backend.Standalone
{
	public static class Program
	{
		public static void Main(string[] Args)
		{
			Application application = Application.Instance;

			if (Args != null && Args.Length != 0)
				application.WorkingDirectory = Args[0];

			while (application.IsStarting)
			{
				application.Initialize();

				while (application.IsRunning)
				{
					application.Service();

					Thread.Sleep(10);
				}

				application.Shutdown();
			}
		}
	}
}