using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface ICardClientService
    {
        Task<Result<CardBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Create(CardUpsertDto input);
        Task<Result<CommandResult>> Update(string id,CardUpsertDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}
