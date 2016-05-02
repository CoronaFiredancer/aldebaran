using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandApplication.Commands;
using CommandApplication.Switchables;

namespace CommandApplication.Containers
{
	public class ContainerSetup
	{
		private ContainerBuilder _builder;

		public IContainer BuildContainer()
		{
			_builder = new ContainerBuilder();

			_builder.RegisterType<Light>().As<ISwitchable>();

			//builder.RegisterType<Valve>().As<ISwitchable>();
			_builder.RegisterType<CloseSwitch>().As<ICommand>();
			_builder.RegisterType<OpenSwitch>().As<ICommand>();

			return _builder.Build();
		}
	}
}
