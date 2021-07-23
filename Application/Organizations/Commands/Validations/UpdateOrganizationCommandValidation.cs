using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Organizations.Commands.Validations
{
   public class UpdateOrganizationCommandValidation : OrganizationValidation<UpdateOrganizationCommand>
    {
        public UpdateOrganizationCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(o => o.Id).NotEmpty().WithMessage(ApplicationMetadata.OrganizationId_Required);
        }
    }
}
