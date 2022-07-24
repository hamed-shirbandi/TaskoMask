using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.ApiContracts
{
    public interface IOwnerClientService
    {
        Task<Result<OwnerBasicInfoDto>> Get();
        Task<Result<CommandResult>> Update(OwnerUpdateDto input);
    }
}
