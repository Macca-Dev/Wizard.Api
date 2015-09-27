using System.Collections.Generic;
using Wizard.Api.Contracts;
using Wizard.Api.Extensions;

namespace Wizard.Api.Problems
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