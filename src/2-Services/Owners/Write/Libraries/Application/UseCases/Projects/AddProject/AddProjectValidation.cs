using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject
{
    public abstract class AddProjectValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddProjectRequest
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
}
