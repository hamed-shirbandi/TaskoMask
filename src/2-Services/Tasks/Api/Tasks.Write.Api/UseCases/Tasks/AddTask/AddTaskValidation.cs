using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.AddTask;

public sealed class AddTaskValidation : AbstractValidator<AddTaskRequest>
{
    public AddTaskValidation()
    {
        ValidateDescription();
    }

    private void ValidateDescription()
    {
        RuleFor(o => o.Description).NotEqual(o => o.Title).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
    }
}
