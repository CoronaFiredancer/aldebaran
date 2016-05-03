using System;
using System.Collections.Generic;
using System.Linq;
using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public class Switch : ISwitch
	{
		private readonly ICommand _closedCommand;
		private readonly ICommand _openedCommand;
		private ICommand _lastExecuted;
		private List<ICommand> _commands;

		public Switch(ICommand closedCommand, ICommand openedCommand)
		{
			_commands = new List<ICommand>();
			_closedCommand = closedCommand;
			_openedCommand = openedCommand;
			_lastExecuted = null;
		}

		public void Close()
		{
			if(_lastExecuted == _closedCommand)
			{
				Console.WriteLine("Already closed");
				return;
			}
			_lastExecuted = _closedCommand;
			_closedCommand.Execute();
		}

		public void FireCommand(ICommand command)
		{
			var executor = _commands.FirstOrDefault(x => x.Equals(command));
			if (executor != null && executor.Equals(_lastExecuted))
			{
				Console.WriteLine($"Cannot execute {executor.GetType().Name} again");
			}
			_lastExecuted = executor;
			executor?.Execute();
		}

		public void Open()
		{
			if(_lastExecuted == _openedCommand)
			{
				Console.WriteLine("Already open");
				return;
			}
			_lastExecuted = _openedCommand;
			_openedCommand.Execute();
		}

	}
}
