using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeApplication
{
	public class Composite : IOperation
	{
		private readonly List<IOperation> _operations = new List<IOperation>();
		public List<double> ResultsList;
		public double Run(double a, double b)
		{
			ResultsList = new List<double>();
			foreach (var operation in _operations)
			{
				ResultsList.Add(operation.Run(a, b));
			}

			return ResultsList.Last();
		}

		public void AddOperation(IOperation operation)
		{
			_operations.Add(operation);
		}

		public void RemoveOperation(IOperation operation)
		{
			_operations.Remove(operation);
		}
	}
}
