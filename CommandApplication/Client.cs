using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using CommandApplication.Commands;
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
				var lamp = scope.Resolve<IEnumerable<ISwitchable>>().ToList()[0];
				var commands = scope.Resolve<IEnumerable<ICommand>>();

				var commandsList = commands.ToList();

				var switchClose = commandsList[0];
				switchClose.Switchable = lamp;
				var switchOpen = commandsList[1];
				switchOpen.Switchable = lamp;

				ISwitch invoker = new Switch();
				invoker.AddCommand(switchOpen);
				invoker.AddCommand(switchClose);

				ClientExecutor.Execute(invoker);


				var flowValve = scope.Resolve<IEnumerable<ISwitchable>>().ToList()[1];

				var valveClose = commandsList[0];
				valveClose.Switchable = flowValve;

				var valveOpen = commandsList[1];
				valveOpen.Switchable = flowValve;

				var ventil = new Switch();
				ventil.AddCommand(valveOpen);
				ventil.AddCommand(valveClose);

				ClientExecutor.Execute(ventil);

			}
		}
	}
}
