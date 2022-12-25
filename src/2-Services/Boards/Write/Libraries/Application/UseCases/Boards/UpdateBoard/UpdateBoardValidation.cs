using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Boards.UpdateBoard
{
    public abstract class UpdateBoardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : UpdateBoardRequest
    {
        public UpdateBoardValidation()
        {
            ValidateDescription();
        }


        private void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o => o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
