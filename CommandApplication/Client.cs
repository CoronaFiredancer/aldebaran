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
			//ICommand switchClose;
			IEnumerable<ICommand> commands;
			using (var scope = Container.BeginLifetimeScope())
			{
				lamp = scope.Resolve<ISwitchable>();
				//invoker = scope.Resolve<ISwitch>();
				//var x = scope.Resolve<ISwitch>().
				//switchClose = scope.Resolve<ICommand>(new List<Parameter> {new NamedParameter("CloseSwitch", typeof (CloseSwitch))});
				//switchClose = scope.Resolve<ICommand>(new NamedParameter("Switchable", typeof(CloseSwitch)));
				commands = scope.Resolve<IEnumerable<ICommand>>();


			}



			//ISwitchable lamp = new Light();
			ICommand switchClose = commands.First();
			switchClose.Switchable = lamp;// new CloseSwitch(lamp);
			ICommand switchOpen = new OpenSwitch(lamp);

			invoker = new Switch(switchClose, switchOpen);
			var input = Console.ReadLine();

			while (input != null && input != "x")
			{
				switch (input)
				{
					case "o":
						invoker.Open();
						break;
					case "c":
						invoker.Close();
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
