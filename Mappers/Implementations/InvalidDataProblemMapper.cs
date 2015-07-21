using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Wizard.Api.Mappers.Interfaces;
using Wizard.Api.Problems;

namespace Wizard.Api.Mappers.Implementations
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