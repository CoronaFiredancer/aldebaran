using System;

namespace CommandApplication.Switchables
{
	public class Light : ISwitchable
	{
		public void OpenTheSwitch()
		{
			Console.WriteLine("The light is on");
		}

		public void CloseTheSwitch()
		{
			Console.WriteLine("The light is now turned off");
		}
	}
}
