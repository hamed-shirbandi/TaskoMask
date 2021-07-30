using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Projects.Commands.Validations
{
   public class UpdateProjectCommandValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(o => o.Id).NotEmpty().WithMessage(ApplicationMetadata.Required);
        }

    }
}
