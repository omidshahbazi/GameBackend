// Copyright 2019. All Rights Reserved.
using Backend.Common;
using System.Threading;

namespace Backend.Client
{
	public static class Program
	{
		class sss
		{
			public int a;
		}

		public static void Main(string[] Args)
		{
			ServerConnection connection = new ServerConnection();
			connection.Connect(ProtocolTypes.TCP, "::1", 81);

			sss s = new sss();
			s.a = 102;

			while (true)
			{
				connection.Service();

				Thread.Sleep(1000);

				connection.Send(s);
			}
		}
	}
}