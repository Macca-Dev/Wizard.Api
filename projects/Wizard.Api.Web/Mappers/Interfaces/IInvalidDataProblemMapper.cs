using System.Collections.Generic;
using FluentValidation.Results;
using Wizard.Api.Problems;

namespace Wizard.Api.Mappers.Interfaces
{
    public interface IInvalidDataProblemMapper
    {
        InvalidDataProblem Map(IEnumerable<ValidationFailure> errors);
    }
}