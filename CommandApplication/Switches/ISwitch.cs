﻿using System.Collections.Generic;
using CommandApplication.Commands;

namespace CommandApplication.Switches
{
	public interface ISwitch
	{
		void FireCommand(ICommand command);
		void AddCommand(ICommand command);
		void RemoveCommand(ICommand command);
		void ClearCommands();
		List<ICommand> Commands { get; set; }
	}
}