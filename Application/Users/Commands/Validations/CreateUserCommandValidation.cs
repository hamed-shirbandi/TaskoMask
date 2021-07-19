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
   public class CreateUserCommandValidation:UserValidation<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            ValidateDisplayName();
            ValidateEmail();
        }

      
    }
}
