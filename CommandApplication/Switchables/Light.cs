using System;

namespace CommandApplication.Switchables
{
	public class Light : ISwitchable
	{
		public void Open()
		{
			Console.WriteLine("The light is on");
		}

		public void Close()
		{
			Console.WriteLine("The light is now turned off");
		}
	}
}
