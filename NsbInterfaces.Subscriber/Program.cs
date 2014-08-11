﻿namespace NsbInterfaces.Subscriber
{
    using System;
    using NServiceBus;

    class Program
	{
		static void Main(string[] args)
		{
			//var kernel = new StandardKernel();

			Configure.Features.Disable<NServiceBus.Features.TimeoutManager>().Disable<NServiceBus.Features.SecondLevelRetries>();
			Configure.With()
				.DefineEndpointName("nsbinterfaces.subscriber")
				.DefiningEventsAs(t => t.Namespace != null && t.Namespace.Contains(".Events"))
				//.NinjectBuilder(kernel)
				.DefaultBuilder()
				.UseTransport<Msmq>()
					.PurgeOnStartup(false)
				.MsmqSubscriptionStorage("nsbinterfaces.subscriber")
				.UnicastBus()
					.LoadMessageHandlers()
					.ImpersonateSender(false)
				.CreateBus()
				.Start(
					() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());


			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
