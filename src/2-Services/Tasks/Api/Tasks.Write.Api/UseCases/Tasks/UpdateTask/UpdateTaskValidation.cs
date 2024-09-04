using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.UpdateTask;

public sealed class UpdateTaskValidation : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskValidation()
    {
        ValidateDescription();
    }

    private void ValidateDescription()
    {
        RuleFor(o => o.Description).NotEqual(o => o.Title).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
    }
}
