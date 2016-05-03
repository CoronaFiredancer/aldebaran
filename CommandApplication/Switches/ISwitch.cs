using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public interface ISwitch
	{
		void Open();
		void Close();
		void FireCommand(ICommand command);
	}
}