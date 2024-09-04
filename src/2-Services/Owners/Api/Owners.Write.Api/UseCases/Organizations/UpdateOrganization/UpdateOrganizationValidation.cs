using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.UpdateOrganization;

public sealed class UpdateOrganizationValidation : AbstractValidator<UpdateOrganizationRequest>
{
    public UpdateOrganizationValidation()
    {
        ValidateDescription();
    }

    private void ValidateDescription()
    {
        RuleFor(o => o.Description).NotEqual(o => o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
    }
}
