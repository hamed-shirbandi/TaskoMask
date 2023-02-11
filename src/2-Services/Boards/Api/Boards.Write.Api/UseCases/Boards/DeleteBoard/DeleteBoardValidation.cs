using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.DeleteBoard
{
    public abstract class DeleteBoardValidation<TRequest> : AbstractValidator<TRequest> where TRequest : DeleteBoardRequest
    {
        public DeleteBoardValidation()
        {
        }

    }
}
