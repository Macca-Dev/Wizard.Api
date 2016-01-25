using FluentValidation;

namespace Wizard.Api.Validation
{
	public class EmailValidator : AbstractValidator<string>
	{
		public EmailValidator()
		{
			RuleFor(it => it)
				.NotEmpty()
				.NotNull()
				.WithMessage("Please provide a valid email address.");
		}
	}
}