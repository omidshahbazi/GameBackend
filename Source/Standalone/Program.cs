// Copyright 2019. All Rights Reserved.
using Backend.Core;
using GameFramework.Common.Utilities;
using System.Threading;

namespace Backend.Standalone
{
	public static class Program
	{
		public static void Main(string[] Args)
		{
			Application application = Application.Instance;

			application.Arguments = ArgumentParser.Parse(Args);

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