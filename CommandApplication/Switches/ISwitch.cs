using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public interface ISwitch
	{
		void Open();
		void Close();
		void FireCommand(ICommand command);
		void AddCommand(ICommand command);
		void RemoveCommand(ICommand command);
	}
}