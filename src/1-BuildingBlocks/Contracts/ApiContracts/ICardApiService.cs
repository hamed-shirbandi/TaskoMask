using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
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
