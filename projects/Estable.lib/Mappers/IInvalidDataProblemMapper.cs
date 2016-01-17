using System.Collections.Generic;
using Estable.Lib.Problems;
using FluentValidation.Results;

namespace Estable.Lib.Mappers
{
	public interface IInvalidDataProblemMapper
	{
		InvalidDataProblem Map(IEnumerable<ValidationFailure> errors);
	}
}
