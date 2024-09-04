using FluentValidation;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.AddBoard;

public sealed class AddBoardValidation : AbstractValidator<AddBoardRequest>
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
