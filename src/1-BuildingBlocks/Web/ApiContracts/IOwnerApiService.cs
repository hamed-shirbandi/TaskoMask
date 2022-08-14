using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.ApiContracts
{
    public interface IOwnerApiService
    {
        Task<Result<OwnerBasicInfoDto>> Get();
        Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input);
    }
}
