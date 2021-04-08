using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Users;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Commands.Validations.Users
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        private const int minDisplayNameLenth = 5;
        private const int maxDisplayNameLenth = 50;



        protected void ValidateDisplayName()
        {
            RuleFor(o => o.DisplayName).NotEmpty().WithMessage(ApplicationMetadata.User_DisplayName_Required);
            RuleFor(o => o.DisplayName).Length(minDisplayNameLenth, maxDisplayNameLenth).WithMessage(string.Format(ApplicationMetadata.Name_Length_Error, minDisplayNameLenth, maxDisplayNameLenth));
        }

        protected void ValidateEmail()
        {
            RuleFor(o => o.Email).NotEmpty().WithMessage(ApplicationMetadata.User_Email_Required);
        }

    }

}
