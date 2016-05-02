using System;

namespace CommandApplication.Switchables
{
	public class Valve : ISwitchable
	{
		public void Open()
		{
			Console.WriteLine("Valve open");
		}

		public void Close()
		{
			Console.WriteLine("Valve is now closed");
		}
	}
}
