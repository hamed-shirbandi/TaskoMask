using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.UpdateProject
{
    public abstract class UpdateProjectValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UpdateProjectRequest
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
}
