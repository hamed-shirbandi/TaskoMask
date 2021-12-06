using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Team.Organizations.Commands.Models;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Team.Organizations.Commands.Validations
{
    public abstract class OrganizationValidation<T> : AbstractValidator<T> where T : OrganizationBaseCommand
    {

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o=>o.Name).WithMessage(ApplicationMetadata.Equal_Name_And_Description_Error);
        }
    }
}
