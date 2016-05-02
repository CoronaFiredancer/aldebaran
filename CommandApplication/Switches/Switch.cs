using System;
using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public class Switch : ISwitch
	{
		private readonly ICommand _closedCommand;
		private readonly ICommand _openedCommand;
		private ICommand _lastExecuted;

		public Switch(ICommand closedCommand, ICommand openedCommand)
		{
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
