using Autofac;
using CommandApplication.Commands;
using CommandApplication.Switchables;
using CommandApplication.Switches;

namespace CommandApplication.Containers
{
	public class ContainerSetup
	{
		private ContainerBuilder _builder;

		public IContainer BuildContainer()
		{
			_builder = new ContainerBuilder();

			_builder.RegisterType<CloseSwitch>().As<ICommand>();
			_builder.RegisterType<OpenSwitch>().As<ICommand>().PreserveExistingDefaults();
			_builder.RegisterType<Reset>().As<ICommand>().PreserveExistingDefaults();

			_builder.RegisterType<Switch>().As<ISwitch>();

			_builder.RegisterType<Light>().As<ISwitchable>();
			_builder.RegisterType<Valve>().As<ISwitchable>().PreserveExistingDefaults();

			return _builder.Build();
		}
	}
}
