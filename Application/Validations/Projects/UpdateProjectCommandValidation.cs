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
   public class UpdateProjectCommandValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidation()
        {
            ValidateName();
            ValidateDescription();
        }

    
    }
}
