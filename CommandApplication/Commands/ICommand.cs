using CommandApplication.Switchables;

namespace CommandApplication.Commands
{
	public interface ICommand
	{
		ISwitchable Switchable { get; }
		void Execute();
	}
}
