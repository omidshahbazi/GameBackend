// Copyright 2019. All Rights Reserved.
using Backend.Base.Utilities;
using Backend.Core.LogSystem;
using Backend.Core.NetworkSystem;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	class RequestManager : Singleton<RequestManager>
	{
		private class RequestMap : Dictionary<uint, Action<Client, object>>
		{ }

		private RequestMap requests = null;

		private RequestManager()
		{
			requests = new RequestMap();
		}

		public void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler)
			where ArgT : class
			where ResT : class
		{
			uint hash = NetworkUtilities.MakeHash<ArgT>();

			requests[hash] = (Client, Argument) =>
			{
				ResT res = Handler(Client, (ArgT)Argument);

				byte[] buffer = null;//res to byte[]

				Client.WriteBuffer(buffer);
			};
		}

		public void RegisterHandler<ArgT>(Action<Client, ArgT> Handler)
			where ArgT : class
		{
			uint hash = NetworkUtilities.MakeHash<ArgT>();

			requests[hash] = (Client, Argument) =>
			{
				Handler(Client, (ArgT)Argument);

				byte[] buffer = null;//just ack

				Client.WriteBuffer(buffer);
			};
		}

		public void InvokeHandler<ArgT>(Client Client, ArgT Argument)
		{
			uint hash = NetworkUtilities.MakeHash<ArgT>();

			if (!requests.ContainsKey(hash))
			{
				LogManager.Instance.WriteWarning("Request arguments [{0}] not recognized", typeof(ArgT).Name);
				return;
			}

			requests[hash](Client, Argument);
		}
	}
}