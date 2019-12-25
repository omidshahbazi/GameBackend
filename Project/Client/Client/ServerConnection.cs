// Copyright 2019. All Rights Reserved.
using Backend.Common;
using GameFramework.BinarySerializer;
using GameFramework.Networking;
using System;

namespace Backend.Client
{
	public class ServerConnection
	{
		private ClientSocket socket = null;
		private RequestManager requestManager = null;

		public ServerConnection()
		{
			requestManager = new RequestManager(this);
		}

		public void Connect(ProtocolTypes Protocol, string Host, ushort Port)
		{
			if (Protocol == ProtocolTypes.TCP)
				socket = new TCPClientSocket();
			else if (Protocol == ProtocolTypes.UDP)
				socket = new UDPClientSocket();

			socket.MultithreadedCallbacks = false;

			socket.OnConnected += Socket_OnConnected;
			socket.OnConnectionFailed += Socket_OnConnectionFailed;
			socket.OnDisconnected += Socket_OnDisconnected;
			socket.OnBufferReceived += Socket_OnBufferReceived;

			socket.Connect(Host, Port);
		}

		public void Service()
		{
			if (socket != null)
				socket.Service();
		}

		public void RegisterHandler<ArgT>(Action<ArgT> Handler)
			where ArgT : class
		{
			requestManager.RegisterHandler(Handler);
		}

		public void Send<ArgT>(ArgT Argument, Action OnComplete = null)
			where ArgT : class
		{
			requestManager.Send(Argument, OnComplete);
		}

		public void Send<ArgT, ResT>(ArgT Argument, Action<ResT> OnComplete = null)
			where ArgT : class
			where ResT : class
		{
			requestManager.Send(Argument, OnComplete);
		}

		public void WriteBuffer(byte[] Buffer, uint Index, uint Length)
		{
			if (socket is TCPClientSocket)
				((TCPClientSocket)socket).Send(Buffer, Index, Length);
			else if (socket is UDPClientSocket)
				((UDPClientSocket)socket).Send(Buffer, Index, Length);
		}

		private void Socket_OnConnected()
		{
		}

		private void Socket_OnConnectionFailed()
		{
		}

		private void Socket_OnDisconnected()
		{
		}

		private void Socket_OnBufferReceived(BufferStream Buffer)
		{
			requestManager.DispatchBuffer(Buffer);
		}
	}
}