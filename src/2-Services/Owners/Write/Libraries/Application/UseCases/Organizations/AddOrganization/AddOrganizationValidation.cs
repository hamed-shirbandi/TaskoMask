using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization
{
    public abstract class AddOrganizationValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddOrganizationRequest
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
}
