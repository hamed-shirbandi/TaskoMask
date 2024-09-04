using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.AddProject;

public sealed class AddProjectValidation : AbstractValidator<AddProjectRequest>
{
    public AddProjectValidation()
    {
        ValidateDescription();
    }

    private void ValidateDescription()
    {
        RuleFor(o => o.Description).NotEqual(o => o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
    }
}
