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
   public class CreateOrganizationCommandValidation:OrganizationValidation<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateUserId();
        }

        private void ValidateUserId()
        {
            RuleFor(o => o.UserId).NotEmpty().WithMessage(ApplicationMetadata.UserId_Required);
        }
    }
}
