using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Organizations.Commands.Validations
{
    public abstract class OrganizationValidation<T> : AbstractValidator<T> where T : OrganizationCommand
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
