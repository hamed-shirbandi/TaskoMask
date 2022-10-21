using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Api.Cards
{
    public interface ICardReadApiService
    {
        Task<Result<CardBasicInfoDto>> Get(string id);
        Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems(string boardId);
    }
}
