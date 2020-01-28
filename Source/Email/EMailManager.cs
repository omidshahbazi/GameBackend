// Copyright 2019. All Rights Reserved.
using Backend.Base;
using Backend.Base.EMailSystem;
using Backend.Base.ModuleSystem;
using System.Net;
using System.Net.Mail;

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
			client.Credentials = new NetworkCredential(config.Username, config.Password);



			Context.EMailManager = this;
		}

		public void Shutdown()
		{
		}

		public void Service()
		{
		}
	}
}