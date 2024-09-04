using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.AddOrganization;

public sealed class AddOrganizationValidation : AbstractValidator<AddOrganizationRequest>
{
    public AddOrganizationValidation()
    {
        ValidateDescription();
    }

    private void ValidateDescription()
    {
        RuleFor(o => o.Description).NotEqual(o => o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
    }
}
