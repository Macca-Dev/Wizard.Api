using Estable.Lib.Problems;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Estable.Lib.Mappers.Impl
{
	public class InvalidDataProblemMapper : IInvalidDataProblemMapper
	{
		public InvalidDataProblem Map(IEnumerable<ValidationFailure> errors)
		{
			return new InvalidDataProblem
			{
				Problems = errors.Select(Map)
			};
		}

		private static DataProblem Map(ValidationFailure error)
		{
			return new DataProblem
			{
				FieldName = error.PropertyName,
				ProblemMessage = error.ErrorMessage
			};
		}
	}
}
