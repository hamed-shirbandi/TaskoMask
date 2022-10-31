using FluentValidation;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization
{
    public abstract class AddOrganizationValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddOrganizationRequest
    {
        public AddOrganizationValidation()
        {
        }

    }
}
