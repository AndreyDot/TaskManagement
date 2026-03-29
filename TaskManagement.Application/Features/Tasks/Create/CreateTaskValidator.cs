using FluentValidation;
using TaskManagement.Application.Features.Tasks.DTOs;

namespace TaskManagement.Application.Features.Tasks.Create
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must be less than 500 characters");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Priority value is invalid");
        }

    }
}
