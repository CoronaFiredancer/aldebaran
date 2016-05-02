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
			//_builder.Register(s => )
			_builder.RegisterType<Switch>()
				.As<ISwitch>()
				.WithParameter("_closedCommand", typeof(CloseSwitch))
				.WithParameter("_openedCommand", typeof(OpenSwitch));

			_builder.RegisterType<Light>().As<ISwitchable>();

			//_builder.Register(ctx => new Switch(ctx.Resolve<CloseSwitch>(), ctx.Resolve<OpenSwitch>()));

			

			return _builder.Build();
		}
	}
}
