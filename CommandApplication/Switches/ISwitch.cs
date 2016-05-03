using System.Collections.Generic;
using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public abstract class ISwitch
	{
		public List<ICommand> Commands;
		public abstract void FireCommand(ICommand command);
		public abstract void AddCommand(ICommand command);
		public abstract void RemoveCommand(ICommand command);
	}
}