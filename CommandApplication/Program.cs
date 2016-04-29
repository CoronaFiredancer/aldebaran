using System;
using Autofac;

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
			builder.RegisterType<CloseSwitchCommand>().As<ICommand>();
			builder.RegisterType<OpenSwitchCommand>().As<ICommand>();

			Container = builder.Build();




			ISwitchable lamp = new Light();
			ISwitchable flowValve = new Valve();

			ICommand switchClose = new CloseSwitchCommand(lamp);
			ICommand switchOpen = new OpenSwitchCommand(lamp);

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

			switchClose.Switchable = flowValve;
			switchOpen.Switchable = flowValve;

			var ventil = new Switch(switchClose, switchOpen);
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
