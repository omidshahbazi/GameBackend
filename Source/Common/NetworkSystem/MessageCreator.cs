// Copyright 2019. All Rights Reserved.
using GameFramework.BinarySerializer;
using GameFramework.Common.MemoryManagement;
using GameFramework.Common.Utilities;
using System;
using System.Collections.Generic;

namespace Backend.Common.NetworkSystem
{
	public class MessageCreator : Singleton<MessageCreator>
	{
		private class TypeMap : Dictionary<uint, Type>
		{ }

		private TypeMap types = null;

		private MessageCreator()
		{
			types = new TypeMap();
		}

		public uint Register<T>()
		{
			uint typeID = GenerateTypeID(typeof(T));

			types[typeID] = typeof(T);

			return typeID;
		}

		public bool Serialize(uint ID, object Instance, BufferStream Buffer)
		{
			if (Instance == null)
				return false;

			uint typeID = GenerateTypeID(Instance.GetType());

			Buffer.WriteUInt32(ID);
			Buffer.WriteUInt32(typeID);
			Serializer.Serialize(Instance, Buffer);

			return true;
		}

		public object Deserialize(BufferStream Buffer, out uint ID, out uint TypeID)
		{
			ID = Buffer.ReadUInt32();
			TypeID = Buffer.ReadUInt32();

			if (!types.ContainsKey(TypeID))
				return null;

			return Serializer.Deserialize(types[TypeID], Buffer);
		}

		public static uint GenerateTypeID(Type Type)
		{
			return ReflectionExtensions.MakeHash(Type);
		}
	}
}


public class args
{
	public int doIt;
}
