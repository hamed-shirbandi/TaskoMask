using FluentValidation;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.DeleteBoard;

public sealed class DeleteBoardValidation : AbstractValidator<DeleteBoardRequest>
{
    public DeleteBoardValidation() { }
}
