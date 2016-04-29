using System;

namespace CommandApplication
{
	public class Switch
	{
		private readonly ICommand _closedCommand;
		private readonly ICommand _openedCommand;
		private ICommand lastExecuted;

		public Switch(ICommand closedCommand, ICommand openedCommand)
		{
			_closedCommand = closedCommand;
			_openedCommand = openedCommand;
			lastExecuted = null;
		}

		public void Close()
		{
			if(lastExecuted == _closedCommand)
			{
				Console.WriteLine("Already closed");
				return;
			}
			lastExecuted = _closedCommand;
			_closedCommand.Execute();
		}

		public void Open()
		{
			if(lastExecuted == _openedCommand)
			{
				Console.WriteLine("Already open");
				return;
			}
			lastExecuted = _openedCommand;
			_openedCommand.Execute();
		}

	}
}
