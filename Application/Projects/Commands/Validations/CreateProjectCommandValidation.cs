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
            RuleFor(o => o.OrganizationId).NotEmpty().WithMessage(ApplicationMetadata.Required);
        }
    }
}
