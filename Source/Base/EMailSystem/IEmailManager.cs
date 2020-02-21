// Copyright 2019. All Rights Reserved.
using System.Text;

namespace Backend.Base.EMailSystem
{
	public struct EMailAddress
	{
		public string Address;
		public string DisplayName;
		public Encoding Encoding;
	}

	public struct EMailMessage
	{
		public EMailAddress From;
		public EMailAddress[] To;

		public EMailAddress Sender;

		public string Subject;
		public Encoding SubjectEncoding;

		public string Body;
		public Encoding BodyEncoding;

		public bool IsHTML;
	}

	public interface IEMailManager
	{
		void Send(string To, string Message);
		void Send(string To, string Title, string Message);
		void Send(string From, string To, string Title, string Message);
		void Send(EMailMessage Message);
	}
}