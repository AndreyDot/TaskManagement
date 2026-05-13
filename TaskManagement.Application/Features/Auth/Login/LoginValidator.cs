using FluentValidation;

namespace TaskManagement.Application.Features.Auth.Login
{
    public class LoginValidator: AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Data.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Data.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    }
}
