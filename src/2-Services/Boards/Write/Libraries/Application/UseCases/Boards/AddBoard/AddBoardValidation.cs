using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Boards.AddBoard
{
    public abstract class AddBoardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : AddBoardRequest
    {
        public AddBoardValidation()
        {
            ValidateDescription();
        }


        private void ValidateDescription()
        {
            RuleFor(o => o.Description).NotEqual(o => o.Name).WithMessage(DomainMessages.Equal_Name_And_Description_Error);
        }
    }
}
