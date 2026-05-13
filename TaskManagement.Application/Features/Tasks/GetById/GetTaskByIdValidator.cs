using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.GetById;

public class GetTaskByIdValidator : AbstractValidator<GetTaskByIdQuery>
{
    public GetTaskByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}