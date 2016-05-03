using CommandApplication.Switchables;

namespace CommandApplication.Commands
{
	class Reset : ICommand
	{
		public ISwitchable Switchable { get; set; }

		public Reset(ISwitchable switchable)
		{
			Switchable = switchable;
		}
		public void Execute()
		{
			Switchable.ResetTheSwitch();
		}
	}
}
