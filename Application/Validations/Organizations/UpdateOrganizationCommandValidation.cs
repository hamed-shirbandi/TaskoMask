using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Organizations;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Validations.Organizations
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
