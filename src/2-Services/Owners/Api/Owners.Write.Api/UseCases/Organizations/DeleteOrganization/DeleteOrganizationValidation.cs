using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.DeleteOrganization;

public sealed class DeleteOrganizationValidation : AbstractValidator<DeleteOrganizationRequest>
{
    public DeleteOrganizationValidation() { }
}
