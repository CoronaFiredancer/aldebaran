using System.Collections.Generic;
using CommandApplication.Switchables;

namespace CommandApplication.Commands
{
	internal class Composite : ICommand
	{
		private readonly List<ICommand> _commands = new List<ICommand>();
		public ISwitchable Switchable { get; set; }
		public void Execute()
		{
			foreach (var command in _commands)
			{
				command.Execute();
			}
		}

		public void AddCommand(ICommand command)
		{
			_commands.Add(command);
		}

		public void RemoveCommand(ICommand command)
		{
			_commands.Remove(command);
		}
	}
}
