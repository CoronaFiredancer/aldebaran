using CommandApplication.Switchables;

namespace CommandApplication.Commands
{
	public class OpenSwitch : ICommand
	{
		public ISwitchable Switchable { get; set; }

		public OpenSwitch(ISwitchable switchable)
		{
			Switchable = switchable;
		}

		public void Execute()
		{
			Switchable.OpenTheSwitch();
		}
	}
}
