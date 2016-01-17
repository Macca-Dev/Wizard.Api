using System.Collections.Generic;
using Estable.Lib.Contracts;
using Estable.Lib.Extensions;

namespace Estable.Lib.Problems
{
	public class InvalidDataProblem : JsonSerializable
	{
		public IEnumerable<DataProblem> Problems { get; set; }

		public string ToJson => this.ToJson<InvalidDataProblem>();
	}

	public class DataProblem
	{
		public string FieldName { get; set; }
		public string ProblemMessage { get; set; }
	}
}
