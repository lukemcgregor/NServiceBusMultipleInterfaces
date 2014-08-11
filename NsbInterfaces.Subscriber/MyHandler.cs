namespace NsbInterfaces.Subscriber
{
    using System;
    using Events;
    using NServiceBus;

    public class MyHandler : IHandleMessages<ISomeOtherInterface>
	{
		public void Handle(ISomeOtherInterface message)
		{
            Console.WriteLine("ISomeOtherInterface Message received");
		}
	}
}
