using System;
using CommandApplication.Switches;

namespace CommandApplication
{
	internal class ClientExecutor
	{
		public static void Execute(ISwitch invoker)
		{
			Console.WriteLine("Press 'o' to open switch, 'c' to close it. 'x' to close program");
			var input = Console.ReadLine();
			
			while (input != null && input != "x")
			{
				switch (input)
				{
					case "o":
						invoker.FireCommand(invoker.Commands[1]);
						break;
					case "c":
						invoker.FireCommand(invoker.Commands[0]);
						break;
				}
				input = Console.ReadLine();
			}
		}
	}
}
