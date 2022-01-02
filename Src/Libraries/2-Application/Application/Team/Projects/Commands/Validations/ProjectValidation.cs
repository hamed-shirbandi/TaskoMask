using FluentValidation;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Team.Projects.Commands.Models;

namespace TaskoMask.Application.Team.Projects.Commands.Validations
{
    public abstract class ProjectValidation<T> : AbstractValidator<T> where T : ProjectBaseCommand
    {

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o=>o.Name).WithMessage(ApplicationMetadata.Equal_Name_And_Description_Error);
        }
    }
}
