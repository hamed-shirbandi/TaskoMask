using FluentValidation;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Workspace.Projects.Commands.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Projects.Commands.Validations
{
    public abstract class ProjectValidation<T> : AbstractValidator<T> where T : ProjectBaseCommand
    {

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o=>o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
