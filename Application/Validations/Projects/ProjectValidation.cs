using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Validations.Projects
{
    public abstract class ProjectValidation<T> : AbstractValidator<T> where T : ProjectCommand
    {
        private const int minNameLenth = 5;
        private const int maxNameLenth = 50;

        private const int minDescriptionLenth = 5;
        private const int maxDescriptionLenth = 250;


        protected void ValidateName()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage(ApplicationMetadata.Name_Required);
            RuleFor(o => o.Name).Length(minNameLenth, maxNameLenth).WithMessage(string.Format(ApplicationMetadata.Name_Length_Error, minNameLenth, maxNameLenth));
        }

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEmpty().WithMessage(ApplicationMetadata.Description_Required);
            RuleFor(o => o.Description).Length(minDescriptionLenth, maxDescriptionLenth).WithMessage(string.Format(ApplicationMetadata.Description_Length_Error, minDescriptionLenth, maxDescriptionLenth));
        }
    }
}
