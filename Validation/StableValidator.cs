using FluentValidation;
using Wizard.Api.Models;

namespace Wizard.Api.Validation
{
    public class StableValidator : AbstractValidator<StableContract>
    {
        public StableValidator()
        {
            RuleFor(stable => stable.RacingCode)
                .Must(BeAValidCode)
                .WithMessage(" ");


        }

        private static bool BeAValidCode(string racingCode)
        {
            var code = racingCode.ToLower();
            
            return (code == "gallops" ||
                    code == "harness" ||
                    code == "greyhound" ||
                    code == "other");
        }
    }
}