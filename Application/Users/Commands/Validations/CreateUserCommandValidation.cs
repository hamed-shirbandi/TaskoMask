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
   public class CreateUserCommandValidation:UserValidation<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            ValidateDisplayName();
            ValidateEmail();
        }

      
    }
}
