using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.UpdateProject;

public sealed class UpdateProjectValidation : AbstractValidator<UpdateProjectRequest>
{
    public UpdateProjectValidation()
    {
        ValidateDescription();
    }

    private void ValidateDescription()
    {
        RuleFor(o => o.Description).NotEqual(o => o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
    }
}
