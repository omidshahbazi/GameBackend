// Copyright 2019. All Rights Reserved.
using System;

namespace Backend.Base.NetworkSystem
{
	public interface IRequestManager
	{
		void RegisterHandler<ArgT>(Action<Client, ArgT> Handler) where ArgT : class;

		void RegisterHandler<ArgT, ResT>(Func<Client, ArgT, ResT> Handler) where ArgT : class where ResT : class;

		void Send<T>(Client Client, T Argument) where T : class;
	}
}