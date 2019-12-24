// Copyright 2019. All Rights Reserved.
using Backend.Base.Utilities;
using Backend.Core.LogSystem;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	class RequestManager : Singleton<RequestManager>
	{
		private class RequestMap : Dictionary<uint, Action<object>>
		{ }

		private RequestMap requests = null;

		private RequestManager()
		{
			requests = new RequestMap();
		}

		public void RegisterHandler<ArgT, ResT>(Func<ArgT, ResT> Handler)
			where ArgT : class
			where ResT : class
		{
			uint hash = NetworkUtilities.MakeHash<ArgT>();

			requests[hash] = (Argument) =>
			{
				ResT res = Handler((ArgT)Argument);


			};
		}

		public void InvokeHandler<ArgT>(ArgT Argument)
		{
			uint hash = NetworkUtilities.MakeHash<ArgT>();

			if (!requests.ContainsKey(hash))
			{
				LogManager.Instance.WriteWarning("Request arguments [{0}] not recognized", typeof(ArgT).Name);
				return;
			}

			requests[hash](Argument);
		}
	}
}