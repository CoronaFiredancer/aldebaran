using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandApplication.Commands;
using CommandApplication.Switches;

namespace CommandApplication
{
	class ClientExecutor
	{
		public static void Execute(ISwitch invoker)
		{
			var input = Console.ReadLine();
			
			while (input != null && input != "x")
			{
				switch (input)
				{
					case "o":
						invoker.FireCommand(invoker.Commands[0]);
						break;
					case "c":
						invoker.FireCommand(invoker.Commands[1]);
						break;
				}
				input = Console.ReadLine();
			}
		}
	}
}
