using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Cards.Commands.Validations
{
    public abstract class CardValidation<T> : AbstractValidator<T> where T : CardCommand
    {
        private const int minNameLenth = 5;
        private const int maxNameLenth = 50;

        private const int minDescriptionLenth = 5;
        private const int maxDescriptionLenth = 250;


        protected void ValidateName()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage(ApplicationMetadata.Required);
            RuleFor(o => o.Name).Length(minNameLenth, maxNameLenth).WithMessage(string.Format(ApplicationMetadata.Length_Error, minNameLenth, maxNameLenth));
        }

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEmpty().WithMessage(ApplicationMetadata.Required);
            RuleFor(o => o.Description).Length(minDescriptionLenth, maxDescriptionLenth).WithMessage(string.Format(ApplicationMetadata.Length_Error, minDescriptionLenth, maxDescriptionLenth));
        }
    }
}
