using System;

namespace CommandApplication
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
