using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			var sub = new Subtract();
			var add = new Add();
			var result = add.Run(1, 4);
			
			Console.WriteLine(result);
			result = sub.Run(1, 4);
			Console.WriteLine(result);

			var comp = new Composite();
			comp.AddOperation(add);
			comp.AddOperation(sub);
			comp.Run(1, 5);

			foreach (var d in comp.ResultsList)
			{
				Console.WriteLine(d);
			}

			comp.RemoveOperation(add);
			comp.Run(1, 6);

			foreach (var d in comp.ResultsList)
			{
				Console.WriteLine(d);
			}


			var interest = new AddInterest();
			comp.AddOperation(interest);
			comp.Run(100, 6);

			foreach (var d in comp.ResultsList)
			{
				Console.WriteLine(d);
			}

			while (!string.IsNullOrEmpty(Console.ReadLine()))
			{

			}
		}
	}
}
