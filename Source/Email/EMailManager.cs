// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.EMailSystem;
using Backend.Base.ModuleSystem;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Backend.Database
{
	class EMailManager : IModule, IEmailManager
	{
		private Base.ConfigSystem.EMail config;

		public void Initialize(IContext Context, object Config)
		{
			if (Config == null)
			{
				Context.Logger.WriteWarning("EMailManager config is null, ignore initializing");
				return;
			}

			config = (Base.ConfigSystem.EMail)Config;

			SmtpClient client = new SmtpClient(config.Host, config.SMTPPort);
			client.UseDefaultCredentials = false;
			client.EnableSsl = config.SSL;
			client.Credentials = new NetworkCredential(config.Username, config.Password);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;

			MailMessage mail = new MailMessage();
			mail.To.Add(CreateMailAddress("Omid Shahbazi", "sh.omid.m@gmail.com"));
			mail.From = CreateMailAddress("Omid Shahbazi", "sh.omid.m@gmail.com");
			mail.Body = "سلام";
			mail.BodyEncoding = Encoding.UTF8;
			mail.Sender = CreateMailAddress("Omid Shahbazi", "sh.omid.m@gmail.com"); ;
			mail.Priority = MailPriority.High;
			mail.SubjectEncoding = Encoding.UTF8;
			client.Send(mail);

			Context.EMailManager = this;
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}

		private static MailAddress CreateMailAddress(string DisplayName, string Address)
		{
			return new MailAddress(Address, DisplayName, Encoding.UTF8);
		}
	}
}