using CommandApplication.Switchables;

namespace CommandApplication.Commands
{
	public class CloseSwitch : ICommand
	{
		public ISwitchable Switchable { get; set; }

		public CloseSwitch(ISwitchable switchable)
		{
			Switchable = switchable;
		}
		public void Execute()
		{
			Switchable.CloseTheSwitch();
		}
	}
}
