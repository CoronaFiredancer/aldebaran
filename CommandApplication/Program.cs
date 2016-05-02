using System;
using Autofac;
using CommandApplication.Commands;
using CommandApplication.Switchables;

namespace CommandApplication
{
	class Program
	{
		private static IContainer Container { get; set; }
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<Light>().As<ISwitchable>();
			builder.RegisterType<Valve>().As<ISwitchable>();
			builder.RegisterType<CloseSwitch>().As<ICommand>();
			builder.RegisterType<OpenSwitch>().As<ICommand>();

			Container = builder.Build();




			ISwitchable lamp = new Light();
			

			ICommand switchClose = new CloseSwitch(lamp);
			ICommand switchOpen = new OpenSwitch(lamp);

			var invoker = new Switch(switchClose, switchOpen);
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
