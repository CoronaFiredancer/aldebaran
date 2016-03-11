namespace CommandApplication
{
	public class OpenSwitchCommand : ICommand
	{
		public ISwitchable Switchable { get; set; }

		public OpenSwitchCommand(ISwitchable switchable)
		{
			Switchable = switchable;
		}

		public void Execute()
		{
			Switchable.Open();
		}
	}
}
