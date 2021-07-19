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
   public class CreateProjectCommandValidation:ProjectValidation<CreateProjectCommand>
    {
        public CreateProjectCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateOrganizationId();
        }

        private void ValidateOrganizationId()
        {
            RuleFor(o => o.OrganizationId).NotEmpty().WithMessage(ApplicationMetadata.OrganizationId_Required);
        }
    }
}
