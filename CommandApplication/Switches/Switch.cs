using System;
using System.Collections.Generic;
using System.Linq;
using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public class Switch : ISwitch
	{
		private ICommand _lastExecuted;
		public List<ICommand> Commands { get; set; }
		
		public Switch(IEnumerable<ICommand> commands)
		{
			Commands = commands.ToList();
			_lastExecuted = null;
		}
		public void FireCommand(ICommand command)
		{
			var executor = Commands.FirstOrDefault(x => x.Equals(command));
			if (executor != null && executor.Equals(_lastExecuted))
			{
				Console.WriteLine($"Cannot execute {executor.GetType().Name} again");
				return;
			}
			_lastExecuted = executor;
			executor?.Execute();
		}

		public void AddCommand(ICommand command)
		{
			Commands.Add(command);
		}
		public void RemoveCommand(ICommand command)
		{
			Commands.Remove(command);
		}

	}
}
