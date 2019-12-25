﻿// Copyright 2019. All Rights Reserved.
using Backend.Common;
using GameFramework.BinarySerializer;
using GameFramework.Networking;
using System;

namespace Backend.Client
{
	public delegate void ConnectionEventHandler(ServerConnection Connection);

	public class ServerConnection
	{
		private ClientSocket socket = null;
		private RequestManager requestManager = null;

		public event ConnectionEventHandler OnConnected;
		public event ConnectionEventHandler OnConnectionFailed;
		public event ConnectionEventHandler OnDisconnected;

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

		public void Disconnect()
		{
			socket.Disconnect();

			socket.OnConnected -= Socket_OnConnected;
			socket.OnConnectionFailed -= Socket_OnConnectionFailed;
			socket.OnDisconnected -= Socket_OnDisconnected;
			socket.OnBufferReceived -= Socket_OnBufferReceived;
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
			if (OnConnected != null)
				OnConnected(this);
		}

		private void Socket_OnConnectionFailed()
		{
			if (OnConnectionFailed != null)
				OnConnectionFailed(this);
		}

		private void Socket_OnDisconnected()
		{
			if (OnDisconnected != null)
				OnDisconnected(this);
		}

		private void Socket_OnBufferReceived(BufferStream Buffer)
		{
			requestManager.DispatchBuffer(Buffer);
		}
	}
}