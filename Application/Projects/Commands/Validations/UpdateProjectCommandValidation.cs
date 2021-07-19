using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Commands.Validations.Projects
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
            RuleFor(o => o.Id).NotEmpty().WithMessage(ApplicationMetadata.ProjectId_Required);
        }

    }
}
