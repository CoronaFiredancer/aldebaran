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
	class Client
	{
		private static IContainer Container { get; set; }
		static void Main(string[] args)
		{
			var containerSetup = new ContainerSetup();
			Container = containerSetup.BuildContainer();



			ISwitch invoker;
			ISwitchable lamp;
			IEnumerable<ICommand> commands;
			using (var scope = Container.BeginLifetimeScope())
			{
				lamp = scope.Resolve<ISwitchable>();
				commands = scope.Resolve<IEnumerable<ICommand>>();

				var commandsList = commands.ToList();

				var switchClose = commandsList[0];
				switchClose.Switchable = lamp;
				var switchOpen = commandsList[1];
				switchOpen.Switchable = lamp;

				invoker = new Switch(switchClose, switchOpen);
				invoker.AddCommand(switchOpen);
				invoker.AddCommand(switchClose);


				var input = Console.ReadLine();

				while (input != null && input != "x")
				{
					switch (input)
					{
						case "o":
							//invoker.Open();
							invoker.FireCommand(switchOpen);
							break;
						case "c":
							//invoker.Close();
							invoker.FireCommand(switchClose);
							break;
					}
					input = Console.ReadLine();
				}


				ISwitchable flowValve = new Valve();
				ICommand valveClose = new CloseSwitch(flowValve);
				ICommand valveOpen = new OpenSwitch(flowValve);

				var ventil = new Switch(valveClose, valveOpen);
				input = "";

				while (input != null && input != "x")
				{
					switch (input)
					{
						case "o":
							ventil.Open();
							break;
						case "c":
							ventil.Close();
							break;
					}
					input = Console.ReadLine();
				}
			}
		}
	}
}
