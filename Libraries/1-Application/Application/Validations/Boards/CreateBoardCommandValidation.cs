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
            RuleFor(o => o.ProjectId).NotEmpty().WithMessage(ApplicationMetadata.ProjectId_Required);
        }
    }
}
