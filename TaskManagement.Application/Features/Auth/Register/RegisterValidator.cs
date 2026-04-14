using FluentValidation;

namespace TaskManagement.Application.Features.Auth.Register
{
    public class RegisterValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Data.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Data.Password)
            .NotEmpty()
            .MinimumLength(6);
        }
    }
}
