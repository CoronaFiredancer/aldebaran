using System.Collections.Generic;
using System.Linq;
using Autofac;
using CommandApplication.Containers;
using CommandApplication.Switchables;
using CommandApplication.Switches;

namespace CommandApplication
{
	internal class Client
	{
		private static IContainer Container { get; set; }
		static void Main(string[] args)
		{
			var containerSetup = new ContainerSetup();
			Container = containerSetup.BuildContainer();


			using (var scope = Container.BeginLifetimeScope())
			{
				var invoker = scope.Resolve<ISwitch>();
				ClientExecutor.Execute(invoker);

				var flowValve = scope.Resolve<IEnumerable<ISwitchable>>().ToList()[1];
				var ventil = scope.Resolve<ISwitch>();

				foreach (var command in ventil.Commands)
				{
					command.Switchable = flowValve;
				}

				ClientExecutor.Execute(ventil);
			}
		}
	}
}
