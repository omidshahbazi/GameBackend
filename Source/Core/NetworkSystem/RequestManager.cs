// Copyright 2019. All Rights Reserved.
using Backend.Core.LogSystem;
using Backend.Core.NetworkSystem;
using GameFramework.Common.MemoryManagement;
using System;
using System.Collections.Generic;

namespace Backend.Core
{
	class RequestManager : Singleton<RequestManager>
	{
		//private static TypeMap types;

		//public static void RegisterType<T>()
		//{
		//	RegisterType(typeof(T));
		//}

		//public static bool RegisterType(Type Type)
		//{
		//	if (Type == null)
		//		return false;

		//	uint hash = Type.MakeHash();

		//	if (types.ContainsKey(hash))
		//		return true;

		//	types[hash] = Type;

		//	MemberInfo[] members = Type.GetMemberVariables(ReflectionExtensions.AllNonStaticFlags);
		//	for (int i = 0; i < members.Length; ++i)
		//	{
		//		MemberInfo member = members[i];
		//		Type type = null;

		//		if (member is FieldInfo)
		//			type = ((FieldInfo)member).FieldType;
		//		else if (member is PropertyInfo)
		//			type = ((PropertyInfo)member).PropertyType;

		//		if (type.IsPrimitive || type.IsEnum || type == typeof(string))
		//			continue;

		//		if (type.IsArray)
		//			type = type.GetElementType();

		//		if (!RegisterType(type))
		//			return false;
		//	}

		//	return true;
		//}



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