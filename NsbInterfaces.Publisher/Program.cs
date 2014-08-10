using NsbInterfaces.Publisher.Events;
using NServiceBus;
using System;

namespace NsbInterfaces.Publisher
{
	class Program
	{
		static void Main(string[] args)
		{
			Configure.Features.Disable<NServiceBus.Features.TimeoutManager>().Disable<NServiceBus.Features.SecondLevelRetries>();
			var bus = Configure.With()
				.DefineEndpointName("nsbinterfaces.publisher")
				.DefiningEventsAs(t => t.Namespace != null && t.Namespace.Contains(".Events"))
				.DefaultBuilder()
				.UseTransport<Msmq>()
					.PurgeOnStartup(false)
				.MsmqSubscriptionStorage("nsbinterfaces.publisher")
				.UnicastBus()
					.LoadMessageHandlers()
					.ImpersonateSender(false)
				.EnablePerformanceCounters()
				.CreateBus()
				.Start(
					() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

			bus.Publish(new MyEvent());

			Console.WriteLine("Press esc to exit, or any other key to send an event");
			while(Console.ReadKey().Key != ConsoleKey.Escape)
			{
				bus.Publish(new MyEvent());
			}
		}
	}
}
