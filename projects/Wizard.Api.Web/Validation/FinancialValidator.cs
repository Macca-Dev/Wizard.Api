using FluentValidation;
using Estable.Lib.Contracts;

namespace Wizard.Api.Validation
{
    public class FinancialValidator : AbstractValidator<FinancialContract>
    {
        public FinancialValidator()
        {
            RuleFor(it => it.TaxNumber)
                .NotEmpty()
                .WithMessage("Please enter a tax number");

            RuleFor(it => it.TaxRate)
                .NotEmpty()
                .WithMessage("Please enter a tax rate");

            RuleFor(it => it.TaxDate)
                .NotEmpty()
                .WithMessage("Please enter a tax date");
        }
    }
}