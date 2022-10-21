using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

namespace TaskoMask.BuildingBlocks.Contracts.Api.Owners
{
    public interface IOwnerWriteApiService
    {
        Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input);
        Task<Result<CommandResult>> Register(RegisterOwnerDto input);
    }
}
