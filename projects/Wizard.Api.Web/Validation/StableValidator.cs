using System;
using FluentValidation;
using Estable.Lib.Contracts;

namespace Wizard.Api.Validation
{
    public class StableValidator : AbstractValidator<StableDataContract>
    {
        public StableValidator()
        {
            RuleFor(stable => stable.StableName)
                .NotEmpty()
                .WithMessage("Please enter your stable name.");
                
            RuleFor(stable => stable.RacingCode)
                .Must(BeAValidCode)
                .WithMessage("Please select a valid Racing Code.");

            RuleFor(stable => stable.Trainer)
                .NotEmpty()
                .WithMessage("Please enter your trainer.");

            RuleFor(stable => stable.LegalEntity)
                .NotEmpty()
                .WithMessage("Please enter your legal entity.");

            RuleFor(stable => stable.Mobile)
                .NotEmpty()
                .WithMessage("Please enter your mobile.");

            RuleFor(stable => stable.Phone)
                .NotEmpty()
                .WithMessage("Please enter your phone.");

            RuleFor(stable => stable.Fax)
                .NotEmpty()
                .WithMessage("Please enter your fax.");

            RuleFor(stable => stable.Address)
                .NotEmpty()
                .WithMessage("Please enter your address.");
        }

        private static bool BeAValidCode(string racingCode)
        {
            if (String.IsNullOrEmpty(racingCode))
            {
                return false;
            }

            var code = racingCode.ToLower();
            
            return (code == "gallops" ||
                    code == "harness" ||
                    code == "greyhound" ||
                    code == "other");
        }
    }
}