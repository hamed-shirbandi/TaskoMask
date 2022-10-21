using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;

namespace TaskoMask.BuildingBlocks.Contracts.Api.Cards
{
    public interface ICardWriteApiService
    {
        Task<Result<CommandResult>> Add(AddCardDto input);
        Task<Result<CommandResult>> Update(string id, UpdateCardDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}
