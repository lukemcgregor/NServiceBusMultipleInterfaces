using NsbInterfaces.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsbInterfaces.Subscriber
{
	public class MyHandler : IHandleMessages<ISomeOtherInterface>
	{
		public void Handle(ISomeOtherInterface message)
		{
			Console.WriteLine("Message received");
		}
	}
}
