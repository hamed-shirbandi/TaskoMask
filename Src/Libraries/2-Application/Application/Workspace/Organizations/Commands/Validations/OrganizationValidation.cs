using FluentValidation;
using TaskoMask.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Organizations.Commands.Validations
{
    public abstract class OrganizationValidation<T> : AbstractValidator<T> where T : OrganizationBaseCommand
    {
        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o=>o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
