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
   public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateDisplayName();
            ValidateEmail();
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(c=>c.Id).NotEmpty().WithMessage(ApplicationMetadata.Required);
        }
    }
}
