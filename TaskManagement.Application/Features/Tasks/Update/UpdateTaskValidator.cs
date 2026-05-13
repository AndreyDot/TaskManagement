using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.Update;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.UpdateData.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.UpdateData.Description)
            .MaximumLength(500);

        RuleFor(x => x.UpdateData.Priority)
            .IsInEnum();

        RuleFor(x => x.UpdateData.Status)
            .IsInEnum();
    }
}