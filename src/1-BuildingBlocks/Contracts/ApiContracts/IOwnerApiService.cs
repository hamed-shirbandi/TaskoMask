using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts
{
    public interface IOwnerApiService
    {
        Task<Result<OwnerBasicInfoDto>> Get();
        Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input);
        Task<Result<CommandResult>> Register(RegisterOwnerDto input);
    }
}
