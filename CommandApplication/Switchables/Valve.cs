using System;

namespace CommandApplication.Switchables
{
	public class Valve : ISwitchable
	{
		public void OpenTheSwitch()
		{
			Console.WriteLine("Valve open");
		}

		public void CloseTheSwitch()
		{
			Console.WriteLine("Valve is now closed");
		}

		public void ResetTheSwitch()
		{
			Console.WriteLine("Valve is now reset");
		}
	}
}
