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
   public class CreateBoardCommandValidation:BoardValidation<CreateBoardCommand>
    {
        public CreateBoardCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateProjectId();
        }

        private void ValidateProjectId()
        {
            RuleFor(o => o.ProjectId).NotEmpty().WithMessage(ApplicationMetadata.Required);
        }
    }
}
