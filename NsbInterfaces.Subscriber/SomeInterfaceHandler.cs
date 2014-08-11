namespace NsbInterfaces.Subscriber
{
    using System;
    using Events;
    using NServiceBus;

    public class SomeInterfaceHandler : IHandleMessages<ISomeInterface>
	{
		public void Handle(ISomeInterface message)
		{
            Console.WriteLine("ISomeInterface Message received");
		}
	}
}
