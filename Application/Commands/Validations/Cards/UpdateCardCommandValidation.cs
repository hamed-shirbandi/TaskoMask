using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Cards;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Commands.Validations.Cards
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
            RuleFor(o => o.Id).NotEmpty().WithMessage(ApplicationMetadata.CardId_Required);
        }

    }
}
