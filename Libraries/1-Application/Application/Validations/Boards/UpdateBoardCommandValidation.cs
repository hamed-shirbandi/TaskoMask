using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Boards;
using TaskoMask.Application.Resources;

namespace TaskoMask.Application.Validations.Boards
{
   public class UpdateBoardCommandValidation : BoardValidation<UpdateBoardCommand>
    {
        public UpdateBoardCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(o => o.Id).NotEmpty().WithMessage(ApplicationMetadata.BoardId_Required);
        }

    }
}
