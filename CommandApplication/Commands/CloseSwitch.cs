namespace CommandApplication.Commands
{
	public class CloseSwitch : ICommand
	{
		public ISwitchable Switchable { get; }

		public CloseSwitch(ISwitchable switchable)
		{
			Switchable = switchable;
		}
		public void Execute()
		{
			Switchable.Close();
		}
	}
}
