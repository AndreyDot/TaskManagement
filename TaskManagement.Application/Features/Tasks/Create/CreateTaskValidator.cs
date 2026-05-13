using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.Create
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.TaskData.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.TaskData.Description)
                .MaximumLength(500);

            RuleFor(x => x.TaskData.Priority)
                .IsInEnum();
        }
    }
}