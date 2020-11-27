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
   public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateDisplayName();
        }

    
    }
}
