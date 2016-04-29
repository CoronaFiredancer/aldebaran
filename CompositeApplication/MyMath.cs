using System.Collections.Generic;

namespace CompositeApplication
{
	public class Add : IOperation
	{
		public double Run(double a, double b)
		{
			return a + b;
		}
	}

	public class Subtract : IOperation
	{
		public double Run(double a, double b)
		{
			return a - b;
		}
	}

	public class AddInterest : IOperation
	{
		public double Run(double a, double b)
		{
			return a * (1 + (b / 100));
		}
	}
}
