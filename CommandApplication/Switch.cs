namespace CommandApplication
{
	public class Switch
	{
		private readonly ICommand _closedCommand;
		private readonly ICommand _openedCommand;

		public Switch(ICommand closedCommand, ICommand openedCommand)
		{
			_closedCommand = closedCommand;
			_openedCommand = openedCommand;
		}

		public void Close()
		{
			_closedCommand.Execute();
		}

		public void Open()
		{
			_openedCommand.Execute();
		}

	}
}
