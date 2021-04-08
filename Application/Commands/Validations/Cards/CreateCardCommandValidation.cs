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
   public class CreateCardCommandValidation:CardValidation<CreateCardCommand>
    {
        public CreateCardCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateBoardId();
        }

        private void ValidateBoardId()
        {
            RuleFor(o => o.BoardId).NotEmpty().WithMessage(ApplicationMetadata.BoardId_Required);
        }
    }
}
