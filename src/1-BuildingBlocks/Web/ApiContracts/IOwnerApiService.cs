using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Web.ApiContracts
{
    public interface IOwnerApiService
    {
        Task<Result<OwnerBasicInfoDto>> Get();
        Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input);
        Task<Result<CommandResult>> Register(RegisterOwnerDto input);
    }
}
