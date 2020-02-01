// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.EMailSystem;
using Backend.Base.ModuleSystem;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Backend.Database
{
	class EMailManager : IModule, IEMailManager
	{
		private Base.ConfigSystem.EMail config;
		private SmtpClient client = null;

		public void Initialize(IContext Context, object Config)
		{
			if (Config == null)
			{
				Context.Logger.WriteWarning("EMailManager config is null, ignore initializing");
				return;
			}

			config = (Base.ConfigSystem.EMail)Config;

			client = new SmtpClient(config.Host, config.SMTPPort);
			client.EnableSsl = config.SSL;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential(config.Username, config.Password);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;

			Context.EMailManager = this;
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		public void Send(string To, string Body)
		{
			Send(new EMailMessage() { To = new EMailAddress[] { new EMailAddress() { Address = To } }, Body = Body });
		}

		public void Send(string To, string Subject, string Body)
		{
			Send(new EMailMessage() { To = new EMailAddress[] { new EMailAddress() { Address = To } }, Subject = Subject, Body = Body });
		}

		public void Send(string From, string To, string Subject, string Body)
		{
			Send(new EMailMessage() { From = new EMailAddress() { Address = From }, To = new EMailAddress[] { new EMailAddress() { Address = To } }, Subject = Subject, Body = Body });
		}

		public void Send(EMailMessage Message)
		{
			if (Message.To == null || string.IsNullOrEmpty(Message.To[0].Address))
				throw new ArgumentException("Doesn't provided or is empty", "Message.To");

			if (string.IsNullOrEmpty(Message.Body))
				throw new ArgumentException("Doesn't provided or is empty", "Message.Body");

			if (Message.SubjectEncoding == null)
				Message.SubjectEncoding = Encoding.UTF8;

			if (Message.BodyEncoding == null)
				Message.BodyEncoding = Encoding.UTF8;

			MailMessage message = new MailMessage();

			message.From = CreateMailAddress(Message.From);

			for (int i = 0; i < Message.To.Length; ++i)
				message.To.Add(CreateMailAddress(Message.To[i]));

			message.Sender = CreateMailAddress(Message.Sender);

			message.Subject = Message.Subject;
			message.SubjectEncoding = Message.SubjectEncoding;

			message.Body = Message.Body;
			message.BodyEncoding = Message.BodyEncoding;

			client.Send(message);
		}

		private MailAddress CreateMailAddress(EMailAddress Address)
		{
			if (string.IsNullOrEmpty(Address.Address))
				Address.Address = config.Username;

			if (string.IsNullOrEmpty(Address.DisplayName))
				Address.DisplayName = config.Username;

			if (Address.Encoding == null)
				Address.Encoding = Encoding.UTF8;

			return new MailAddress(Address.Address, Address.DisplayName, Address.Encoding);
		}
	}
}