using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.UpdateOrganization
{
    public abstract class UpdateOrganizationValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UpdateOrganizationRequest
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
}
