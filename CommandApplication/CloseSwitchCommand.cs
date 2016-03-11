namespace CommandApplication
{
	public class CloseSwitchCommand : ICommand
	{
		public ISwitchable Switchable { get; set; }

		public CloseSwitchCommand(ISwitchable switchable)
		{
			Switchable = switchable;
		}
		public void Execute()
		{
			Switchable.Close();
		}
	}
}
