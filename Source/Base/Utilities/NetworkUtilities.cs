// Copyright 2019. All Rights Reserved.

using GameFramework.Common.Utilities;
using System.Text;

namespace Backend.Base.Utilities
{
	public static class NetworkUtilities
	{
		public static uint MakeHash<T>()
		{
			return CRC32.CalculateHash(Encoding.ASCII.GetBytes(typeof(T).FullName));
		}
	}
}