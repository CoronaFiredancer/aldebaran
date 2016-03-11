namespace CommandApplication
{
	public interface ICommand
	{
		ISwitchable Switchable { get; set; }
		void Execute();
	}
}
