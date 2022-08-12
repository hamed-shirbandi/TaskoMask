using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.ApiContracts
{
    public interface ICardApiService
    {
        Task<Result<CardBasicInfoDto>> Get(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string boardId);
        Task<Result<CommandResult>> Add(AddCardDto input);
        Task<Result<CommandResult>> Update(string id,UpdateCardDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}
