using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Cards.Commands.Validations
{
   public class UpdateCardCommandValidation : CardValidation<UpdateCardCommand>
    {
        public UpdateCardCommandValidation()
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
