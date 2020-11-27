using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Users;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Validations.Users
{
   public class CreateUserCommandValidation:UserValidation<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            ValidateDisplayName();
        }

        private void ValidateUserId()
        {
            RuleFor(o => o.UserId).NotEmpty().WithMessage(ApplicationMetadata.UserId_Required);
        }
    }
}
