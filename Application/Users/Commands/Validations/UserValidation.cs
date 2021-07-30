using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Users.Commands.Validations
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        private const int minDisplayNameLenth = 5;
        private const int maxDisplayNameLenth = 50;



        protected void ValidateDisplayName()
        {
            RuleFor(o => o.DisplayName).NotEmpty().WithMessage(ApplicationMetadata.Required);
            RuleFor(o => o.DisplayName).Length(minDisplayNameLenth, maxDisplayNameLenth).WithMessage(string.Format(ApplicationMetadata.Length_Error, minDisplayNameLenth, maxDisplayNameLenth));
        }

        protected void ValidateEmail()
        {
            RuleFor(o => o.Email).NotEmpty().WithMessage(ApplicationMetadata.Required);
        }

    }

}
