using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Boards.Commands.Validations
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
