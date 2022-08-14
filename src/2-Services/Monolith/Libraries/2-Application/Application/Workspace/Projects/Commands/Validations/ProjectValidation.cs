using FluentValidation;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.Core.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Validations
{
    public abstract class ProjectValidation<TProjectCommand> : AbstractValidator<TProjectCommand> where TProjectCommand : ProjectBaseCommand
    {

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o=>o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
