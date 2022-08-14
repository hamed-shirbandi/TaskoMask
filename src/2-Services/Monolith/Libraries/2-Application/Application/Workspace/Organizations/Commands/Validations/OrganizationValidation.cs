using FluentValidation;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Validations
{
    public abstract class OrganizationValidation<TOrganizationCommand> : AbstractValidator<TOrganizationCommand> where TOrganizationCommand : OrganizationBaseCommand
    {
        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o=>o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
