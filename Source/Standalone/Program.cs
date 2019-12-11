// Copyright 2019. All Rights Reserved.
using Backend.Core;
using System;

namespace Backend.Standalone
{
	public static class Program
	{
		public static void Main(string[] Args)
		{
			Application application = Application.Instance;

			application.Initialize();
		}
	}
}